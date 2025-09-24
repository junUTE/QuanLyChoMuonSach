using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class FunctionBLL
    {
        private readonly FunctionDAL _dal;

        public FunctionBLL()
        {
            _dal = new FunctionDAL();
        }

        public DataTable SachTheoTinhTrang(string tinhTrang)
        {
            return _dal.SachTheoTinhTrang(tinhTrang);
        }

        public DataTable TimKiemPhieuMuon(string keyword)
        {
            return _dal.TimKiemPhieuMuon(keyword);
        }

        public string GetMaNhanVien(string maNguoi)
        {
            return _dal.GetMaNhanVien(maNguoi);
        }
        public DataTable GetThongTinPhieu(int soPhieu)
        {
            return _dal.GetThongTinPhieu(soPhieu);
        }

        public DataTable TimKiemSachTheoTinhTrang(string tinhTrang, string keyword)
        {
            if (string.IsNullOrWhiteSpace(tinhTrang))
                tinhTrang = "Có sẵn"; // mặc định

            return _dal.GetSachTheoTinhTrang(tinhTrang, keyword);
        }

        public DataTable TimKiemDocGia(string keyword)
        {
            // Nếu từ khóa null thì coi như rỗng
            return _dal.TimKiemDocGia(keyword?.Trim() ?? string.Empty);
        }
        public DataTable LayDanhSachTacGia()
        {
            return _dal.LayDanhSachTacGia();
        }

        public DataTable LayDanhSachTheLoai()
        {
            return _dal.LayDanhSachTheLoai();
        }

        public DataTable TimKiemCuonSach_ChiTiet(string keyword)
        {
            return _dal.TimKiemCuonSach_ChiTiet(keyword);
        }

        public DataTable TimKiemTaiKhoan(string keyword)
        {
            return _dal.TimKiemTaiKhoan(keyword);
        }

        // ================= Phiếu mượn =================
        public int GetSoPhieuDangMuon(DateTime tuNgay, DateTime denNgay)
        {
            return _dal.SoPhieuDangMuon(tuNgay, denNgay);
        }

        public int GetSoPhieuDaTra(DateTime tuNgay, DateTime denNgay)
        {
            return _dal.SoPhieuDaTra(tuNgay, denNgay);
        }

        public int GetSoPhieuTreHan(DateTime tuNgay, DateTime denNgay)
        {
            return _dal.SoPhieuTreHan(tuNgay, denNgay);
        }

        public int GetTongPhieu(DateTime tuNgay, DateTime denNgay)
        {
            return _dal.TongPhieu(tuNgay, denNgay);
        }

        // ================= Sách =================
        public int GetSoSachDangMuon(DateTime tuNgay, DateTime denNgay)
        {
            return _dal.SoSachDangMuon(tuNgay, denNgay);
        }

        public int GetSoSachHong(DateTime tuNgay, DateTime denNgay)
        {
            return _dal.SoSachHong(tuNgay, denNgay);
        }

        public int GetSoSachMat(DateTime tuNgay, DateTime denNgay)
        {
            return _dal.SoSachMat(tuNgay, denNgay);
        }

        public int GetTongSach()
        {
            return _dal.TongSach();
        }

        // ================= Độc giả =================
        public int GetSoDocGiaDangMuon(DateTime tuNgay, DateTime denNgay)
        {
            return _dal.SoDocGiaDangMuon(tuNgay, denNgay);
        }

        public int GetSoDocGiaViPham(DateTime tuNgay, DateTime denNgay)
        {
            return _dal.SoDocGiaViPham(tuNgay, denNgay);
        }

        public int GetTongDocGia()
        {
            return _dal.TongDocGia();
        }

        public DataTable DanhSachPhieuQuaHan()
        {
            return _dal.DanhSachPhieuQuaHan();
        }
        public DataTable GetDanhSachPhieuQuaHan(DateTime tuNgay, DateTime denNgay)
        {
            return _dal.DanhSachPhieuQuaHanTheoKhoangNgay(tuNgay, denNgay);
        }
    }
}
