using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyGiaoHang.DTO
{
    public class NguoiDung
    {
        public int maNguoiDung {  get; set; }   
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int VaiTro { get; set; }
        public string ten {  get; set; }    
        public string SDT { get; set; } 
        public string email {  get; set; }
        public string cccd { get; set; }
        public string diaChi {  get; set; }
        public bool VoHieuHoa { get; set; }

        public string GhiChu { get; set; }
        public DateTime ngaySinh { get; set; }
        public NguoiDung(string tenDangNhap, string matKhau, int vaiTro, bool voHieuHoa, string ghichu, int maNguoiDung, string ten, string sDT, string email, string cccd, string diaChi ,DateTime ngaySinh )
        {
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            VaiTro = vaiTro;
            VoHieuHoa = voHieuHoa;
            GhiChu = ghichu;
            this.maNguoiDung = maNguoiDung;
            this.ten = ten;
            SDT = sDT;
            this.email = email;
            this.cccd = cccd;
            this.diaChi = diaChi;
            this.ngaySinh = ngaySinh;
        }

        public NguoiDung()
        {
          
         
        }
    }
}
