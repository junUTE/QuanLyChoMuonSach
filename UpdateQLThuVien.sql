CREATE DATABASE QLThuVien;
GO
USE QLThuVien;
GO

-- =============== Bảng Người (cha) =================
CREATE TABLE Nguoi (
    maNguoi INT IDENTITY(1,1) PRIMARY KEY,  -- Tự tăng từ 1
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
    maNguoi INT UNIQUE NOT NULL
        FOREIGN KEY REFERENCES Nguoi(maNguoi),
    ngayDangKy DATE DEFAULT GETDATE(),
    hanTaiKhoan DATE
);
GO

-- =============== Bảng Nhân viên (con) =================
CREATE TABLE NhanVien (
    maNhanVien VARCHAR(14) PRIMARY KEY,
    maNguoi INT UNIQUE NOT NULL
        FOREIGN KEY REFERENCES Nguoi(maNguoi),
    chucVu NVARCHAR(50) NULL,
    ngayVaoLam DATE DEFAULT GETDATE(),
    luong DECIMAL(12,2)
);
GO

-- =============== Bảng Tài khoản (nếu cần login) =================

CREATE TABLE TaiKhoan (
    maTaiKhoan INT PRIMARY KEY IDENTITY(1,1),
    maNguoi INT NOT NULL UNIQUE
        FOREIGN KEY REFERENCES Nguoi(maNguoi),
    userName VARCHAR(100) UNIQUE NOT NULL,
    passWord VARCHAR(100) NOT NULL,
    hanTaiKhoan DATE NULL,
    vaiTro NVARCHAR(10) NOT NULL DEFAULT N'guest'
        CHECK (vaiTro IN (N'guest', N'staff', N'admin'))
);

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
    soPhieu INT IDENTITY(1,1) PRIMARY KEY,  
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

CREATE OR ALTER TRIGGER trg_InsertNguoi
ON Nguoi
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Thêm vào bảng Độc giả nếu vaiTro = 'guest'
    INSERT INTO DocGia(maDocGia, maNguoi, ngayDangKy, hanTaiKhoan)
    SELECT 
        'DG' + CAST(i.maNguoi AS VARCHAR(10)),   -- ép INT sang chuỗi
        i.maNguoi,
        GETDATE(),
        DATEADD(MONTH, 3, GETDATE())  
    FROM inserted i
    WHERE i.vaiTro = N'guest';

    -- Thêm vào bảng Nhân viên nếu vaiTro = 'staff' hoặc 'admin'
    INSERT INTO NhanVien(maNhanVien, maNguoi, chucVu, ngayVaoLam, luong)
    SELECT 
        'NV' + CAST(i.maNguoi AS VARCHAR(10)),   -- ép INT sang chuỗi
        i.maNguoi,
        i.vaiTro,           
        GETDATE(),
        0                   
    FROM inserted i
    WHERE i.vaiTro IN (N'staff', N'admin');
END;
GO
-- Set hạn cho tài khoản đọc giả
CREATE OR ALTER TRIGGER trg_SetHanTaiKhoan
ON TaiKhoan
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật hạn tài khoản cho các bản ghi mới thêm, chỉ áp dụng cho guest
    UPDATE t
    SET hanTaiKhoan = DATEADD(MONTH, 3, GETDATE())
    FROM TaiKhoan t
    INNER JOIN inserted i ON t.maTaiKhoan = i.maTaiKhoan
    WHERE i.vaiTro = N'guest';
END
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
-- Trigger thêm mới: khi INSERT vào TaiKhoan

