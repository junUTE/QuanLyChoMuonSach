CREATE DATABASE Test_QLThuVien;
GO
USE Test_QLThuVien;
GO

-- =============== Bảng Người (cha) =================
CREATE TABLE Nguoi (
    maNguoi VARCHAR(10) PRIMARY KEY,
    hoTen NVARCHAR(100) NOT NULL,
    gioiTinh NVARCHAR(10) CHECK (gioiTinh IN (N'Nam',N'Nữ')),
    ngaySinh DATE CHECK (ngaySinh <= GETDATE()),
    diaChi NVARCHAR(MAX),
    SDT VARCHAR(11),
    email NVARCHAR(100) UNIQUE,
    cccd NVARCHAR(20) NOT NULL UNIQUE,
    vaiTro NVARCHAR(10) NOT NULL
        CHECK (vaiTro IN (N'guest', N'staff', N'admin'))
);
GO

-- =============== Bảng Độc giả (con) =================
CREATE TABLE DocGia (
    maDocGia VARCHAR(14) PRIMARY KEY,
    maNguoi VARCHAR(10) UNIQUE NOT NULL
        FOREIGN KEY REFERENCES Nguoi(maNguoi),
    ngayDangKy DATE DEFAULT GETDATE(),
    hanTaiKhoan DATE
);
GO

-- =============== Bảng Nhân viên (con) =================
CREATE TABLE NhanVien (
    maNhanVien VARCHAR(14) PRIMARY KEY,
    maNguoi VARCHAR(10) UNIQUE NOT NULL
        FOREIGN KEY REFERENCES Nguoi(maNguoi),
    chucVu NVARCHAR(50) NULL,
    ngayVaoLam DATE DEFAULT GETDATE(),
    luong DECIMAL(12,2)
);
GO

-- =============== Bảng Tài khoản (nếu cần login) =================
CREATE TABLE TaiKhoan (
    maTaiKhoan VARCHAR(10) PRIMARY KEY,
    maNguoi VARCHAR(10) NOT NULL UNIQUE
        FOREIGN KEY REFERENCES Nguoi(maNguoi),
    userName VARCHAR(100) UNIQUE NOT NULL,
    passWord VARCHAR(100) NOT NULL,
    hanTaiKhoan DATE NULL,
	vaiTro NVARCHAR(10) NOT NULL DEFAULT N'guest'
				CHECK (vaiTro IN (N'guest', N'staff', N'admin'))
);
GO
-- =============== Bảng Tựa sách =================
CREATE TABLE TuaSach (
    maTuaSach INT PRIMARY KEY IDENTITY(1,1),
    tenTuaSach NVARCHAR(200) NOT NULL UNIQUE,
    tacGia NVARCHAR(100),
    theLoai NVARCHAR(100),
    nhaXuatBan NVARCHAR(100),
    namXuatBan INT CHECK (namXuatBan > 1900 AND namXuatBan <= YEAR(GETDATE())),
    donGia DECIMAL(10,2) CHECK (donGia >= 0)
);
GO

-- =============== Bảng Cuốn sách =================
CREATE TABLE CuonSach (
    maCuonSach INT PRIMARY KEY IDENTITY(1,1),
    maTuaSach INT NOT NULL
        FOREIGN KEY REFERENCES TuaSach(maTuaSach),
    tinhTrang NVARCHAR(20) DEFAULT N'Có sẵn'
        CHECK (tinhTrang IN (N'Có sẵn', N'Đang mượn', N'Hỏng', N'Mất')),
    viTri NVARCHAR(50)
);
GO

-- =============== Bảng Phiếu mượn =================
CREATE TABLE PhieuMuon (
    soPhieu INT IDENTITY(1,1) PRIMARY KEY,   -- tự tăng
    maDocGia VARCHAR(14) NOT NULL FOREIGN KEY REFERENCES DocGia(maDocGia),
    maNhanVien VARCHAR(14) NOT NULL FOREIGN KEY REFERENCES NhanVien(maNhanVien),
    ngayMuon DATE NOT NULL DEFAULT GETDATE(),
    ngayHenTra DATE NOT NULL,
    trangThai NVARCHAR(20) DEFAULT N'Đang mượn'
        CHECK (trangThai IN (N'Đang mượn', N'Đã trả', N'Quá hạn', N'Đã hủy')),
    ngayTra DATE NULL
);
GO

CREATE TABLE CTPhieuMuon (
    soPhieu INT NOT NULL,
    maCuonSach INT NOT NULL,
    ghiChu NVARCHAR(200) NULL,
    trangThai NVARCHAR(20) NOT NULL DEFAULT N'Đang mượn'
        CHECK (trangThai IN (N'Đang mượn', N'Đã trả', N'Quá hạn', N'Đã hủy')),
    ngayTra DATE NULL,
    soNgayTre INT NULL,

    CONSTRAINT PK_CTPhieuMuon PRIMARY KEY (soPhieu, maCuonSach),
    CONSTRAINT FK_CTPhieuMuon_PhieuMuon FOREIGN KEY (soPhieu) REFERENCES PhieuMuon(soPhieu),
    CONSTRAINT FK_CTPhieuMuon_CuonSach FOREIGN KEY (maCuonSach) REFERENCES CuonSach(maCuonSach)
);
GO

