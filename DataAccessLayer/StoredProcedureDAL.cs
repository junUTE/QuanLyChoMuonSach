using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class StoredProcedureDAL
    {
        public bool ChinhSuaCT(int soPhieu, int maCuonSachCu, int maCuonSachMoi)
        {
            string sp = "sp_ChinhSuaCTPhieuMuon";
            var prms = new[]
            {
                new SqlParameter("@soPhieu", soPhieu),
                new SqlParameter("@maCuonSachCu", maCuonSachCu),
                new SqlParameter("@maCuonSachMoi", maCuonSachMoi)
            };
            int rows = LoadData.ExecuteNonQuerySP(sp, prms);
            return rows > 0;
        }

        // Xóa chi tiết phiếu mượn (trả hoặc bỏ cuốn)
        public bool XoaCT(int soPhieu, int maCuonSach)
        {
            string sp = "sp_XoaCTPhieuMuon";
            var prms = new[]
            {
                new SqlParameter("@soPhieu", soPhieu),
                new SqlParameter("@maCuonSach", maCuonSach)
            };
            int rows = LoadData.ExecuteNonQuerySP(sp, prms);
            return rows > 0;
        }

        // Thêm chi tiết phiếu mượn (thêm 1 cuốn mới vào phiếu)
        public bool ThemCT(int soPhieu, int maCuonSach)
        {
            string sp = "sp_ThemCTPhieuMuon";
            var prms = new[]
            {
                new SqlParameter("@soPhieu", soPhieu),
                new SqlParameter("@maCuonSach", maCuonSach)
            };
            int rows = LoadData.ExecuteNonQuerySP(sp, prms);
            return rows > 0;
        }

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

        public bool TraTungSach(int soPhieu, int maCuonSach, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                var prms = new[]
                {
            new SqlParameter("@soPhieu", soPhieu),
            new SqlParameter("@maCuonSach", maCuonSach)
        };
                LoadData.ExecuteNonQuerySP("sp_TraTungSach", prms);
                return true;
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message;
                return false;
            }
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

        public DataTable DanhSachPhieuQuaHan()
        {
            return LoadData.ExecuteQuery("EXEC sp_DanhSachPhieuQuaHan");
        }
    }
}
