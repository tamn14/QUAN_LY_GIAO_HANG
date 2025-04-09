using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyGiaoHang.DTO
{
    public class ChiTiet_KhuyenMai
    {
        public DonHang DonHang { get; set; }
        public KhuyenMai KhuyenMai { get; set; }
        public ChiTiet_KhuyenMai() { }
        public ChiTiet_KhuyenMai(DonHang donHang, KhuyenMai khuyenMai)
        {
            DonHang = donHang;
            KhuyenMai = khuyenMai;
        }
    }
}