--================ Trigger =================
CREATE TRIGGER trgCheckNgayHenTra
ON PhieuMuon
FOR INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra ngày hẹn trả >= ngày mượn
    IF EXISTS (
        SELECT 1
        FROM inserted i
        WHERE i.ngayHenTra < i.ngayMuon
    )
    BEGIN
        RAISERROR (N'Ngày hẹn trả phải lớn hơn hoặc bằng ngày mượn.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

CREATE TRIGGER trg_InsertNguoi
ON Nguoi
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Thêm vào bảng Độc giả nếu vaiTro = 'guest'
    INSERT INTO DocGia(maDocGia, maNguoi, ngayDangKy, hanTaiKhoan)
    SELECT 
        'DG' + i.maNguoi,   -- bạn có thể đổi cách sinh mã
        i.maNguoi,
        GETDATE(),
        DATEADD(MONTH, 3, GETDATE())  
    FROM inserted i
    WHERE i.vaiTro = N'guest';

    -- Thêm vào bảng Nhân viên nếu vaiTro = 'staff' hoặc 'admin'
    INSERT INTO NhanVien(maNhanVien, maNguoi, chucVu, ngayVaoLam, luong)
    SELECT 
        'NV' + i.maNguoi,   -- bạn có thể đổi cách sinh mã
        i.maNguoi,
        i.vaiTro,           -- mặc định để vai trò làm chức vụ
        GETDATE(),
        0                   -- lương mặc định = 0
    FROM inserted i
    WHERE i.vaiTro IN (N'staff', N'admin');
END;
GO



-- Khi thêm 1 bản ghi vào CTPhieuMuon (mượn sách) => sách chuyển sang "Đang mượn"
CREATE OR ALTER TRIGGER trg_CuonSach_DangMuon
ON CTPhieuMuon
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE cs
    SET cs.tinhTrang = N'Đang mượn'
    FROM CuonSach cs
    INNER JOIN inserted i ON cs.maCuonSach = i.maCuonSach;
END;
GO

-- Khi tất cả CTPhieuMuon của phiếu đã trả => cập nhật trạng thái phiếu là "Đã trả"
CREATE OR ALTER TRIGGER trg_PhieuMuon_UpdateTrangThai
ON CTPhieuMuon
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật trạng thái phiếu khi tất cả sách đã trả hoặc quá hạn
    UPDATE pm
    SET pm.trangThai = CASE 
                          WHEN EXISTS (
                              SELECT 1 
                              FROM CTPhieuMuon c 
                              WHERE c.soPhieu = pm.soPhieu 
                                AND c.trangThai = N'Quá hạn'
                          ) THEN N'Quá hạn'
                          ELSE N'Đã trả'
                       END,
        pm.ngayTra = GETDATE()
    FROM PhieuMuon pm
    WHERE pm.soPhieu IN (
        SELECT soPhieu
        FROM CTPhieuMuon
        GROUP BY soPhieu
        HAVING SUM(CASE WHEN trangThai IN (N'Đang mượn') THEN 1 ELSE 0 END) = 0
    );
END;
GO

-- Khi cập nhật CTPhieuMuon hoặc PhieuMuon, nếu quá hạn => chuyển trạng thái phiếu
CREATE OR ALTER TRIGGER trg_PhieuMuon_QuaHan
ON PhieuMuon
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE pm
    SET trangThai = N'Quá hạn'
    FROM PhieuMuon pm
    WHERE pm.trangThai = N'Đang mượn'
      AND pm.ngayHenTra < GETDATE();
END;
GO

--================ Stored Procedure ================
CREATE PROCEDURE sp_Login
    @Username NVARCHAR(50),
    @Password NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT tk.maTaiKhoan, tk.maNguoi, tk.userName, tk.passWord, tk.hanTaiKhoan,
           n.vaiTro, n.hoTen, n.gioiTinh, n.SDT, n.email, n.cccd, n.diaChi, n.ngaySinh
    FROM TaiKhoan tk
    JOIN Nguoi n ON tk.maNguoi = n.maNguoi
    WHERE tk.userName=@Username AND tk.passWord=@Password;
END;

CREATE OR ALTER PROCEDURE sp_TaoTaiKhoanDocGia
    @maNguoi VARCHAR(10),
    @userName VARCHAR(100),
    @passWord VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra người đã tồn tại tài khoản chưa
    IF EXISTS (SELECT 1 FROM TaiKhoan WHERE maNguoi = @maNguoi)
    BEGIN
        RAISERROR('Người này đã có tài khoản.', 16, 1);
        RETURN;
    END

    -- Kiểm tra username đã tồn tại chưa
    IF EXISTS (SELECT 1 FROM TaiKhoan WHERE userName = @userName)
    BEGIN
        RAISERROR('Username đã tồn tại.', 16, 1);
        RETURN;
    END

    -- Kiểm tra vai trò của người
    IF NOT EXISTS (SELECT 1 FROM Nguoi WHERE maNguoi = @maNguoi AND vaiTro = N'guest')
    BEGIN
        RAISERROR('Người này không phải là độc giả.', 16, 1);
        RETURN;
    END

    -- Thêm tài khoản mới với vai trò 'guest'
    INSERT INTO TaiKhoan (maNguoi, userName, passWord, vaiTro)
    VALUES (@maNguoi, @userName, @passWord, N'guest');

    PRINT 'Tạo tài khoản độc giả thành công!';
END
GO

CREATE TYPE SachMuon_Type AS TABLE (
    maCuonSach INT PRIMARY KEY
);
GO

CREATE OR ALTER PROCEDURE sp_MuonSach
    @maDocGia   VARCHAR(14),
    @maNhanVien VARCHAR(14),
    @ngayHenTra DATE,
    @dsSach     SachMuon_Type READONLY
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;

        DECLARE @ngayMuon DATE = GETDATE();

        -- Kiểm tra độc giả
        IF NOT EXISTS (SELECT 1 FROM DocGia WHERE maDocGia=@maDocGia)
        BEGIN
            RAISERROR(N'Mã độc giả không hợp lệ.',16,1);
            ROLLBACK TRAN; RETURN;
        END

        -- Kiểm tra nhân viên
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE maNhanVien=@maNhanVien)
        BEGIN
            RAISERROR(N'Mã nhân viên không hợp lệ.',16,1);
            ROLLBACK TRAN; RETURN;
        END

        -- Kiểm tra danh sách sách có rỗng không
        IF NOT EXISTS (SELECT 1 FROM @dsSach)
        BEGIN
            RAISERROR(N'Danh sách sách mượn không được rỗng.',16,1);
            ROLLBACK TRAN; RETURN;
        END

        -- Kiểm tra sách có tồn tại không
        IF EXISTS (
            SELECT 1
            FROM @dsSach s
            LEFT JOIN CuonSach c ON s.maCuonSach = c.maCuonSach
            WHERE c.maCuonSach IS NULL
        )
        BEGIN
            RAISERROR(N'Một hoặc nhiều cuốn trong danh sách không tồn tại.',16,1);
            ROLLBACK TRAN; RETURN;
        END

        -- Kiểm tra tình trạng sách: phải "Có sẵn"
        IF EXISTS (
            SELECT 1
            FROM @dsSach s
            JOIN CuonSach c ON s.maCuonSach = c.maCuonSach
            WHERE c.tinhTrang <> N'Có sẵn'
        )
        BEGIN
            RAISERROR(N'Một hoặc nhiều cuốn trong danh sách không còn ở trạng thái Có sẵn.',16,1);
            ROLLBACK TRAN; RETURN;
        END

        -- Thêm phiếu mượn (soPhieu tự tăng)
        INSERT INTO PhieuMuon(maDocGia, maNhanVien, ngayMuon, ngayHenTra, trangThai)
        VALUES(@maDocGia,@maNhanVien,@ngayMuon,@ngayHenTra,N'Đang mượn');

        DECLARE @soPhieu INT = SCOPE_IDENTITY();

        -- Thêm chi tiết phiếu
        INSERT INTO CTPhieuMuon(soPhieu, maCuonSach, trangThai)
        SELECT @soPhieu, s.maCuonSach, N'Đang mượn'
        FROM @dsSach s;

        COMMIT TRAN;

        -- Trả về số phiếu vừa thêm
        SELECT @soPhieu AS SoPhieuMoi;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrState INT = ERROR_STATE();
        RAISERROR(@ErrMsg, @ErrSeverity, @ErrState);
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE sp_TraTungSach
    @soPhieu    INT,
    @maCuonSach INT,
	@tinhTrangMoi NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;
		IF @tinhTrangMoi IS NULL
            SET @tinhTrangMoi = N'Có sẵn';

        DECLARE @ngayHenTra DATE, @soNgayTre INT;

        -- Lấy ngày hẹn trả
        SELECT @ngayHenTra = ngayHenTra 
        FROM PhieuMuon 
        WHERE soPhieu = @soPhieu;

        IF @ngayHenTra IS NULL
        BEGIN
            RAISERROR(N'Phiếu mượn không tồn tại.', 16, 1);
            ROLLBACK TRAN;
            RETURN;
        END

        -- Kiểm tra chi tiết tồn tại và đang mượn
        IF NOT EXISTS (
            SELECT 1 
            FROM CTPhieuMuon
            WHERE soPhieu=@soPhieu 
              AND maCuonSach=@maCuonSach
              AND trangThai=N'Đang mượn'
        )
        BEGIN
            RAISERROR(N'Chi tiết phiếu không tồn tại hoặc đã trả.', 16, 1);
            ROLLBACK TRAN;
            RETURN;
        END

        -- Tính số ngày trễ (nếu có)
        IF GETDATE() > @ngayHenTra
            SET @soNgayTre = DATEDIFF(DAY, @ngayHenTra, GETDATE());
        ELSE
            SET @soNgayTre = 0;

        -- Cập nhật chi tiết phiếu mượn
        UPDATE CTPhieuMuon
        SET trangThai = CASE WHEN @soNgayTre > 0 THEN N'Quá hạn' ELSE N'Đã trả' END,
            ngayTra   = GETDATE(),
            soNgayTre = @soNgayTre,
            ghiChu    = ISNULL(ghiChu, N'') + 
                        CASE WHEN @soNgayTre > 0 
                             THEN N' [Trả quá hạn ' + CAST(@soNgayTre AS NVARCHAR) + N' ngày]' 
                             ELSE N' [Đã trả]' END
        WHERE soPhieu=@soPhieu AND maCuonSach=@maCuonSach;

        -- Cập nhật tình trạng sách
        UPDATE CuonSach
        SET tinhTrang = @tinhTrangMoi
        WHERE maCuonSach = @maCuonSach;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
		DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
		DECLARE @ErrSeverity INT = ERROR_SEVERITY();
		DECLARE @ErrState INT = ERROR_STATE();

		ROLLBACK TRAN;
		RAISERROR(@ErrMsg, @ErrSeverity, @ErrState);
	END CATCH;
