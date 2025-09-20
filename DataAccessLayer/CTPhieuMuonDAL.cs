using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class CTPhieuMuonDAL
    {
        // Chỉnh sửa chi tiết phiếu mượn (đổi sách cũ -> sách mới)
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
    }
}
