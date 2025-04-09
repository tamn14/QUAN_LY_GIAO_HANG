using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyGiaoHang.DTO
{
    public class KhachHang

    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; } 
        public KhachHang( string tenKH, string soDienThoai, string diaChi)
        {
            TenKH = tenKH;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
        }

        public KhachHang() { }
    }
}