END;
GO


CREATE OR ALTER PROCEDURE sp_HuyPhieuMuon
    @soPhieu INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Result BIT = 0;

    BEGIN TRY
        BEGIN TRAN;

        -- Kiểm tra phiếu tồn tại và đang mượn
        IF NOT EXISTS (
            SELECT 1 
            FROM PhieuMuon 
            WHERE soPhieu = @soPhieu AND trangThai = N'Đang mượn'
        )
        BEGIN
            SET @Result = 0;
            ROLLBACK TRAN;
            SELECT @Result AS Result; -- Trả kết quả cho DAL
            RETURN;
        END

        -- Cập nhật tình trạng sách về "Có sẵn"
        UPDATE c
        SET c.tinhTrang = N'Có sẵn'
        FROM CuonSach c
        JOIN CTPhieuMuon ct ON c.maCuonSach = ct.maCuonSach
        WHERE ct.soPhieu = @soPhieu AND ct.trangThai = N'Đang mượn';

        -- Cập nhật chi tiết phiếu: đánh dấu đã hủy
        UPDATE CTPhieuMuon
        SET trangThai = N'Đã hủy',
            ngayTra = GETDATE(),
            ghiChu = ISNULL(ghiChu, N'') + N' [Đã hủy]'
        WHERE soPhieu = @soPhieu AND trangThai = N'Đang mượn';

        -- Cập nhật phiếu mượn
        UPDATE PhieuMuon
        SET trangThai = N'Đã hủy',
            ngayTra = GETDATE()
        WHERE soPhieu = @soPhieu;

        COMMIT TRAN;
        SET @Result = 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        SET @Result = 0;
    END CATCH

    SELECT @Result AS Result; -- luôn trả kết quả