CREATE OR ALTER TRIGGER TRG_TaiKhoan_Insert_AI
ON TaiKhoan
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Username NVARCHAR(100), 
            @Password NVARCHAR(100),
            @Role NVARCHAR(10),
            @sql NVARCHAR(MAX);

    SELECT TOP 1 
           @Username = userName,
           @Password = passWord,
           @Role = vaiTro
    FROM inserted;

    -- Tạo LOGIN (nếu chưa có), nếu có thì đổi mật khẩu
    IF SUSER_ID(@Username) IS NULL
        SET @sql = N'CREATE LOGIN ' + QUOTENAME(@Username) +
                   N' WITH PASSWORD = ''' + REPLACE(@Password,'''','''''') + 
                   N''', CHECK_POLICY=OFF, CHECK_EXPIRATION=OFF;';
    ELSE
        SET @sql = N'ALTER LOGIN ' + QUOTENAME(@Username) +
                   N' WITH PASSWORD = ''' + REPLACE(@Password,'''','''''') +
                   N''', CHECK_POLICY=OFF;';
    EXEC(@sql);

    -- Tạo USER trong DB nếu chưa có
    IF USER_ID(@Username) IS NULL
    BEGIN
        SET @sql = N'CREATE USER ' + QUOTENAME(@Username) +
                   N' FOR LOGIN ' + QUOTENAME(@Username) + N';';
        EXEC(@sql);
    END

    -- Gán vào ROLE theo vaiTro
    IF @Role = N'guest'
        SET @sql = N'ALTER ROLE GuestRole ADD MEMBER ' + QUOTENAME(@Username) + ';';
    ELSE IF @Role = N'staff'
        SET @sql = N'ALTER ROLE StaffRole ADD MEMBER ' + QUOTENAME(@Username) + ';';
    ELSE IF @Role = N'admin'
        SET @sql = N'ALTER ROLE AdminRole ADD MEMBER ' + QUOTENAME(@Username) + ';';
    ELSE
        SET @sql = NULL;

    IF @sql IS NOT NULL EXEC(@sql);
END
GO


-- Trigger xóa: khi DELETE khỏi TaiKhoan
CREATE OR ALTER TRIGGER TRG_TaiKhoan_Delete_AD
ON TaiKhoan
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Username NVARCHAR(100),
            @sql NVARCHAR(MAX);

    SELECT TOP 1 @Username = userName
    FROM deleted;

    -- Gỡ khỏi role
    SET @sql = N'IF IS_ROLEMEMBER(''r_guest'',''' + @Username + N''')=1 
                ALTER ROLE GuestRole DROP MEMBER ' + QUOTENAME(@Username) + N';';
    EXEC(@sql);

    SET @sql = N'IF IS_ROLEMEMBER(''r_staff'',''' + @Username + N''')=1 
                ALTER ROLE StaffRole DROP MEMBER ' + QUOTENAME(@Username) + N';';
    EXEC(@sql);

    SET @sql = N'IF IS_ROLEMEMBER(''r_admin'',''' + @Username + N''')=1 
                ALTER ROLE AdminRole DROP MEMBER ' + QUOTENAME(@Username) + N';';
    EXEC(@sql);

    -- Drop USER
    IF USER_ID(@Username) IS NOT NULL
    BEGIN
        SET @sql = N'DROP USER ' + QUOTENAME(@Username) + N';';
        EXEC(@sql);
    END

    -- Drop LOGIN
    IF SUSER_ID(@Username) IS NOT NULL
    BEGIN
        SET @sql = N'DROP LOGIN ' + QUOTENAME(@Username) + N';';
        EXEC(@sql);
    END
END
GO


-- Trigger update: khi đổi userName hoặc passWord
CREATE OR ALTER TRIGGER TRG_TaiKhoan_Update_AU
ON TaiKhoan
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @OldUser NVARCHAR(100), @NewUser NVARCHAR(100), @NewPw NVARCHAR(100),
            @sql NVARCHAR(MAX);

    SELECT TOP 1
        @OldUser = d.userName,
        @NewUser = i.userName,
        @NewPw   = i.passWord
    FROM inserted i
    JOIN deleted d ON i.maTaiKhoan = d.maTaiKhoan;

    -- Nếu đổi username
    IF UPDATE(userName) AND @OldUser <> @NewUser
    BEGIN
        SET @sql = N'ALTER LOGIN ' + QUOTENAME(@OldUser) +
                   N' WITH NAME = ' + QUOTENAME(@NewUser) + N';';
        EXEC(@sql);

        IF USER_ID(@OldUser) IS NOT NULL
        BEGIN
            SET @sql = N'ALTER USER ' + QUOTENAME(@OldUser) +
                       N' WITH NAME = ' + QUOTENAME(@NewUser) + N';';
            EXEC(@sql);
        END
    END

    -- Nếu đổi password
    IF UPDATE(passWord)
    BEGIN
        DECLARE @Target NVARCHAR(100) = 
            CASE WHEN UPDATE(userName) AND @OldUser <> @NewUser
                 THEN @NewUser ELSE @OldUser END;

        SET @sql = N'ALTER LOGIN ' + QUOTENAME(@Target) +
                   N' WITH PASSWORD = ''' + REPLACE(@NewPw,'''','''''') + 
                   N''', CHECK_POLICY=OFF;';
        EXEC(@sql);
    END
END
GO

--================ Stored Procedure ================
CREATE OR ALTER PROCEDURE sp_ThemDocGia
    @hoTen NVARCHAR(100),
    @gioiTinh NVARCHAR(10),
    @ngaySinh DATE,
    @diaChi NVARCHAR(MAX),
    @SDT VARCHAR(11),
    @Email NVARCHAR(100),
    @CCCD NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        INSERT INTO Nguoi (hoTen, gioiTinh, ngaySinh, diaChi, SDT, email, cccd, vaiTro)
        VALUES (@hoTen, @gioiTinh, @ngaySinh, @diaChi, @SDT, @Email, @CCCD, N'guest');

        PRINT N'Thêm độc giả thành công!';
    END TRY
    BEGIN CATCH
        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrMsg, 16, 1);
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE sp_Login
    @Username NVARCHAR(50),
    @Password NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT tk.maTaiKhoan, tk.maNguoi, tk.userName, tk.passWord, tk.hanTaiKhoan,
           n.vaiTro, n.hoTen, n.gioiTinh, n.SDT, n.email, n.cccd, n.diaChi, n.ngaySinh
    FROM TaiKhoan tk
    JOIN Nguoi n ON tk.maNguoi = n.maNguoi
    WHERE tk.userName = @Username 
      AND tk.passWord = @Password
      AND (tk.hanTaiKhoan IS NULL OR tk.hanTaiKhoan >= GETDATE());
END;
GO

-- Tạo tài khoản đọc giả
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

--Xóa tài khoản
CREATE OR ALTER PROCEDURE sp_XoaTaiKhoan
    @userName VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra username có tồn tại không
    IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE userName = @userName)
    BEGIN
        RAISERROR(N'Tài khoản không tồn tại.', 16, 1);
        RETURN;
    END

    -- Xóa tài khoản
    DELETE FROM TaiKhoan WHERE userName = @userName;

    PRINT N'Xóa tài khoản thành công!';
END
GO

-- Đổi mật khẩu
CREATE OR ALTER PROCEDURE dbo.sp_DoiMatKhau
    @userName VARCHAR(100),
    @oldPassword VARCHAR(100),
    @newPassword VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra tài khoản có tồn tại không
    IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE userName = @userName)
    BEGIN
        RAISERROR(N'Tài khoản không tồn tại.', 16, 1);
        RETURN;
    END

    -- Kiểm tra mật khẩu cũ có khớp không
    IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE userName = @userName AND passWord = @oldPassword)
    BEGIN
        RAISERROR(N'Mật khẩu cũ không đúng.', 16, 1);
        RETURN;
    END

    -- Cập nhật mật khẩu mới
    UPDATE TaiKhoan
    SET passWord = @newPassword
    WHERE userName = @userName;

    PRINT N'Đổi mật khẩu thành công!';
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

        DECLARE @ngayHenTra DATE, @soNgayTre INT, @donGia DECIMAL(18,0), @tienPhat DECIMAL(18,0) = 0, @ghiChu NVARCHAR(4000);

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
              AND trangThai IN (N'Đang mượn', N'Quá hạn')
        )
        BEGIN
            RAISERROR(N'Chi tiết phiếu không tồn tại hoặc đã trả.', 16, 1);
            ROLLBACK TRAN;
            RETURN;
        END

        -- Lấy đơn giá sách (join qua bảng Sach)
        SELECT @donGia = ts.donGia
		FROM CuonSach cs
		JOIN TuaSach ts ON cs.maTuaSach = ts.maTuaSach
		WHERE cs.maCuonSach = @maCuonSach;

        -- Tính số ngày trễ (nếu có)
        IF GETDATE() > @ngayHenTra
            SET @soNgayTre = DATEDIFF(DAY, @ngayHenTra, GETDATE());
        ELSE
            SET @soNgayTre = 0;

        -- Xác định tiền phạt theo tình trạng
        SET @ghiChu = ISNULL((SELECT ghiChu FROM CTPhieuMuon WHERE soPhieu=@soPhieu AND maCuonSach=@maCuonSach), N'');

        IF @tinhTrangMoi = N'Mất' 
        BEGIN
            SET @tienPhat = @donGia;
            SET @ghiChu += N' [Mất sách - phạt ' + CAST(@tienPhat AS NVARCHAR) + N'đ]';
        END
        ELSE IF @tinhTrangMoi = N'Hỏng'
        BEGIN
            SET @tienPhat = CAST(@donGia * 0.1 AS INT);
            SET @ghiChu += N' [Hỏng sách - phạt ' + CAST(@tienPhat AS NVARCHAR) + N'đ]';
        END

        -- Nếu quá hạn
        IF @soNgayTre > 0
        BEGIN
            DECLARE @phatTreHan INT = @soNgayTre * 5000;
            SET @tienPhat += @phatTreHan;
            SET @ghiChu += N' [Trả quá hạn ' + CAST(@soNgayTre AS NVARCHAR) + N' ngày - phạt ' 
                         + CAST(@phatTreHan AS NVARCHAR) + N'đ]';
        END
        ELSE
            SET @ghiChu += N' [Đã trả]';

        -- Cập nhật chi tiết phiếu mượn
        UPDATE CTPhieuMuon
        SET trangThai = CASE 
                            WHEN @soNgayTre > 0 THEN N'Quá hạn'
                            ELSE N'Đã trả'
                        END,
            ngayTra   = GETDATE(),
            soNgayTre = @soNgayTre,
            ghiChu    = @ghiChu
        WHERE soPhieu=@soPhieu AND maCuonSach=@maCuonSach;

        -- Cập nhật tình trạng sách
        UPDATE CuonSach
        SET tinhTrang = @tinhTrangMoi
        WHERE maCuonSach = @maCuonSach;

        -- Nếu phiếu không còn sách đang mượn
        IF NOT EXISTS (SELECT 1 FROM CTPhieuMuon WHERE soPhieu=@soPhieu AND trangThai=N'Đang mượn')
        BEGIN
            UPDATE PhieuMuon
            SET trangThai = CASE 
                                WHEN EXISTS (SELECT 1 FROM CTPhieuMuon WHERE soPhieu=@soPhieu AND trangThai=N'Quá hạn') THEN N'Quá hạn'
                                ELSE N'Đã trả'
                            END,
                ngayTra = GETDATE()
            WHERE soPhieu=@soPhieu;
        END

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

