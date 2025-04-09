using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyGiaoHang.DTO
{
    public class Kho
    {
        public int MaK { get; set; }
        public string TenK { get; set; }
        public string DiaChiK { get; set; }
        public Kho( string tenK, string diaChiK)
        {
            TenK = tenK;
            DiaChiK = diaChiK;
        }
    }
}
