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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HeThongQuanLyGiaoHang
{
    public partial class ThongTinTaiKhoan : Form
    {
        private NguoiDung nguoiDung;
        public ThongTinTaiKhoan(NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
            loadData();
        }

      

        public void loadData()
        {
            lb_ten_FormTTTK.Text = nguoiDung.ten;
            lb_sdt_formTTTK.Text = nguoiDung.SDT;
            lb_email_FormTTTK.Text = nguoiDung.email;
            lb_cccd_formTTTK.Text = nguoiDung.cccd;
            lb_dc_formTTTK.Text = nguoiDung.diaChi;
            lb_vaitro_formTTTK.Text = (nguoiDung.VaiTro == 1) ? "Quản Lý" : "Nhân Viên Giao Hàng";
            lb_TDN_formTTTK.Text = nguoiDung.TenDangNhap;
            lb_mk_formTTTK.Text = new string('*', nguoiDung.MatKhau.Length);

        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_CN_FormTTTK_Click(object sender, EventArgs e)
        {
            CapNhatTaiKhoan capNhatTaiKhoan = new CapNhatTaiKhoan(nguoiDung);
            capNhatTaiKhoan.ShowDialog();
        }
    }
}
