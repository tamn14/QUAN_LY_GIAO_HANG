using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyGiaoHang.DTO
{
    public class LichSuGiaoHang
    {
        public int MaLS { get; set; }
        public DonHang MaDH { get; set; }
        public DateTime ThoiGianCapNhat { get; set; }
        public int TrangThaiMoi { get; set; }
        public int LanGiao { get; set; }
        public LichSuGiaoHang( DonHang maDH, DateTime thoiGianCapNhat, int trangThaiMoi, int lanGiao)
        {
           
            MaDH = maDH;
            ThoiGianCapNhat = thoiGianCapNhat;
            TrangThaiMoi = trangThaiMoi;
            LanGiao = lanGiao;
        }
    }
}