END;
GO


CREATE OR ALTER PROCEDURE sp_ChinhSuaPhieuMuon
    @soPhieu     INT,
    @maNhanVien  VARCHAR(14),
    @ngayHenTra  DATE
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON; -- nếu có lỗi thì rollback tự động

    BEGIN TRY
        BEGIN TRAN;

        -- Kiểm tra phiếu tồn tại
        IF NOT EXISTS (SELECT 1 FROM PhieuMuon WHERE soPhieu=@soPhieu)
            THROW 50001, N'Phiếu mượn không tồn tại.', 1;

        -- Kiểm tra nhân viên
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE maNhanVien=@maNhanVien)
            THROW 50002, N'Mã nhân viên không hợp lệ.', 1;

        -- Lấy ngày mượn để so sánh
        DECLARE @ngayMuon DATE;
        SELECT @ngayMuon = ngayMuon 
        FROM PhieuMuon 
        WHERE soPhieu=@soPhieu;

        IF @ngayHenTra < @ngayMuon
            THROW 50003, N'Ngày hẹn trả phải ≥ ngày mượn.', 1;

        -- Cập nhật phiếu
        UPDATE PhieuMuon
        SET maNhanVien   = @maNhanVien,
            ngayHenTra   = @ngayHenTra
        WHERE soPhieu = @soPhieu;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRAN;

        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE(),
                @ErrNum INT = ERROR_NUMBER();
        THROW @ErrNum, @ErrMsg, 1;  -- ném lại lỗi cho tầng ứng dụng bắt
    END CATCH
END;
GO


CREATE OR ALTER PROCEDURE sp_ChinhSuaCTPhieuMuon
    @soPhieu       INT,
    @maCuonSachCu  INT,
    @maCuonSachMoi INT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRY
        BEGIN TRAN;

        IF @maCuonSachMoi = @maCuonSachCu
            THROW 50000, N'Cuốn mới phải khác cuốn cũ.', 1;

        IF NOT EXISTS (
            SELECT 1 FROM CTPhieuMuon
            WHERE soPhieu=@soPhieu AND maCuonSach=@maCuonSachCu AND trangThai=N'Đang mượn'
        )
            THROW 50000, N'Chi tiết phiếu không tồn tại hoặc đã trả.', 1;

        IF EXISTS (
            SELECT 1 FROM CTPhieuMuon
            WHERE soPhieu=@soPhieu AND maCuonSach=@maCuonSachMoi
        )
            THROW 50000, N'Cuốn sách mới đã có trong phiếu này.', 1;

        IF NOT EXISTS (
            SELECT 1 FROM CuonSach
            WHERE maCuonSach=@maCuonSachMoi AND tinhTrang=N'Có sẵn'
        )
            THROW 50000, N'Cuốn sách mới không có sẵn.', 1;

        -- Đổi cuốn
        UPDATE CuonSach SET tinhTrang=N'Có sẵn' WHERE maCuonSach=@maCuonSachCu;

        UPDATE CTPhieuMuon
        SET maCuonSach=@maCuonSachMoi
        WHERE soPhieu=@soPhieu AND maCuonSach=@maCuonSachCu;

        UPDATE CuonSach SET tinhTrang=N'Đang mượn' WHERE maCuonSach=@maCuonSachMoi;

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW; -- cho C# nhận đúng thông điệp gốc
    END CATCH
END
GO


