using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class PhieuMuon
    {
        public int soPhieu { get; set; }
        public string maDocGia { get; set; }
        public string maNhanVien { get; set; }
        public DateTime ngayMuon { get; set; }
        public DateTime ngayHenTra { get; set; }
        public string trangThai { get; set; }
        public DateTime? ngayTra { get; set; }

        // Mở rộng
        public string tenDocGia { get; set; }
        public string tenNhanVien { get; set; }
    }
}
