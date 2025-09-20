using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Nguoi
    {
        public string maNguoi { get; set; }
        public string hoTen { get; set; }
        public string gioiTinh { get; set; }
        public DateTime? ngaySinh { get; set; }
        public string diaChi { get; set; }
        public string SDT { get; set; }
        public string email { get; set; }
        public string cccd { get; set; }
        public string vaiTro { get; set; }
    }
}
