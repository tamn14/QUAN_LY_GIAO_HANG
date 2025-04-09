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
    public partial class CapNhatNhanVienGiaoHangAdmin : Form
    {
        private NguoiDung nguoiDung1; 
        public CapNhatNhanVienGiaoHangAdmin(NguoiDung nguoiDung)
        {
            this.nguoiDung1 = nguoiDung; 
            InitializeComponent();
            setDataNguoiDung(); 
        }

        public int CapNhatNhanVienGiaoHang()
        {

            string tenNhanVien = txb_tenNVGHFormCNVGHA.Text.Trim();
            string SDT = txb_SDTFormCNVGHA.Text.Trim();
            string email = txb_email_formCNVGHA.Text.Trim();
            string cccd = txb_CCCD_formCNVGHA.Text.Trim();
            string diaChi = txb_diachiFormCNVGHA.Text.Trim();
            DateTime ngaySinh = dateTimePicker2_formCNNVGH.Value;

            NguoiDung nguoiDung = new NguoiDung();
            nguoiDung.maNguoiDung = nguoiDung1.maNguoiDung; 
            nguoiDung.ten = tenNhanVien;
            nguoiDung.SDT = SDT;
            nguoiDung.email = email;
            nguoiDung.cccd = cccd;
            nguoiDung.diaChi = diaChi;
            nguoiDung.ngaySinh = ngaySinh;

            int check = NhanVienGiaoHangDAO.Instance.CapNhatNhanVienGiaoHang(nguoiDung);
            
            return check;





        }

        public void setDataNguoiDung()
        {
            txb_tenNVGHFormCNVGHA.Text = nguoiDung1.ten; 
            txb_SDTFormCNVGHA.Text = nguoiDung1.SDT;
            txb_email_formCNVGHA.Text = nguoiDung1.email;
            txb_diachiFormCNVGHA.Text = nguoiDung1.diaChi;  
            txb_CCCD_formCNVGHA.Text = nguoiDung1.cccd;
            dateTimePicker2_formCNNVGH.Value = nguoiDung1.ngaySinh; 
        }

        private void button_themNVGHA_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               $"Bạn có chắc chắn muốn cập nhật nhân viên này không? ",
               "Xác nhận lưu",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int check = CapNhatNhanVienGiaoHang();
                MessageBox.Show(check != -1 ? " cập nhật nhân viên thành công!" : "cập nhật nhân viên thất bại!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                check != -1 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                this.Close();

            }
            else
            {
                MessageBox.Show("Bạn đã hủy thao tác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
    }
}