CREATE OR ALTER PROCEDURE sp_XoaCTPhieuMuon
    @soPhieu    INT,
    @maCuonSach INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRAN;

        -- Kiểm tra tồn tại chi tiết
        IF NOT EXISTS (
            SELECT 1 
            FROM CTPhieuMuon
            WHERE soPhieu=@soPhieu 
              AND maCuonSach=@maCuonSach 
              AND trangThai=N'Đang mượn'
        )
            THROW 50010, N'Chi tiết phiếu không tồn tại hoặc đã trả.', 1;

        -- Cập nhật sách về "Có sẵn"
        UPDATE CuonSach
        SET tinhTrang=N'Có sẵn'
        WHERE maCuonSach=@maCuonSach;

        -- Xóa chi tiết
        DELETE FROM CTPhieuMuon
        WHERE soPhieu=@soPhieu AND maCuonSach=@maCuonSach;

        -- Nếu phiếu không còn chi tiết nào thì hủy phiếu
        IF NOT EXISTS (
            SELECT 1 
            FROM CTPhieuMuon 
            WHERE soPhieu=@soPhieu AND trangThai=N'Đang mượn'
        )
        BEGIN
            UPDATE PhieuMuon
            SET trangThai=N'Đã hủy',
                ngayTra=GETDATE()
            WHERE soPhieu=@soPhieu;
        END

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW; -- ném lại lỗi thật ra ngoài
    END CATCH
END;
GO


CREATE OR ALTER PROCEDURE sp_ThemCTPhieuMuon
    @soPhieu    INT,
    @maCuonSach INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRAN;

        -- Kiểm tra phiếu hợp lệ
        IF NOT EXISTS (
            SELECT 1 
            FROM PhieuMuon 
            WHERE soPhieu=@soPhieu AND trangThai=N'Đang mượn'
        )
            THROW 50000, N'Phiếu mượn không tồn tại hoặc không còn hiệu lực.', 1;

        -- Kiểm tra sách còn có sẵn
        IF NOT EXISTS (
            SELECT 1 
            FROM CuonSach 
            WHERE maCuonSach=@maCuonSach AND tinhTrang=N'Có sẵn'
        )
            THROW 50001, N'Cuốn sách không tồn tại hoặc không còn có sẵn.', 1;

        -- Kiểm tra chi tiết đã tồn tại chưa
        IF EXISTS (
            SELECT 1 
            FROM CTPhieuMuon 
            WHERE soPhieu=@soPhieu AND maCuonSach=@maCuonSach
        )
            THROW 50002, N'Chi tiết phiếu mượn này đã tồn tại.', 1;

        -- Thêm chi tiết phiếu
        INSERT INTO CTPhieuMuon(soPhieu, maCuonSach, trangThai)
        VALUES(@soPhieu, @maCuonSach, N'Đang mượn');

        -- Cập nhật tình trạng sách
        UPDATE CuonSach
        SET tinhTrang=N'Đang mượn'
        WHERE maCuonSach=@maCuonSach;

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW; -- ném lại lỗi gốc ra ngoài để C# bắt được
    END CATCH
END;
GO


CREATE OR ALTER PROCEDURE sp_DanhSachPhieuQuaHan
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN;

        UPDATE PhieuMuon
        SET trangThai = N'Quá hạn'
        WHERE trangThai = N'Đang mượn'
          AND ngayHenTra < GETDATE();
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE sp_XemCuonSach_Filter
    @tacGia NVARCHAR(100) = NULL,
    @theLoai NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM v_CuonSach_ChiTiet
    WHERE (@tacGia IS NULL OR tacGia = @tacGia)
      AND (@theLoai IS NULL OR theLoai = @theLoai)
    ORDER BY tenTuaSach ASC;
END;
GO

-- Thủ tục gọi view v_PhieuMuon
CREATE OR ALTER PROCEDURE sp_XemPhieuMuon
AS
BEGIN
    SELECT * FROM v_PhieuMuon;
END;
GO

-- Thủ tục gọi view v_TaiKhoanNguoi
CREATE OR ALTER PROCEDURE sp_XemTaiKhoanNguoi
AS
BEGIN
    SELECT * FROM v_TaiKhoanNguoi;
END;
GO

-- Thủ tục gọi view v_DocGiaThongTin
CREATE OR ALTER PROCEDURE sp_XemDocGiaThongTin
AS
BEGIN
    SELECT * FROM v_DocGiaThongTin;
END;
GO

-- Thủ tục gọi view v_CTPhieuMuon
CREATE OR ALTER PROCEDURE sp_XemCTPhieuMuon
AS
BEGIN
    SELECT * FROM v_CTPhieuMuon;
END;
GO

CREATE OR ALTER PROCEDURE sp_DsTaiKhoan
AS
BEGIN
    SELECT * FROM v_TaiKhoanNguoi;
END;
GO

CREATE OR ALTER PROCEDURE sp_XemDanhSach_CuonSach_ChiTiet
AS
BEGIN
    SELECT * FROM v_CuonSach_ChiTiet;
END;
GO

CREATE OR ALTER PROCEDURE sp_XemDanhSach_CuonSach_ChiTiet_SapXep
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM v_CuonSach_ChiTiet
    ORDER BY tenTuaSach ASC;
END;
GO


--============= Functions ===============
-- Số phiếu đang mượn
CREATE FUNCTION fn_ThongKe_Phieu_DangMuon(@tuNgay DATE, @denNgay DATE)
RETURNS INT
AS
BEGIN
    RETURN (
        SELECT COUNT(*) 
        FROM PhieuMuon
        WHERE trangThai = N'Đang mượn'
          AND ngayMuon BETWEEN @tuNgay AND @denNgay
    )
