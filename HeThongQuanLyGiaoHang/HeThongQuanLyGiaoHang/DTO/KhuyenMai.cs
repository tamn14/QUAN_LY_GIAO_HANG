using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyGiaoHang.DTO
{
    public class KhuyenMai
    {
        public int MaKM { get; set; }
        public string tenKM { get; set; }
        public decimal PhanTramGiamGia { get; set; }
        public DateTime ngayBatDau { get; set; }
        public DateTime ngayKetThuc {  get; set; }
        public KhuyenMai() { }
        public KhuyenMai(int maKM, string tenKM, decimal phanTramGiamGia, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            MaKM = maKM;
            this.tenKM = tenKM;
            PhanTramGiamGia = phanTramGiamGia;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
        }
    }
}
