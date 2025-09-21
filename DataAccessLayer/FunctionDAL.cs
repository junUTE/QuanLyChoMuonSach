using System;
using System.Data;
using System.Data.SqlClient;
using static System.Collections.Specialized.BitVector32;


namespace DataAccessLayer
{
    public class FunctionDAL
    {
        // fn_TongNgayTre: trả về INT
        public int TongNgayTre(string maDocGia)
        {
            string sql = "SELECT dbo.fn_TongNgayTre(@param0)";
            DataTable dt = LoadData.ExecuteQuery(sql, new object[] { maDocGia });
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }

        // fn_TongSachTheoTinhTrang: trả về INT
        public int TongSachTheoTinhTrang(string tinhTrang)
        {
            string sql = "SELECT dbo.fn_TongSachTheoTinhTrang(@param0)";
            DataTable dt = LoadData.ExecuteQuery(sql, new object[] { tinhTrang });
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }

        // fn_SachDangMuon: trả về bảng
        public DataTable SachDangMuon(string maDocGia)
        {
            string sql = "SELECT * FROM dbo.fn_SachDangMuon(@param0)";
            return LoadData.ExecuteQuery(sql, new object[] { maDocGia });
        }

        // fn_SachTheoTinhTrang: trả về bảng
        public  DataTable SachTheoTinhTrang(string tinhTrang)
        {
            string sql = "SELECT * FROM dbo.fn_SachTheoTinhTrang(@param0)";
            return LoadData.ExecuteQuery(sql, new object[] { tinhTrang });
        }

        public DataTable TimKiemPhieuMuon(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return LoadData.ExecuteQuery("SELECT * FROM v_PhieuMuon"); ;
            }
            string sql = "SELECT * FROM dbo.fn_TimKiemPhieuMuon(@param0)";
            return LoadData.ExecuteQuery(sql, new object[] { keyword });
        }

        public string GetMaNhanVien(string maNguoi)
        {
            const string sql = "SELECT dbo.fn_GetMaNhanVien(@param0) AS maNhanVien";
            var dt = LoadData.ExecuteQuery(sql, new object[] { maNguoi });

            if (dt.Rows.Count == 0 || dt.Rows[0]["maNhanVien"] == DBNull.Value)
                return null;

            return dt.Rows[0]["maNhanVien"].ToString();
        }

        public string GetHoTenDocGia(int soPhieu)
        {
            const string sql = "SELECT dbo.fn_GetHoTenDocGia(@param0) AS HoTen";
            var dt = LoadData.ExecuteQuery(sql, new object[] { soPhieu });

            if (dt.Rows.Count == 0 || dt.Rows[0]["HoTen"] == DBNull.Value)
                return null;

            return dt.Rows[0]["HoTen"].ToString();
        }

        public DataTable GetThongTinPhieu(int soPhieu)
        {
            const string sql = "SELECT * FROM dbo.fn_GetThongTinPhieu(@param0)";
            return LoadData.ExecuteQuery(sql, new object[] { soPhieu });
        }
        public DataTable GetSachTheoTinhTrang(string tinhTrang, string keyword)
        {
            // Phải viết đúng tham số dạng @param0, @param1
            string sql = "SELECT * FROM dbo.fn_SachTheoTinhTrang_TimKiem(@param0, @param1)";

            object[] prms = { tinhTrang, keyword ?? string.Empty };

            return LoadData.ExecuteQuery(sql, prms);
        }

        public DataTable TimKiemDocGia(string keyword)
        {
            string sql = "SELECT * FROM dbo.fn_TimKiemDocGia(@param0)";

            object[] prms = { keyword ?? string.Empty };

            return LoadData.ExecuteQuery(sql, prms);
        }
    }
}
