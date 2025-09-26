using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class StoredProcedureDAL
    {
        // Chỉnh sửa phiếu mượn (nhân viên xử lý, ngày hẹn trả)
        public bool ChinhSuaPhieuMuon(int soPhieu, string maNhanVien, DateTime ngayHenTra, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string sp = "sp_ChinhSuaPhieuMuon";
                var prms = new[]
                {
            new SqlParameter("@soPhieu", soPhieu),
            new SqlParameter("@maNhanVien", maNhanVien),
            new SqlParameter("@ngayHenTra", ngayHenTra)
        };

                LoadData.ExecuteNonQuerySP(sp, prms);

                // Nếu không lỗi thì coi như thành công
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
        // Chỉnh sửa chi tiết phiếu mượn (thay cuốn sách này bằng cuốn sách khác)
        public bool ChinhSuaCT(int soPhieu, int maCuonSachCu, int maCuonSachMoi, out string error)
        {
            error = string.Empty;
            try
            {
                string sp = "sp_ChinhSuaCTPhieuMuon";
                var prms = new[]
                {
            new SqlParameter("@soPhieu", soPhieu),
            new SqlParameter("@maCuonSachCu", maCuonSachCu),
            new SqlParameter("@maCuonSachMoi", maCuonSachMoi)
        };
                LoadData.ExecuteNonQuerySP(sp, prms); // không cần check rows
                return true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
                return false;
            }
        }

        // Xóa chi tiết phiếu mượn (trả hoặc bỏ cuốn)
        public bool XoaCT(int soPhieu, int maCuonSach, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string sp = "sp_XoaCTPhieuMuon";
                var prms = new[]
                {
            new SqlParameter("@soPhieu", soPhieu),
            new SqlParameter("@maCuonSach", maCuonSach)
        };

                LoadData.ExecuteNonQuerySP(sp, prms);
                return true;
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }


        // Thêm chi tiết phiếu mượn (thêm 1 cuốn mới vào phiếu)
        public bool ThemCT(int soPhieu, int maCuonSach, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string sp = "sp_ThemCTPhieuMuon";
                var prms = new[]
                {
                    new SqlParameter("@soPhieu", soPhieu),
                    new SqlParameter("@maCuonSach", maCuonSach)
                };

                LoadData.ExecuteNonQuerySP(sp, prms); // nếu SP ném lỗi thì catch sẽ bắt
                return true;
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message;
                return false;
            }
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

        public bool TraTungSach(int soPhieu, int maCuonSach, string tinhTrangMoi, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                var prms = new[]
                {
                    new SqlParameter("@soPhieu", soPhieu),
                    new SqlParameter("@maCuonSach", maCuonSach),
                    new SqlParameter("@tinhTrangMoi", (object)tinhTrangMoi ?? DBNull.Value)
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
            object result = LoadData.ExecuteScalarSP("sp_HuyPhieuMuon", prms);

            return result != null && Convert.ToInt32(result) == 1;
        }
        public DataTable DanhSachPhieuQuaHan()
        {
            return LoadData.ExecuteQuery("EXEC sp_DanhSachPhieuQuaHan");
        }

        public DataTable XemDanhSach_CuonSach_ChiTiet()
        {
            return LoadData.ExecuteQuery("EXEC sp_XemDanhSach_CuonSach_ChiTiet");
        }

        public DataTable XemDanhSach_CuonSach_ChiTiet_SapXep()
        {
            return LoadData.ExecuteQuery("EXEC sp_XemDanhSach_CuonSach_ChiTiet_SapXep");
        }
        public DataTable XemCuonSach_Filter(string tacGia = null, string theLoai = null)
        {
            var prms = new[]
            {
                new SqlParameter("@tacGia", (object)tacGia ?? DBNull.Value),
                new SqlParameter("@theLoai", (object)theLoai ?? DBNull.Value)
            };

            return LoadData.ExecuteQuerySP("sp_XemCuonSach_Filter", prms);
        }

        public DataTable DsTaiKhoan()
        {
            return LoadData.ExecuteQuery("EXEC sp_DsTaiKhoan");
        }

        public bool TaoTaiKhoanDocGia(string maNguoi, string userName, string passWord, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                // luôn kèm schema dbo để tránh nhầm default schema
                string sp = "dbo.sp_TaoTaiKhoanDocGia";

                var prms = new[]
                {
            new SqlParameter("@maNguoi", maNguoi),
            new SqlParameter("@userName", userName),
            new SqlParameter("@passWord", passWord)
        };

                // gọi hàm thực thi NonQuery
                LoadData.ExecuteNonQuerySP(sp, prms);
                return true;
            }
            catch (SqlException ex)
            {
                // log chi tiết lỗi để biết chính xác vấn đề quyền gì bị thiếu
                errorMessage = $"SQL {ex.Number} (State {ex.State}) in {ex.Procedure} -> {ex.Message}";
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool XoaTaiKhoan(string userName, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string sp = "sp_XoaTaiKhoan"; // tên stored procedure bên SQL Server
                var prms = new[]
                {
                    new SqlParameter("@userName", userName)
                };

                LoadData.ExecuteNonQuerySP(sp, prms); // thực thi SP
                return true;
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi hệ thống: " + ex.Message;
                return false;
            }
        }

        public bool DoiMatKhau(string userName, string oldPassword, string newPassword, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string sp = "sp_DoiMatKhau";
                var prms = new[]
                {
            new SqlParameter("@userName", userName),
            new SqlParameter("@oldPassword", oldPassword),
            new SqlParameter("@newPassword", newPassword)
        };

                LoadData.ExecuteNonQuerySP(sp, prms);
                return true;
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public DataTable XemDsChiTietPhieuMuon(int? soPhieu, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string sp = "sp_XemDsChiTietPhieuMuon"; // tên stored procedure
                var prms = new[]
                {
                    new SqlParameter("@soPhieu", (object)soPhieu ?? DBNull.Value)
                };

                // Hàm này sẽ trả về DataTable
                return LoadData.ExecuteQuerySP(sp, prms);
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message;
                return null;
            }
        }
        public bool ThemDocGia(string hoTen, string gioiTinh, DateTime ngaySinh, string diaChi, string sdt, string email, string cccd, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                var prms = new[]
                {
                    new SqlParameter("@hoTen", hoTen),
                    new SqlParameter("@gioiTinh", gioiTinh),
                    new SqlParameter("@ngaySinh", ngaySinh),
                    new SqlParameter("@diaChi", (object)diaChi ?? DBNull.Value),
                    new SqlParameter("@SDT", (object)sdt ?? DBNull.Value),
                    new SqlParameter("@Email", (object)email ?? DBNull.Value),
                    new SqlParameter("@CCCD", cccd)
                };

                LoadData.ExecuteNonQuerySP("sp_ThemDocGia", prms);
                return true;
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
        public DataTable XemDSThanhVien()
        {
            return LoadData.ExecuteQuery("EXEC sp_XemDanhSachThanhVien");
        }
    }
}
