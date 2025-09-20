using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class TaiKhoan
    {
        public string maTaiKhoan { get; set; }
        public string maNguoi { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public string vaiTro { get; set; }
        public DateTime? hanTaiKhoan { get; set; }

        // Nếu muốn hiển thị thêm thông tin từ bảng Nguoi (JOIN)
        public string hoTen { get; set; }
        public string gioiTinh { get; set; }
        public string SDT { get; set; }
        public string email { get; set; }
        public string cccd { get; set; }
        public string diaChi { get; set; }
        public DateTime? ngaySinh { get; set; }
    }
}
