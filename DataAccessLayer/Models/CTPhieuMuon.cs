using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class CTPhieuMuon
    {
        public int soPhieu { get; set; }
        public int maCuonSach { get; set; }
        public string trangThai { get; set; }
        public DateTime? ngayTra { get; set; }
        public int? soNgayTre { get; set; }
        public string ghiChu { get; set; }

        // Mở rộng
        public string tenTuaSach { get; set; }
    }
}
