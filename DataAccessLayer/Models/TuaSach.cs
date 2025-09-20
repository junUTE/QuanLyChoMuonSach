using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class TuaSach
    {
        public int maTuaSach { get; set; }
        public string tenTuaSach { get; set; }
        public string tacGia { get; set; }
        public string theLoai { get; set; }
        public string nhaXuatBan { get; set; }
        public int? namXuatBan { get; set; }
        public decimal? donGia { get; set; }
    }
}
