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
    }
}