END
GO

-- Số phiếu đã trả
CREATE FUNCTION fn_ThongKe_Phieu_DaTra(@tuNgay DATE, @denNgay DATE)
RETURNS INT
AS
BEGIN
    RETURN (
        SELECT COUNT(*)
        FROM PhieuMuon
        WHERE trangThai = N'Đã trả'
          AND ngayMuon BETWEEN @tuNgay AND @denNgay
    )
END
GO

-- Số phiếu trễ hạn
CREATE FUNCTION fn_ThongKe_Phieu_TreHan(@tuNgay DATE, @denNgay DATE)
RETURNS INT
AS
BEGIN
    RETURN (
        SELECT COUNT(*)
        FROM PhieuMuon
        WHERE trangThai = N'Quá hạn'
          AND ngayMuon BETWEEN @tuNgay AND @denNgay
    )
END
GO

-- Tổng số phiếu (không tính đã hủy)
CREATE FUNCTION fn_ThongKe_Phieu_Tong(@tuNgay DATE, @denNgay DATE)
RETURNS INT
AS
BEGIN
    RETURN (
        SELECT COUNT(*)
        FROM PhieuMuon
        WHERE trangThai <> N'Đã hủy'
          AND ngayMuon BETWEEN @tuNgay AND @denNgay
    )
END
GO

-- Số sách đang mượn
CREATE FUNCTION fn_ThongKe_Sach_DangMuon(@tuNgay DATE, @denNgay DATE)
RETURNS INT
AS
BEGIN
    RETURN (
        SELECT COUNT(*)
        FROM CuonSach cs
        JOIN CTPhieuMuon ct ON cs.maCuonSach = ct.maCuonSach
        JOIN PhieuMuon pm ON ct.soPhieu = pm.soPhieu
        WHERE ct.trangThai = N'Đang mượn'
          AND pm.ngayMuon BETWEEN @tuNgay AND @denNgay
    )
END
GO

-- Số sách bị hỏng
CREATE FUNCTION fn_ThongKe_Sach_Hong(@tuNgay DATE, @denNgay DATE)
RETURNS INT
AS
BEGIN
    RETURN (
        SELECT COUNT(*)
        FROM CuonSach
        WHERE tinhTrang = N'Hỏng'
          AND maCuonSach IN (
              SELECT maCuonSach FROM CTPhieuMuon 
              WHERE ngayTra BETWEEN @tuNgay AND @denNgay
          )
    )
END
GO

-- Số sách bị mất
CREATE FUNCTION fn_ThongKe_Sach_Mat(@tuNgay DATE, @denNgay DATE)
RETURNS INT
AS
BEGIN
    RETURN (
        SELECT COUNT(*)
        FROM CuonSach
        WHERE tinhTrang = N'Mất'
          AND maCuonSach IN (
              SELECT maCuonSach FROM CTPhieuMuon 
              WHERE ngayTra BETWEEN @tuNgay AND @denNgay
          )
    )
END
GO

-- Tổng số sách
CREATE FUNCTION fn_ThongKe_Sach_Tong()
RETURNS INT
AS
BEGIN
    RETURN (SELECT COUNT(*) FROM CuonSach)
END
GO

CREATE FUNCTION fn_ThongKe_DocGia_DangMuon(@tuNgay DATE, @denNgay DATE)
RETURNS INT
AS
BEGIN
    RETURN (
        SELECT COUNT(DISTINCT pm.maDocGia)
        FROM PhieuMuon pm
        JOIN CTPhieuMuon ct ON pm.soPhieu = ct.soPhieu
        WHERE ct.trangThai = N'Đang mượn'
          AND pm.ngayMuon BETWEEN @tuNgay AND @denNgay
    )
END
GO

-- Số độc giả vi phạm (hỏng, mất, trễ hạn)
CREATE FUNCTION fn_ThongKe_DocGia_ViPham(@tuNgay DATE, @denNgay DATE)
RETURNS INT
AS
BEGIN
    RETURN (
        SELECT COUNT(DISTINCT pm.maDocGia)
        FROM PhieuMuon pm
        JOIN CTPhieuMuon ct ON pm.soPhieu = ct.soPhieu
        WHERE ct.trangThai IN (N'Quá hạn')
           OR ct.maCuonSach IN (
               SELECT maCuonSach
               FROM CuonSach
               WHERE tinhTrang IN (N'Hỏng', N'Mất')
           )
          AND pm.ngayMuon BETWEEN @tuNgay AND @denNgay
    )
END
GO

-- Tổng số độc giả
CREATE FUNCTION fn_ThongKe_DocGia_Tong()
RETURNS INT
AS
BEGIN
    RETURN (SELECT COUNT(*) FROM DocGia)
END
GO

CREATE OR ALTER FUNCTION fn_DanhSachPhieuQuaHanTheoKhoangNgay
(
    @TuNgay DATE,
    @DenNgay DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        pm.soPhieu, 
        dg.maDocGia, 
        n.hoTen, 
        pm.ngayMuon, 
        pm.ngayHenTra,
        DATEDIFF(DAY, pm.ngayHenTra, GETDATE()) AS soNgayTre
    FROM PhieuMuon pm
    JOIN DocGia dg ON pm.maDocGia = dg.maDocGia
    JOIN Nguoi n ON dg.maNguoi = n.maNguoi
    WHERE pm.trangThai = N'Quá hạn'
      AND pm.ngayHenTra BETWEEN @TuNgay AND @DenNgay
);
GO

