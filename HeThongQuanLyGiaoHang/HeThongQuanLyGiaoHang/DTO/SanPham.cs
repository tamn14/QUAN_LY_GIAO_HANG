using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyGiaoHang.DTO
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string  Mota { get; set; }
        public DateTime thoiDiemMua { get; set; }

        public SanPham ()
        {
           
        }
        public SanPham(int maSP, string tenSP, string mota, DateTime thoiDiemMua)
        {
            MaSP = maSP;
            TenSP = tenSP;
            Mota = mota;
            this.thoiDiemMua = thoiDiemMua;
        }
    }
}