CREATE OR ALTER PROCEDURE sp_XemDsChiTietPhieuMuon
    @soPhieu INT = NULL      -- tham số lọc theo số phiếu (có thể bỏ trống)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM v_DsChiTietPhieuMuon
    WHERE (@soPhieu IS NULL OR soPhieu = @soPhieu);

END;
GO

-- Thủ tục gọi view v_PhieuMuon
CREATE OR ALTER PROCEDURE sp_XemPhieuMuon
AS
BEGIN
    SELECT * FROM v_PhieuMuon;
END;
GO
-- Thủ tục gọi view v_DanhsachThanhVien
CREATE OR ALTER PROCEDURE sp_XemDanhsachThanhVien
AS
BEGIN
    SELECT * FROM v_DanhsachThanhVien;
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
    SELECT * FROM v_TaiKhoan;
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

CREATE PROCEDURE sp_GetThongTinTaiKhoan_ChiTiet_ByID
    @userName VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM v_ThongTinTaiKhoan_ChiTiet
    WHERE userName = @userName;
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
-- Tổng số độc giả mượn sách
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

--Lấy thông tin phiếu
CREATE OR ALTER FUNCTION fn_GetThongTinPhieu (@soPhieu INT)
RETURNS TABLE
AS
RETURN
(
    SELECT 
		pm.soPhieu,
        pm.maDocGia,
        pm.maNhanVien,
        dg.maNguoi,
        nd.hoTen AS hoTen,
		pm.ngayHenTra,
        pm.ngayMuon
    FROM PhieuMuon pm
    INNER JOIN DocGia dg ON pm.maDocGia = dg.maDocGia
    INNER JOIN Nguoi nd ON dg.maNguoi = nd.maNguoi
    INNER JOIN NhanVien nv ON pm.maNhanVien = nv.maNhanVien
    WHERE pm.soPhieu = @soPhieu
);
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

