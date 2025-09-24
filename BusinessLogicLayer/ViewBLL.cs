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
