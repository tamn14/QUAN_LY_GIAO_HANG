using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyGiaoHang.DTO
{
    public class NhaPhanPhoi
    {
        public int maNPP {  get; set; }
        public string tenNPP { get; set; }
        public string diaChi { get; set; }
        public string SDT { get; set; }
        public string email { get; set; }
        public NhaPhanPhoi() { }
        public NhaPhanPhoi(int maNPP, string tenNPP, string diaChi, string sDT, string email)
        {
            this.maNPP = maNPP;
            this.tenNPP = tenNPP;
            this.diaChi = diaChi;
            SDT = sDT;
            this.email = email;
        }
    }
}
