using System;
using System.Data;
using System.Data.SqlClient;
using static System.Collections.Specialized.BitVector32;


namespace DataAccessLayer
{
    public class FunctionDAL
    {

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

        // Lấy danh sách tác giả từ function SQL
        public DataTable LayDanhSachTacGia()
        {
            string sql = "SELECT tacGia FROM fn_LayDanhSachTacGia() ORDER BY tacGia";
            return LoadData.ExecuteQuery(sql);
        }

        // Lấy danh sách thể loại từ function SQL
        public DataTable LayDanhSachTheLoai()
        {
            string sql = "SELECT theLoai FROM fn_LayDanhSachTheLoai() ORDER BY theLoai";
            return LoadData.ExecuteQuery(sql);
        }

        public DataTable TimKiemCuonSach_ChiTiet(string keyword)
        {

            object[] prms = { keyword ?? string.Empty };

            string sql = "SELECT * FROM fn_TimKiemCuonSach_ChiTiet(@param0)";

            return LoadData.ExecuteQuery(sql, prms);
        }

        public DataTable TimKiemTaiKhoan(string keyword)
        {
            string sql = "SELECT * FROM dbo.fn_TimKiemTaiKhoan(@param0)";
            return LoadData.ExecuteQuery(sql, new object[] { keyword ?? string.Empty });
        }

        // ================= Phiếu mượn =================
        public int SoPhieuDangMuon(DateTime tuNgay, DateTime denNgay)
        {
            string sql = "SELECT dbo.fn_ThongKe_Phieu_DangMuon(@param0, @param1) AS SoPhieu";
            var dt = LoadData.ExecuteQuery(sql, new object[] { tuNgay, denNgay });
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["SoPhieu"]) : 0;
        }

        public int SoPhieuDaTra(DateTime tuNgay, DateTime denNgay)
        {
            string sql = "SELECT dbo.fn_ThongKe_Phieu_DaTra(@param0, @param1) AS SoPhieu";
            var dt = LoadData.ExecuteQuery(sql, new object[] { tuNgay, denNgay });
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["SoPhieu"]) : 0;
        }

        public int SoPhieuTreHan(DateTime tuNgay, DateTime denNgay)
        {
            string sql = "SELECT dbo.fn_ThongKe_Phieu_TreHan(@param0, @param1) AS SoPhieu";
            var dt = LoadData.ExecuteQuery(sql, new object[] { tuNgay, denNgay });
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["SoPhieu"]) : 0;
        }

        public int TongPhieu(DateTime tuNgay, DateTime denNgay)
        {
            string sql = "SELECT dbo.fn_ThongKe_Phieu_Tong(@param0, @param1) AS SoPhieu";
            var dt = LoadData.ExecuteQuery(sql, new object[] { tuNgay, denNgay });
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["SoPhieu"]) : 0;
        }

        // ================= Sách =================
        public int SoSachDangMuon(DateTime tuNgay, DateTime denNgay)
        {
            string sql = "SELECT dbo.fn_ThongKe_Sach_DangMuon(@param0, @param1) AS SoSach";
            var dt = LoadData.ExecuteQuery(sql, new object[] { tuNgay, denNgay });
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["SoSach"]) : 0;
        }

        public int SoSachHong(DateTime tuNgay, DateTime denNgay)
        {
            string sql = "SELECT dbo.fn_ThongKe_Sach_Hong(@param0, @param1) AS SoSach";
            var dt = LoadData.ExecuteQuery(sql, new object[] { tuNgay, denNgay });
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["SoSach"]) : 0;
        }

        public int SoSachMat(DateTime tuNgay, DateTime denNgay)
        {
            string sql = "SELECT dbo.fn_ThongKe_Sach_Mat(@param0, @param1) AS SoSach";
            var dt = LoadData.ExecuteQuery(sql, new object[] { tuNgay, denNgay });
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["SoSach"]) : 0;
        }

        public int TongSach()
        {
            string sql = "SELECT dbo.fn_ThongKe_Sach_Tong() AS SoSach";
            var dt = LoadData.ExecuteQuery(sql);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["SoSach"]) : 0;
        }

        // ================= Độc giả =================
        public int SoDocGiaDangMuon(DateTime tuNgay, DateTime denNgay)
        {
            string sql = "SELECT dbo.fn_ThongKe_DocGia_DangMuon(@param0, @param1) AS SoDocGia";
            var dt = LoadData.ExecuteQuery(sql, new object[] { tuNgay, denNgay });
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["SoDocGia"]) : 0;
        }

        public int SoDocGiaViPham(DateTime tuNgay, DateTime denNgay)
        {
            string sql = "SELECT dbo.fn_ThongKe_DocGia_ViPham(@param0, @param1) AS SoDocGia";
            var dt = LoadData.ExecuteQuery(sql, new object[] { tuNgay, denNgay });
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["SoDocGia"]) : 0;
        }

        public int TongDocGia()
        {
            string sql = "SELECT dbo.fn_ThongKe_DocGia_Tong() AS SoDocGia";
            var dt = LoadData.ExecuteQuery(sql);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["SoDocGia"]) : 0;
        }

        public DataTable DanhSachPhieuQuaHan()
        {
            string sql = "EXEC sp_DanhSachPhieuQuaHan";
            return LoadData.ExecuteQuery(sql);
        }
        public DataTable DanhSachPhieuQuaHanTheoKhoangNgay(DateTime tuNgay, DateTime denNgay)
        {
            string sql = "SELECT * FROM dbo.fn_DanhSachPhieuQuaHanTheoKhoangNgay(@param0, @param1)";
            object[] prms = { tuNgay, denNgay };
            return LoadData.ExecuteQuery(sql, prms);
        }

    }
}
