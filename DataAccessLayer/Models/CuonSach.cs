using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class CuonSach
    {
        public int maCuonSach { get; set; }
        public int maTuaSach { get; set; }
        public string tinhTrang { get; set; }
        public string viTri { get; set; }

        // Mở rộng
        public string tenTuaSach { get; set; }
    }
}
