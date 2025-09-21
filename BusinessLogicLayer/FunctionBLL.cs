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

        public int TongNgayTre(string maDocGia)
        {
            return _dal.TongNgayTre(maDocGia);
        }

        public int TongSachTheoTinhTrang(string tinhTrang)
        {
            return _dal.TongSachTheoTinhTrang(tinhTrang);
        }

        public DataTable SachDangMuon(string maDocGia)
        {
            return _dal.SachDangMuon(maDocGia);
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
        public string GetHoTenDocGia(int soPhieu)
        {
            return _dal.GetHoTenDocGia(soPhieu);
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
    }
}
