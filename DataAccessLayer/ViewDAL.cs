using System.Data;

namespace DataAccessLayer
{
    public class ViewDAL
    {
        public DataTable GetPhieuMuon()
        {
            return LoadData.ExecuteQuery("SELECT * FROM v_PhieuMuon");
        }
        public DataTable GetDocGiaThongTin()
        {
            string sql = "SELECT * FROM v_DocGiaThongTin";
            return LoadData.ExecuteQuery(sql);
        }
        public DataTable GetCTPhieuMuon(int soPhieu)
        {
            string sql = "SELECT * FROM v_CTPhieuMuon WHERE soPhieu = @param0";
            return LoadData.ExecuteQuery(sql, new object[] { soPhieu });
        }

        public DataTable GetAllOrderByNgayMuonDesc()
        {
            return LoadData.ExecuteQuery("SELECT * FROM v_PhieuMuon ORDER BY ngayMuon DESC");
        }

        public DataTable GetAllOrderByNgayMuonAsc()
        {
            return LoadData.ExecuteQuery("SELECT * FROM v_PhieuMuon ORDER BY ngayMuon ASC");
        }
    }
}