CREATE OR ALTER VIEW v_ThongTinTaiKhoan_ChiTiet
AS
SELECT 
    tk.maTaiKhoan,
    tk.maNguoi,
    tk.userName,
    tk.passWord,
    tk.hanTaiKhoan,
    n.vaiTro,
    n.hoTen,
    n.gioiTinh,
    n.SDT,
    n.email,
    n.cccd,
    n.diaChi,
    n.ngaySinh
FROM TaiKhoan tk
LEFT JOIN Nguoi n ON tk.maNguoi = n.maNguoi;
GO

CREATE OR ALTER VIEW v_DsChiTietPhieuMuon
AS
SELECT 
    pm.soPhieu,
    ct.maCuonSach,
    pm.ngayMuon,
    pm.ngayHenTra,
    pm.ngayTra,
    ct.soNgayTre,
    ct.trangThai,
    ct.ghiChu
FROM PhieuMuon pm
JOIN CTPhieuMuon ct ON pm.soPhieu = ct.soPhieu;
GO

CREATE OR ALTER VIEW v_DanhSachThanhVien
AS
SELECT 
    maNguoi,
    hoTen,
    gioiTinh,
    ngaySinh,
    diaChi,
    SDT,
    email,
    cccd,
    vaiTro
FROM Nguoi
WHERE vaiTro = N'guest';
GO


 --================== Phân Quyền ====================
