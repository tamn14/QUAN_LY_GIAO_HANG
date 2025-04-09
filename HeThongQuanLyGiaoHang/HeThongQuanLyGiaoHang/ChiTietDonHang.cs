using HeThongQuanLyGiaoHang.DAO;
using HeThongQuanLyGiaoHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyGiaoHang
{
    public partial class ChiTietDonHang : Form
    {
        private DonHang donHang; 
        public ChiTietDonHang(DonHang donHang)
        {
            InitializeComponent();
            this.donHang = donHang;
            loadCTDH(); 
        }

        public ChiTiet_DonHang chiTietDonHang()
        {
            ChiTiet_DonHang chiTiet_DonHang = new ChiTiet_DonHang();
            chiTiet_DonHang = ChiTiet_DonHangDao.Instance.getCTDH(donHang.MaDH);
            int maSP = ChiTiet_DonHangDao.Instance.getMaSP(donHang.MaDH); 
            SanPham sanPham = SanPhamDAO.Instance.getSP(maSP);
            ChiTiet_DonHang CTDH = new ChiTiet_DonHang(donHang, sanPham, chiTiet_DonHang.soLuong, chiTiet_DonHang.giaBan, chiTiet_DonHang.thanhTien, chiTiet_DonHang.khoiLuong);
            return CTDH; 
        }

        public void loadCTDH()
        {
            ChiTiet_DonHang chiTiet_DonHang = chiTietDonHang();
            NhaPhanPhoi nhaPhanPhoi = NhaPhanPhoiDAO.Instance.getNhaPhanPhoi(donHang.MaDH); 
            lb_madh_formCTDH.Text = chiTiet_DonHang.DonHang.MaDH.ToString();
            lb_tensp_formCTDH.Text = chiTiet_DonHang.SanPham.TenSP;

            lb_SL_FormCTDH.Text = chiTiet_DonHang.soLuong.ToString();

            lb_giaban_formCTDH.Text = $"{chiTiet_DonHang.giaBan:N0} VND";
            lb_thanhtien_formCTDH.Text = $"{chiTiet_DonHang.thanhTien:N0} VND";

            lb_khoiluong_formCTDH.Text = chiTiet_DonHang.khoiLuong.ToString();

            lb_MoTa_FormCTDH.Text = chiTiet_DonHang.SanPham.Mota;

            lb_thm_FormCTDH.Text = chiTiet_DonHang.SanPham.thoiDiemMua.ToString("dd/MM/yyyy");

            lb_nhaPP_formCTDH.Text = nhaPhanPhoi.tenNPP; 


        }

    }
}