CREATE OR ALTER FUNCTION fn_SachDangMuon(@maDocGia VARCHAR(14))
RETURNS TABLE
AS
RETURN
(
    SELECT 
        pm.soPhieu, 
        ct.maCuonSach, 
        ts.tenTuaSach, 
        ct.trangThai, 
        pm.ngayMuon, 
        pm.ngayHenTra
    FROM CTPhieuMuon ct
    JOIN PhieuMuon pm ON ct.soPhieu = pm.soPhieu
    JOIN CuonSach cs ON ct.maCuonSach = cs.maCuonSach
    JOIN TuaSach ts ON cs.maTuaSach = ts.maTuaSach
    WHERE pm.maDocGia = @maDocGia 
      AND ct.trangThai = N'Đang mượn'
);
GO

CREATE OR ALTER FUNCTION fn_SachTheoTinhTrang
(
    @tinhTrang NVARCHAR(20)   -- 'Có sẵn' hoặc 'Đang mượn'
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        cs.maCuonSach,
        ts.tenTuaSach,
        ts.tacGia
    FROM CuonSach cs
    JOIN TuaSach ts ON cs.maTuaSach = ts.maTuaSach
    WHERE cs.tinhTrang = @tinhTrang
);
GO

CREATE OR ALTER FUNCTION fn_SachTheoTinhTrang_TimKiem
(
    @tinhTrang NVARCHAR(20),        -- 'Có sẵn' hoặc 'Đang mượn'
    @keyword   NVARCHAR(100) = N''  -- từ khóa tìm kiếm, có thể rỗng
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        cs.maCuonSach,
        ts.tenTuaSach,
        ts.tacGia
    FROM CuonSach cs
    JOIN TuaSach ts ON cs.maTuaSach = ts.maTuaSach
    WHERE cs.tinhTrang = @tinhTrang
      AND (
             @keyword = N'' 
             OR ts.tenTuaSach LIKE N'%' + @keyword + N'%'
             OR ts.tacGia    LIKE N'%' + @keyword + N'%'
          )
);
GO

CREATE OR ALTER FUNCTION fn_TimKiemPhieuMuon
(
    @keyword NVARCHAR(100)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM v_PhieuMuon
    WHERE 
        CAST(soPhieu AS NVARCHAR(50)) LIKE N'%' + @keyword + N'%'
        OR maDocGia LIKE N'%' + @keyword + N'%'
        OR hoTen LIKE N'%' + @keyword + N'%'
        OR SDT LIKE N'%' + @keyword + N'%'
        OR CONVERT(NVARCHAR(10), ngayMuon, 103) LIKE N'%' + @keyword + N'%'
        OR CONVERT(NVARCHAR(10), ngayHenTra, 103) LIKE N'%' + @keyword + N'%'
        OR CONVERT(NVARCHAR(10), ngayTra, 103) LIKE N'%' + @keyword + N'%'
        OR trangThai LIKE N'%' + @keyword + N'%'
);
GO

CREATE OR ALTER FUNCTION fn_GetMaNhanVien (@maNguoi VARCHAR(10))
RETURNS VARCHAR(14)
AS
BEGIN
    DECLARE @maNhanVien VARCHAR(14);

    SELECT @maNhanVien = maNhanVien
    FROM NhanVien
    WHERE maNguoi = @maNguoi;

    RETURN @maNhanVien;
END;
GO

CREATE OR ALTER FUNCTION fn_TimKiemDocGia
(
    @keyword NVARCHAR(100) = N''   -- từ khóa tìm kiếm, có thể để trống
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        dg.maDocGia,
        n.hoTen,
        n.ngaySinh
    FROM DocGia dg
    JOIN Nguoi n ON dg.maNguoi = n.maNguoi
    WHERE 
        @keyword = N'' 
        OR dg.maDocGia LIKE N'%' + @keyword + N'%'
        OR n.hoTen LIKE N'%' + @keyword + N'%'
        OR CONVERT(NVARCHAR(10), n.ngaySinh, 23) LIKE N'%' + @keyword + N'%'
);
GO

CREATE OR ALTER FUNCTION fn_TimKiemCuonSach_ChiTiet
(
    @keyword NVARCHAR(200) = N''
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM v_CuonSach_ChiTiet
    WHERE @keyword IS NULL 
       OR tenTuaSach LIKE '%' + @keyword + '%'
       OR tacGia LIKE '%' + @keyword + '%'
       OR theLoai LIKE '%' + @keyword + '%'
       OR nhaXuatBan LIKE '%' + @keyword + '%'
	   OR maCuonSach LIKE '%' + @keyword + '%'
);
GO

CREATE OR ALTER FUNCTION fn_TimKiemTaiKhoan
(
    @keyword NVARCHAR(100)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM v_TaiKhoan
    WHERE maNguoi LIKE '%' + @keyword + '%'
       OR hoTen LIKE '%' + @keyword + '%'
       OR userName LIKE '%' + @keyword + '%'
       OR SDT LIKE '%' + @keyword + '%'
);
GO

CREATE OR ALTER FUNCTION fn_LayDanhSachTheLoai()
RETURNS TABLE
AS
RETURN
(
    SELECT DISTINCT theLoai
    FROM TuaSach
);
GO