CREATE ROLE AdminRole;
CREATE ROLE StaffRole;
CREATE ROLE GuestRole;
GO

/* --- AdminRole: toàn quyền --- */
GRANT CONTROL ON DATABASE::QLThuVien TO AdminRole;

/* --- StaffRole: quyền nghiệp vụ --- */
GRANT ALTER ANY USER TO StaffRole;
GRANT EXECUTE ON OBJECT::sp_MuonSach TO StaffRole;
GRANT EXECUTE ON OBJECT::sp_TaoTaiKhoanDocGia TO StaffRole;
GRANT EXECUTE ON OBJECT::sp_TraTungSach TO StaffRole;
GRANT EXECUTE ON OBJECT::sp_DanhSachPhieuQuaHan TO StaffRole;
GRANT EXECUTE ON OBJECT::sp_XemPhieuMuon TO StaffRole;
GRANT EXECUTE ON OBJECT::sp_XemCuonSach_Filter TO StaffRole;
GRANT EXECUTE ON OBJECT::sp_XemDocGiaThongTin TO StaffRole;
GRANT EXECUTE ON OBJECT::sp_DsTaiKhoan TO StaffRole;
GRANT EXECUTE ON OBJECT::sp_XemDanhSach_CuonSach_ChiTiet TO StaffRole;
GRANT EXECUTE ON OBJECT::sp_XemDanhSach_CuonSach_ChiTiet_SapXep TO StaffRole;
GRANT EXECUTE ON OBJECT::sp_Login TO StaffRole;
GRANT EXECUTE ON OBJECT::sp_GetThongTinTaiKhoan_ChiTiet_ByID TO StaffRole;
GRANT EXECUTE ON OBJECT::sp_XemDsChiTietPhieuMuon TO StaffRole;
GRANT EXECUTE ON OBJECT::sp_DoiMatKhau TO StaffRole;
GRANT EXECUTE ON OBJECT::sp_ThemDocGia TO StaffRole;
GRANT EXECUTE ON OBJECT::sp_XemDanhSachThanhVien TO StaffRole;

-- Các function / view Staff cần SELECT hoặc EXECUTE
GRANT SELECT ON OBJECT::fn_DanhSachPhieuQuaHanTheoKhoangNgay TO StaffRole;

--GRANT SELECT ON OBJECT::fn_GetThongTinPhieu TO StaffRole;
GRANT INSERT, SELECT ON dbo.TaiKhoan TO StaffRole;
GRANT SELECT ON OBJECT::fn_SachDangMuon TO StaffRole;
GRANT SELECT ON OBJECT::fn_SachTheoTinhTrang TO StaffRole;
GRANT SELECT ON OBJECT::fn_SachTheoTinhTrang_TimKiem TO StaffRole;
GRANT SELECT ON OBJECT::fn_TimKiemCuonSach_ChiTiet TO StaffRole;
GRANT SELECT ON OBJECT::fn_TimKiemDocGia TO StaffRole;
GRANT SELECT ON OBJECT::fn_TimKiemPhieuMuon TO StaffRole;
GRANT SELECT ON OBJECT::fn_TimKiemTaiKhoan TO StaffRole;
GRANT SELECT ON OBJECT::fn_LayDanhSachTacGia TO StaffRole;
GRANT SELECT ON OBJECT::fn_LayDanhSachTheLoai TO StaffRole;
GRANT SELECT ON OBJECT::fn_GetThongTinPhieu TO StaffRole;

