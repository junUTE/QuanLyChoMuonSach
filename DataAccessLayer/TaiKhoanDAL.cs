using System;
using System.Data;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class TaiKhoanDAL
    {
        public TaiKhoan Login(string username, string password)
        {
            string sql = "EXEC sp_Login @param0, @param1";
            DataTable dt = LoadData.ExecuteQuery(sql, new object[] { username, password });

            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                return new TaiKhoan
                {
                    maTaiKhoan = row["maTaiKhoan"].ToString(),
                    maNguoi = row["maNguoi"].ToString(),
                    userName = row["userName"].ToString(),
                    passWord = row["passWord"].ToString(),
                    hanTaiKhoan = row["hanTaiKhoan"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["hanTaiKhoan"]),
                    vaiTro = row.Table.Columns.Contains("vaiTro") ? row["vaiTro"].ToString() : null,
                    hoTen = row.Table.Columns.Contains("hoTen") ? row["hoTen"].ToString() : null,
                    gioiTinh = row.Table.Columns.Contains("gioiTinh") ? row["gioiTinh"].ToString() : null,
                    SDT = row.Table.Columns.Contains("SDT") ? row["SDT"].ToString() : null,
                    email = row.Table.Columns.Contains("email") ? row["email"].ToString() : null,
                    cccd = row.Table.Columns.Contains("cccd") ? row["cccd"].ToString() : null,
                    diaChi = row.Table.Columns.Contains("diaChi") ? row["diaChi"].ToString() : null,
                    ngaySinh = row.Table.Columns.Contains("ngaySinh") && row["ngaySinh"] != DBNull.Value
                                ? Convert.ToDateTime(row["ngaySinh"])
                                : (DateTime?)null
                };
            }
            return null;
        }

        public string GetRole(string maNguoi)
        {
            string sql = "SELECT vaiTro FROM Nguoi WHERE maNguoi=@param0";
            DataTable dt = LoadData.ExecuteQuery(sql, new object[] { maNguoi });
            return dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : null;
        }
    }
}
