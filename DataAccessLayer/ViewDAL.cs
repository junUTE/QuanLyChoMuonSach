using System.Data;

namespace DataAccessLayer
{
    public class ViewDAL
    {
        public DataTable GetPhieuMuon()
        {
            return LoadData.ExecuteQuery("SELECT * FROM v_PhieuMuon");
        }

        public DataTable GetPhieuMuonGanNhat()
        {
            string sql = "SELECT TOP 1 * FROM v_PhieuMuon ORDER BY ngayMuon DESC";
            return LoadData.ExecuteQuery(sql);
        }

        public DataTable GetPhieuMuonXaNhat()
        {
            string sql = "SELECT TOP 1 * FROM v_PhieuMuon ORDER BY ngayMuon ASC";
            return LoadData.ExecuteQuery(sql);
        }

        public DataTable GetTaiKhoanNguoi()
        {
            return LoadData.ExecuteQuery("SELECT * FROM v_TaiKhoanNguoi");
        }

        public DataTable GetAllBooks()
        {
            string sql = "SELECT * FROM Sach";
            return LoadData.ExecuteQuery(sql);
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