GRANT EXECUTE ON OBJECT::fn_GetMaNhanVien TO StaffRole;
GRANT EXECUTE ON OBJECT::fn_ThongKe_DocGia_DangMuon TO StaffRole;
GRANT EXECUTE ON OBJECT::fn_ThongKe_DocGia_Tong TO StaffRole;
GRANT EXECUTE ON OBJECT::fn_ThongKe_DocGia_ViPham TO StaffRole;
GRANT EXECUTE ON OBJECT::fn_ThongKe_Phieu_DangMuon TO StaffRole;
GRANT EXECUTE ON OBJECT::fn_ThongKe_Phieu_DaTra TO StaffRole;
GRANT EXECUTE ON OBJECT::fn_ThongKe_Phieu_Tong TO StaffRole;
GRANT EXECUTE ON OBJECT::fn_ThongKe_Phieu_TreHan TO StaffRole;
GRANT EXECUTE ON OBJECT::fn_ThongKe_Sach_DangMuon TO StaffRole;
GRANT EXECUTE ON OBJECT::fn_ThongKe_Sach_Hong TO StaffRole;
GRANT EXECUTE ON OBJECT::fn_ThongKe_Sach_Mat TO StaffRole;
GRANT EXECUTE ON OBJECT::fn_ThongKe_Sach_Tong TO StaffRole;

GRANT SELECT ON OBJECT::v_CTPhieuMuon TO StaffRole;
GRANT SELECT ON OBJECT::v_CuonSach_ChiTiet TO StaffRole;
GRANT SELECT ON OBJECT::v_DocGiaThongTin TO StaffRole;
GRANT SELECT ON OBJECT::v_TaiKhoan TO StaffRole;
GRANT SELECT ON OBJECT::v_ThongTinTaiKhoan_ChiTiet TO StaffRole;
GRANT SELECT ON OBJECT::v_DsChiTietPhieuMuon TO StaffRole;
GRANT SELECT ON OBJECT::v_DanhsachThanhVien TO StaffRole;
GRANT SELECT ON OBJECT::v_PhieuMuon TO StaffRole;

/* --- GuestRole: chỉ tra cứu --- */
GRANT EXECUTE ON OBJECT::sp_Login TO GuestRole;
GRANT EXECUTE ON OBJECT::sp_XemDanhSach_CuonSach_ChiTiet TO GuestRole;
GRANT EXECUTE ON OBJECT::sp_XemDanhSach_CuonSach_ChiTiet_SapXep TO GuestRole;
GRANT EXECUTE ON OBJECT::sp_XemCuonSach_Filter TO GuestRole;
GRANT EXECUTE ON OBJECT::sp_DoiMatKhau TO GuestRole;

GRANT SELECT ON OBJECT::fn_TimKiemCuonSach_ChiTiet TO GuestRole;
GRANT SELECT ON OBJECT::fn_LayDanhSachTacGia TO GuestRole;
GRANT SELECT ON OBJECT::fn_LayDanhSachTheLoai TO GuestRole;


--============================ Data ===============================
-- Table Nguoi
INSERT INTO Nguoi (hoTen, gioiTinh, ngaySinh, diaChi, SDT, email, cccd, vaiTro)
VALUES
-- 1 Admin
(N'Vũ Quốc Trung', N'Nam', '2005-05-15', N'Hòa Bắc Di Linh Lâm Đồng', '0912345678', 'an.admin@example.com', '012345678901', N'admin'),

-- 3 Staff
( N'Nguyễn Lâm Tấn', N'Nam', '2005-03-20', N'Quận 9 Tp.Thủ Đức', '0923456789', 'tan.staff1@example.com', '123456789012', N'staff'),
(N'Nguyễn Kim Điền', N'Nam', '2005-07-10', N'Đình Phong Phú Quận 9 Tp.Thủ Đức', '0934567890', 'dien.staff2@example.com', '234567890123', N'staff'),
( N'Phạm Quốc Việt', N'Nam', '2005-11-25', N'Quận 1 Tp.Hồ Chí Minh', '0945678901', 'viet.staff3@example.com', '345678901234', N'staff'),

-- 6 Guest
( N'Trần Lê Quốc Đại', N'Nam', '2005-01-01', N'Ba Đình Hà Nội', '0956789012', 'dai.guest@example.com', '456789012345', N'guest'),
( N'Vũ Lê Minh', N'Nữ', '2003-02-15', N'Quận 10 Hồ Chí Minh', '0967890123', 'minh.guest@example.com', '567890123456', N'guest'),
( N'Đỗ Văn Nam', N'Nam', '1999-08-20', N'Cần Thơ', '0978901234', 'nam.guest@example.com', '678901234567', N'guest'),
( N'Vũ Thị Hương', N'Nữ', '2002-04-30', N'Cầu Giấy Hà Nội', '0989012345', 'huong.guest@example.com', '789012345678', N'guest'),
( N'Bùi Tấn Hảo', N'Nam', '2003-12-12', N'Đà Nẵng', '0990123456', 'hao.guest@example.com', '890123456789', N'guest'),
(N'Nguyễn Thị Kim', N'Nữ', '2001-09-09', N'Hải Dương', '0901234567', 'kim.guest@example.com', '901234567890', N'guest');
GO

