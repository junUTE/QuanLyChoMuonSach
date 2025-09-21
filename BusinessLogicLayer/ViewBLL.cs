using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class ViewBLL
    {
        private readonly ViewDAL _dal;

        public ViewBLL()
        {
            _dal = new ViewDAL();  
        }

        public DataTable GetPhieuMuon()
        {
            return _dal.GetPhieuMuon();
        }

        public DataTable GetPhieuMuonGanNhat()
        {
            return _dal.GetPhieuMuonGanNhat();
        }

        public DataTable GetPhieuMuonXaNhat()
        {
            return _dal.GetPhieuMuonXaNhat();
        }

        public DataTable GetTaiKhoanNguoi()
        {
            return _dal.GetTaiKhoanNguoi();
        }

        public DataTable GetAllBooks()
        {
            return _dal.GetAllBooks();
        }

        public DataTable GetDocGiaThongTin()
        {
            return _dal.GetDocGiaThongTin();
        }
        public DataTable GetCTPhieuMuon(int soPhieu)
        {
            return _dal.GetCTPhieuMuon(soPhieu);
        }

        public DataTable GetAllOrderByNgayMuonDesc()
        {
            return _dal.GetAllOrderByNgayMuonDesc();
        }

        public DataTable GetAllOrderByNgayMuonAsc()
        {
            return _dal.GetAllOrderByNgayMuonAsc();
        }
    }
}
