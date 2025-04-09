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
    public partial class HeThongQuanLy : Form
    {
        private NguoiDung nguoiDung;
        public HeThongQuanLy(NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
            KiemTraQuyen(); 
        }
        public void KiemTraQuyen()
        {
            if (this.nguoiDung.VaiTro == 1)
            {
                ShowToolStripForRole1();
            }

            else if (this.nguoiDung.VaiTro == 2)
            {
                ShowToolStripForRole2();
            }

           
        }

       
        public void ShowToolStripForRole1()
        {
           ShipperToolStripMenuItem.Visible = false;
            QuanlyToolStripMenuItem.Visible = true;
        }

        public void ShowToolStripForRole2()
        {

            ShipperToolStripMenuItem.Visible = true;
            QuanlyToolStripMenuItem.Visible = false;
        }

        private void ThongTinTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ThongTinTaiKhoanToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
        }

        private void ThongTinTaiKhoanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ThongTinTaiKhoan thongTinTaiKhoan = new ThongTinTaiKhoan(nguoiDung);
            thongTinTaiKhoan.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cậpNhậtĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapNhatDonHang capNhatDonHang = new CapNhatDonHang(nguoiDung); 
            capNhatDonHang.ShowDialog();
        }

        private void thôngTinĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
           LichSuGH lichSuGH = new LichSuGH(nguoiDung);
            lichSuGH.ShowDialog();  
        }

        private void đơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DonHangAdmin donHangAdmin = new DonHangAdmin(nguoiDung); 
            donHangAdmin.ShowDialog();  
              
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SanPhamAdmin sanPham = new SanPhamAdmin();
            sanPham.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachHangAdmin khachHangAdmin = new KhachHangAdmin();   
            khachHangAdmin.ShowDialog();    

        }

        private void nhânViênGiaoHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NhanVienGiaoHangAdmin nhanVienGiaoHangAdmin = new NhanVienGiaoHangAdmin();
            nhanVienGiaoHangAdmin.ShowDialog();
        }

        private void lịchSửGiaoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LichSuGiaoHangAdmin lich = new LichSuGiaoHangAdmin();
            lich.ShowDialog();

        }

        private void QuanlyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void báoCáoThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void khuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhuyenMaiAdmin khuyenMai = new KhuyenMaiAdmin();
            khuyenMai.ShowDialog(); 
        }

        private void HeThongQuanLy_Load(object sender, EventArgs e)
        {

        }

        private void nhàPhânPhốiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhaPhanPhoiAdmin nhaPhanPhoi = new NhaPhanPhoiAdmin();    
            nhaPhanPhoi.ShowDialog();   
        }
    }
}