--Tạo sẵn tài khoản admin và staff (các tài khoản đọc giả sẽ được phân quyền cho admin hoặc staff tạo)
INSERT INTO TaiKhoan (maNguoi, userName, passWord, vaiTro)
VALUES ('11', 'trung', '123', 'admin');
INSERT INTO TaiKhoan (maNguoi, userName, passWord, vaiTro)
VALUES ('12', 'tan', '123', 'staff');
INSERT INTO TaiKhoan (maNguoi, userName, passWord, vaiTro)
VALUES ('13', 'dien', '123', 'staff');

USE master;
GO
GRANT ALTER ANY LOGIN TO dien;
GRANT ALTER ANY LOGIN TO trung;
GRANT ALTER ANY LOGIN TO tan;
--Tựa sách
INSERT INTO TuaSach (tenTuaSach, tacGia, theLoai, nhaXuatBan, namXuatBan, donGia)
VALUES
(N'Harry Potter và Hòn đá Phù thủy', N'J.K. Rowling', N'Tiểu thuyết thiếu nhi', N'NXB Trẻ', 2019, 120000),
(N'Harry Potter và Chiếc cốc lửa', N'J.K. Rowling', N'Tiểu thuyết thiếu nhi', N'NXB Trẻ', 2019, 150000),
(N'Chạng vạng (Twilight)', N'Stephenie Meyer', N'Tiểu thuyết lãng mạn', N'NXB Văn Học', 2018, 110000),
(N'Đắc Nhân Tâm', N'Dale Carnegie', N'Kỹ năng sống', N'NXB Tổng Hợp TPHCM', 2017, 90000),
(N'7 Thói quen hiệu quả', N'Stephen R. Covey', N'Kỹ năng sống', N'NXB Trẻ', 2020, 130000),
(N'Không gia đình', N'Hector Malot', N'Văn học kinh điển', N'NXB Kim Đồng', 2015, 85000),
(N'Tắt đèn', N'Ngô Tất Tố', N'Văn học Việt Nam', N'NXB Văn Học', 2016, 75000),
(N'Chí Phèo', N'Nam Cao', N'Văn học Việt Nam', N'NXB Văn Học', 2017, 60000),
(N'Lão Hạc', N'Nam Cao', N'Văn học Việt Nam', N'NXB Văn Học', 2017, 60000),
(N'Doraemon - Tập 1', N'Fujiko F. Fujio', N'Truyện tranh thiếu nhi', N'NXB Kim Đồng', 2014, 25000),
(N'Thám tử lừng danh Conan - Tập 1', N'Aoyama Gosho', N'Truyện tranh trinh thám', N'NXB Kim Đồng', 2013, 25000),
(N'One Piece - Tập 1', N'Eiichiro Oda', N'Truyện tranh phiêu lưu', N'NXB Kim Đồng', 2015, 25000),
(N'Nghìn lẻ một đêm', N'Nhiều tác giả', N'Truyện dân gian', N'NXB Văn Học', 2010, 95000),
(N'Tôi thấy hoa vàng trên cỏ xanh', N'Nguyễn Nhật Ánh', N'Tiểu thuyết thiếu nhi', N'NXB Trẻ', 2018, 105000),
(N'Mắt biếc', N'Nguyễn Nhật Ánh', N'Tiểu thuyết lãng mạn', N'NXB Trẻ', 2019, 98000);
GO

--Cuốn sách
-- Tủ 1
INSERT INTO CuonSach (maTuaSach, tinhTrang, viTri) VALUES
(1, N'Có sẵn', N'Tủ 1 - Kệ 1'),
(1, N'Có sẵn', N'Tủ 1 - Kệ 1'),
(1, N'Có sẵn', N'Tủ 1 - Kệ 1'),
(1, N'Có sẵn', N'Tủ 1 - Kệ 1'),

(2, N'Có sẵn', N'Tủ 1 - Kệ 2'),
(2, N'Có sẵn', N'Tủ 1 - Kệ 2'),
(2, N'Có sẵn', N'Tủ 1 - Kệ 2'),
(2, N'Có sẵn', N'Tủ 1 - Kệ 2'),