CREATE OR ALTER FUNCTION fn_LayDanhSachTacGia()
RETURNS TABLE
AS
RETURN
(
    SELECT DISTINCT tacGia
    FROM TuaSach
);
GO


--=============== Views ================
CREATE OR ALTER VIEW v_PhieuMuon
AS
SELECT 
    pm.soPhieu,
    pm.maDocGia,
    n.hoTen,
    n.SDT,
    pm.ngayMuon,
    pm.ngayHenTra,
    pm.ngayTra,
    pm.trangThai
FROM PhieuMuon pm
JOIN DocGia dg ON pm.maDocGia = dg.maDocGia
JOIN Nguoi n ON dg.maNguoi = n.maNguoi;
GO

CREATE OR ALTER VIEW v_TaiKhoan
AS
SELECT 
    n.maNguoi,
    n.hoTen,
    tk.userName,
    n.SDT,
    n.email,
    n.vaiTro,
    tk.hanTaiKhoan
FROM TaiKhoan tk
JOIN Nguoi n ON tk.maNguoi = n.maNguoi;
GO

CREATE OR ALTER VIEW v_DocGiaThongTin
AS
SELECT 
    dg.maDocGia,
    n.hoTen,
    n.ngaySinh
FROM DocGia dg
JOIN Nguoi n ON dg.maNguoi = n.maNguoi;
GO

CREATE OR ALTER VIEW v_CTPhieuMuon
AS
SELECT 
    ct.soPhieu,
    ct.maCuonSach,
    s.tenTuaSach,
    s.tacGia,
    ct.trangThai
FROM CTPhieuMuon ct
JOIN CuonSach cs ON ct.maCuonSach = cs.maCuonSach
JOIN TuaSach s ON cs.maTuaSach = s.maTuaSach;
GO

CREATE OR ALTER VIEW v_CuonSach_ChiTiet
AS
SELECT 
    cs.maCuonSach,
    ts.tenTuaSach,
    ts.tacGia,
    ts.theLoai,
    ts.nhaXuatBan,
    cs.viTri,
    cs.tinhTrang
FROM CuonSach cs
JOIN TuaSach ts ON cs.maTuaSach = ts.maTuaSach;
GO


--Data--
INSERT INTO TuaSach (tenTuaSach, tacGia, theLoai, nhaXuatBan, namXuatBan, donGia)
VALUES 
(N'Lập Trình C++ Cơ Bản', N'Nguyễn Văn A', N'Lập trình', N'NXB Giáo Dục', 2020, 95000),
(N'Java Programming', N'James Gosling', N'Lập trình', N'Pearson', 2019, 120000),
(N'Cơ Sở Dữ Liệu SQL Server', N'Trần Văn B', N'CSDL', N'NXB Khoa Học', 2021, 110000),
(N'Trí Tuệ Nhân Tạo – AI', N'Andrew Ng', N'AI', N'OReilly', 2022, 150000),
(N'Thuật Toán Và Ứng Dụng', N'CLRS', N'Toán-Tin', N'MIT Press', 2018, 200000);

-- ===== Mỗi tựa sách thêm 2 cuốn =====
INSERT INTO CuonSach (maTuaSach, tinhTrang, viTri)
SELECT maTuaSach, N'Có sẵn', N'Kệ A1'
FROM TuaSach;

INSERT INTO CuonSach (maTuaSach, tinhTrang, viTri)
SELECT maTuaSach, N'Có sẵn', N'Kệ A2'
FROM TuaSach;

-- ===== Thêm người =====
INSERT INTO Nguoi (maNguoi, hoTen, gioiTinh, ngaySinh, diaChi, SDT, email, cccd, vaiTro)
VALUES
('001', N'Vũ Quốc Trung', N'Nam', '1990-05-20', N'Hà Nội', '0912345678', 'trung@gmail.com', '012345678901', 'admin'),
('002', N'Nguyễn Lâm Tấn', N'Nam', '1992-08-15', N'Hồ Chí Minh', '0987654321', 'tan@gmail.com', '123456789012', 'staff'),
('003', N'Nguyễn Kim Điền', N'Nam', '2000-03-10', N'Đà Nẵng', '0909123123', 'dien@gmail.com', '234567890123', 'guest'),
('004', N'Phạm Quốc Việt', N'Nam', '2001-11-25', N'Cần Thơ', '0977554433', 'viet@gmail.com', '345678901234', 'guest');


-- Bước 1: Khai báo biến table type
DECLARE @dsSach SachMuon_Type;

-- Bước 2: Chèn danh sách sách muốn mượn
INSERT INTO @dsSach(maCuonSach)
VALUES (1), (2);   -- giả sử muốn mượn 2 quyển có mã 1 và 2

-- Bước 3: Gọi thủ tục mượn sách
EXEC sp_MuonSach
    @maDocGia   = 'DG003',   -- mã độc giả
    @maNhanVien = 'NV002',   -- mã nhân viên
     @ngayHenTra = '2025-09-25', -- hẹn trả sau 7 ngày
    @dsSach     = @dsSach;

SELECT * FROM PhieuMuon;
SELECT * FROM CuonSach;
SELECT * FROM NhanVien;
SELECT * FROM DocGia;

INSERT INTO TaiKhoan (maTaiKhoan, maNguoi, userName, passWord, hanTaiKhoan)
VALUES ('001', '001', 'jun', '123', NULL);
