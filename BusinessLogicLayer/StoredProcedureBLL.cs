using System;
using System.Data;
using System.Data.Entity;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class StoredProcedureBLL
    {
        private readonly StoredProcedureDAL _dal;

        public StoredProcedureBLL()
        {
            _dal = new StoredProcedureDAL();
        }
        // Chỉnh sửa phiếu mượn (nhân viên xử lý, ngày hẹn trả)
        public bool ChinhSuaPhieuMuon(int soPhieu, string maNhanVien, DateTime ngayHenTra, out string error)
        {
            if (ngayHenTra < DateTime.Today)
            {
                error = "Ngày hẹn trả không thể nhỏ hơn ngày hiện tại.";
                return false;
            }
            // Không validation, chỉ gọi DAL
            return _dal.ChinhSuaPhieuMuon(soPhieu, maNhanVien, ngayHenTra, out error);
        }
        // Chỉnh sửa chi tiết phiếu mượn
        public bool ChinhSuaCT(int soPhieu, int maCuonSachCu, int maCuonSachMoi, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (soPhieu <= 0 || maCuonSachCu <= 0 || maCuonSachMoi <= 0)
            {
                errorMessage = "Dữ liệu đầu vào không hợp lệ.";
                return false;
            }

            return _dal.ChinhSuaCT(soPhieu, maCuonSachCu, maCuonSachMoi, out errorMessage);
        }

        // Xóa chi tiết phiếu mượn
        public bool XoaCT(int soPhieu, int maCuonSach, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (soPhieu <= 0 || maCuonSach <= 0)
            {
                errorMessage = "Dữ liệu đầu vào không hợp lệ.";
                return false;
            }

            return _dal.XoaCT(soPhieu, maCuonSach, out errorMessage);
        }


        // Thêm chi tiết phiếu mượn
        public bool ThemCT(int soPhieu, int maCuonSach, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (soPhieu <= 0 || maCuonSach <= 0)
            {
                errorMessage = "Dữ liệu đầu vào không hợp lệ.";
                return false;
            }

            return _dal.ThemCT(soPhieu, maCuonSach, out errorMessage);
        }

        // Mượn sách
        public int MuonSach(string maDocGia, string maNhanVien, DateTime ngayHenTra, DataTable dsSach)
        {
            if (string.IsNullOrWhiteSpace(maDocGia) ||
                string.IsNullOrWhiteSpace(maNhanVien) ||
                dsSach == null || dsSach.Rows.Count == 0)
                return 0;

            return _dal.MuonSach(maDocGia, maNhanVien, ngayHenTra, dsSach);
        }

        // Trả từng sách
        public bool TraTungSach(int soPhieu, int maCuonSach,string tinhTrangMoi, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (soPhieu <= 0 || maCuonSach <= 0)
            {
                errorMessage = "Số phiếu hoặc mã cuốn sách không hợp lệ.";
                return false;
            }

            return _dal.TraTungSach(soPhieu, maCuonSach, tinhTrangMoi, out errorMessage);
        }

        // Hủy phiếu mượn
        public bool HuyPhieu(int soPhieu)
        {
            if (soPhieu <= 0)
                return false;

            try
            {
                return _dal.HuyPhieu(soPhieu);
            }
            catch (Exception ex)
            {
                // Ghi log nếu cần
                Console.WriteLine("Lỗi khi hủy phiếu: " + ex.Message);
                return false;
            }
        }

        // Danh sách phiếu quá hạn
        public DataTable DanhSachPhieuQuaHan()
        {
            return _dal.DanhSachPhieuQuaHan();
        }

        // Danh sách cuốn sách
        public DataTable DanhSachCuonSach()
        {
            return _dal.XemDanhSach_CuonSach_ChiTiet();
        }

        public DataTable DanhSachCuonSachSapXep()
        {
            return _dal.XemDanhSach_CuonSach_ChiTiet_SapXep();
        }
        public DataTable XemCuonSach_Filter(string tacGia = null, string theLoai = null)
        {
            return _dal.XemCuonSach_Filter(tacGia, theLoai);
        }

        public DataTable DsTaiKhoan()
        {
            return _dal.DsTaiKhoan();
        }

        public bool TaoTaiKhoanDocGia (string maDocGia, string tenDangNhap, string matKhau, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(maDocGia) ||
                string.IsNullOrWhiteSpace(tenDangNhap) ||
                string.IsNullOrWhiteSpace(matKhau))
            {
                errorMessage = "Dữ liệu đầu vào không hợp lệ.";
                return false;
            }
            return _dal.TaoTaiKhoanDocGia(maDocGia, tenDangNhap, matKhau, out errorMessage);
        }

        public bool XoaTaiKhoan(string tenDangNhap, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                errorMessage = "Tên đăng nhập không hợp lệ.";
                return false;
            }
            try
            {
                return _dal.XoaTaiKhoan(tenDangNhap, out errorMessage);
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi xóa tài khoản: " + ex.Message;
                return false;
            }
        }

        public bool DoiMatKhau(string userName, string oldPassword, string newPassword, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(oldPassword) || string.IsNullOrWhiteSpace(newPassword))
            {
                errorMessage = "Thông tin đầu vào không hợp lệ.";
                return false;
            }

            if (oldPassword == newPassword)
            {
                errorMessage = "Mật khẩu mới không được trùng với mật khẩu cũ.";
                return false;
            }

            return _dal.DoiMatKhau(userName, oldPassword, newPassword, out errorMessage);
        }

        public DataTable XemDsChiTietPhieuMuon(int? soPhieu, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (soPhieu.HasValue && soPhieu <= 0)
            {
                errorMessage = "Số phiếu không hợp lệ.";
                return null;
            }
            try
            {
                return _dal.XemDsChiTietPhieuMuon(soPhieu, out errorMessage);
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi lấy dữ liệu: " + ex.Message;
                return null;
            }
        }
        public bool ThemDocGia(string hoTen, string gioiTinh, DateTime ngaySinh, string diaChi, string sdt, string email, string cccd, out string errorMessage)
        {
            return _dal.ThemDocGia(hoTen, gioiTinh, ngaySinh, diaChi, sdt, email, cccd, out errorMessage);
        }
        public DataTable XemDSThanhVien()
        {
            return _dal.XemDSThanhVien();
        }
    }
}