(3, N'Có sẵn', N'Tủ 1 - Kệ 3'),
(3, N'Có sẵn', N'Tủ 1 - Kệ 3'),
(3, N'Có sẵn', N'Tủ 1 - Kệ 3'),
(3, N'Có sẵn', N'Tủ 1 - Kệ 3'),

(4, N'Có sẵn', N'Tủ 1 - Kệ 4'),
(4, N'Có sẵn', N'Tủ 1 - Kệ 4'),
(4, N'Có sẵn', N'Tủ 1 - Kệ 4'),
(4, N'Có sẵn', N'Tủ 1 - Kệ 4');

-- Tủ 2
INSERT INTO CuonSach (maTuaSach, tinhTrang, viTri) VALUES
(5, N'Có sẵn', N'Tủ 2 - Kệ 1'),
(5, N'Có sẵn', N'Tủ 2 - Kệ 1'),
(5, N'Có sẵn', N'Tủ 2 - Kệ 1'),
(5, N'Có sẵn', N'Tủ 2 - Kệ 1'),

(6, N'Có sẵn', N'Tủ 2 - Kệ 2'),
(6, N'Có sẵn', N'Tủ 2 - Kệ 2'),
(6, N'Có sẵn', N'Tủ 2 - Kệ 2'),
(6, N'Có sẵn', N'Tủ 2 - Kệ 2'),

(7, N'Có sẵn', N'Tủ 2 - Kệ 3'),
(7, N'Có sẵn', N'Tủ 2 - Kệ 3'),
(7, N'Có sẵn', N'Tủ 2 - Kệ 3'),
(7, N'Có sẵn', N'Tủ 2 - Kệ 3'),

(8, N'Có sẵn', N'Tủ 2 - Kệ 4'),
(8, N'Có sẵn', N'Tủ 2 - Kệ 4'),
(8, N'Có sẵn', N'Tủ 2 - Kệ 4'),
(8, N'Có sẵn', N'Tủ 2 - Kệ 4');

-- Tủ 3
INSERT INTO CuonSach (maTuaSach, tinhTrang, viTri) VALUES
(9,  N'Có sẵn', N'Tủ 3 - Kệ 1'),
(9,  N'Có sẵn', N'Tủ 3 - Kệ 1'),
(9,  N'Có sẵn', N'Tủ 3 - Kệ 1'),
(9,  N'Có sẵn', N'Tủ 3 - Kệ 1'),

(10, N'Có sẵn', N'Tủ 3 - Kệ 2'),
(10, N'Có sẵn', N'Tủ 3 - Kệ 2'),
(10, N'Có sẵn', N'Tủ 3 - Kệ 2'),
(10, N'Có sẵn', N'Tủ 3 - Kệ 2'),

(11, N'Có sẵn', N'Tủ 3 - Kệ 3'),
(11, N'Có sẵn', N'Tủ 3 - Kệ 3'),
(11, N'Có sẵn', N'Tủ 3 - Kệ 3'),
(11, N'Có sẵn', N'Tủ 3 - Kệ 3'),

(12, N'Có sẵn', N'Tủ 3 - Kệ 4'),
(12, N'Có sẵn', N'Tủ 3 - Kệ 4'),
(12, N'Có sẵn', N'Tủ 3 - Kệ 4'),
(12, N'Có sẵn', N'Tủ 3 - Kệ 4');

-- Tủ 4
INSERT INTO CuonSach (maTuaSach, tinhTrang, viTri) VALUES
(13, N'Có sẵn', N'Tủ 4 - Kệ 1'),
(13, N'Có sẵn', N'Tủ 4 - Kệ 1'),
(13, N'Có sẵn', N'Tủ 4 - Kệ 1'),
(13, N'Có sẵn', N'Tủ 4 - Kệ 1'),

(14, N'Có sẵn', N'Tủ 4 - Kệ 2'),
(14, N'Có sẵn', N'Tủ 4 - Kệ 2'),
(14, N'Có sẵn', N'Tủ 4 - Kệ 2'),
(14, N'Có sẵn', N'Tủ 4 - Kệ 2'),

(15, N'Có sẵn', N'Tủ 4 - Kệ 3'),
(15, N'Có sẵn', N'Tủ 4 - Kệ 3'),
(15, N'Có sẵn', N'Tủ 4 - Kệ 3'),
(15, N'Có sẵn', N'Tủ 4 - Kệ 3');


