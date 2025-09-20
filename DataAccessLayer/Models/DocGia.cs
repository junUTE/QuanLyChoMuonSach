using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class DocGia
    {
        public string maDocGia { get; set; }
        public string maNguoi { get; set; }
        public DateTime ngayDangKy { get; set; }
        public DateTime? hanTaiKhoan { get; set; }

        // Thông tin mở rộng (JOIN từ Nguoi)
        public string hoTen { get; set; }
        public string email { get; set; }
        public string SDT { get; set; }
    }
}
