using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyGiaoHang.DTO
{
    public class DonHang
    {
        public int MaDH { get; set; }
       
        public KhachHang MaKH { get; set; }
        public Kho MaK { get; set; }
        public NguoiDung nguoiDung { get; set; }
        public NhaPhanPhoi NhaPhanPhoi { get; set; }
        public decimal TongTien { get; set; }
        public int TrangThaiGH { get; set; }
        public DateTime NgayTao { get; set; }
        public string DiaChiGH { get; set; }
        public DateTime ngayGiao {get; set; }
        public decimal phiShip { get; set; }

       public DonHang(int maDH, KhachHang maKH, Kho maK, NguoiDung nguoiDung, NhaPhanPhoi nhaPhanPhoi, decimal tongTien, int trangThaiGH, DateTime ngayTao, string diaChiGH, DateTime ngayGiao, decimal phiShip)
        {
            MaDH = maDH;
            MaKH = maKH;
            MaK = maK;
            this.nguoiDung = nguoiDung;
            NhaPhanPhoi = nhaPhanPhoi;
            TongTien = tongTien;
            TrangThaiGH = trangThaiGH;
            NgayTao = ngayTao;
            DiaChiGH = diaChiGH;
            this.ngayGiao = ngayGiao;
            this.phiShip = phiShip;
        }

        public DonHang() { }

       
    }
}
