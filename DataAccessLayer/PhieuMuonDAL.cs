using System.Data.SqlClient;
using System;
using System.Data;

namespace DataAccessLayer
{
    public class PhieuMuonDAL
    {
        public DataTable GetAll()
        {
            return LoadData.ExecuteQuery("SELECT * FROM v_PhieuMuon");
        }

        public DataTable GetAllOrderByNgayMuonDesc()
        {
            return LoadData.ExecuteQuery("SELECT * FROM v_PhieuMuon ORDER BY ngayMuon DESC");
        }

        public DataTable GetAllOrderByNgayMuonAsc()
        {
            return LoadData.ExecuteQuery("SELECT * FROM v_PhieuMuon ORDER BY ngayMuon ASC");
        }

        // sp_MuonSach: cần TVP @dsSach = dbo.SachMuon_Type(maCuonSach INT)
        public int MuonSach(string maDocGia, string maNhanVien, DateTime ngayHenTra, DataTable dsSach)
        {
            var p1 = new SqlParameter("@maDocGia", maDocGia);
            var p2 = new SqlParameter("@maNhanVien", maNhanVien);
            var p3 = new SqlParameter("@ngayHenTra", SqlDbType.Date) { Value = ngayHenTra.Date };
            var p4 = new SqlParameter("@dsSach", SqlDbType.Structured)
            {
                TypeName = "dbo.SachMuon_Type",
                Value = dsSach
            };

            // SP trả về SELECT @soPhieu AS SoPhieuMoi;
            var dt = LoadData.ExecuteQuerySP("sp_MuonSach", p1, p2, p3, p4);
            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0][0]); // cột đầu tiên là SoPhieuMoi
            return 0;
        }

        public bool TraTungSach(int soPhieu, int maCuonSach)
        {
            var prms = new[]
            {
                new SqlParameter("@soPhieu", soPhieu),
                new SqlParameter("@maCuonSach", maCuonSach)
            };
            return LoadData.ExecuteNonQuerySP("sp_TraTungSach", prms) > 0;
        }

        public bool HuyPhieu(int soPhieu)
        {
            var prms = new[] { new SqlParameter("@soPhieu", soPhieu) };
            return LoadData.ExecuteNonQuerySP("sp_HuyPhieuMuon", prms) > 0;
        }

        public bool ChinhSuaPhieuMuon(int soPhieu, string maNhanVien, DateTime ngayHenTra)
        {
            var prms = new[]
            {
                new SqlParameter("@soPhieu", soPhieu),
                new SqlParameter("@maNhanVien", maNhanVien),
                new SqlParameter("@ngayHenTra", SqlDbType.Date){ Value = ngayHenTra.Date }
            };
            return LoadData.ExecuteNonQuerySP("sp_ChinhSuaPhieuMuon", prms) > 0;
        }
    }
}
