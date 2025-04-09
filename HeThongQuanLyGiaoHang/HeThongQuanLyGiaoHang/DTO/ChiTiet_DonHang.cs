using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyGiaoHang.DTO
{
    public class ChiTiet_DonHang
    {
        public DonHang DonHang { get; set; }
        public SanPham SanPham { get; set; }
        public int soLuong { get; set; }
        public decimal giaBan {  get; set; }
        public decimal thanhTien { get; set; }
        public decimal khoiLuong { get; set; }

       public ChiTiet_DonHang() { }
       public ChiTiet_DonHang(DonHang donHang, SanPham sanPham, int soLuong, decimal giaBan, decimal thanhTien, decimal khoiLuong)
        {
            DonHang = donHang;
            SanPham = sanPham;
            this.soLuong = soLuong;
            this.giaBan = giaBan;
            this.thanhTien = thanhTien;
            this.khoiLuong = khoiLuong;
        }
    }
}
