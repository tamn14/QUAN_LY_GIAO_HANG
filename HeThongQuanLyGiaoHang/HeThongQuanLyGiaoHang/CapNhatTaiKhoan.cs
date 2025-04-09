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
    public partial class CapNhatTaiKhoan : Form
    {
        private NguoiDung nguoiDung;  

        public CapNhatTaiKhoan(NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
            loadData(); 
        }


        public void loadData()
        {
            txb_TDN_FormCNTK.Text = nguoiDung.TenDangNhap; 

        }
        public int Save_Event()
        {
            string TDN = txb_TDN_FormCNTK.Text.Trim();
            string matKhauCu = txb_MK_CNTK.Text.Trim();
            string matKhauMoi = txb_MKM_FormCNTK.Text.Trim();
            string matKhauMoiNhapLai = txb_NLMK_FormCNTK.Text.Trim();

            NguoiDung nguoiDungCapNhat = new NguoiDung();
            nguoiDungCapNhat.TenDangNhap = TDN;
            nguoiDungCapNhat.maNguoiDung = nguoiDung.maNguoiDung;

            if (string.IsNullOrWhiteSpace(matKhauCu))
            {
                return NguoiDungDAO.Instance.UpdateUserName(nguoiDungCapNhat);
            }

            if (matKhauCu != nguoiDung.MatKhau)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác, vui lòng nhập lại!");
                return -1;
            }

            if (string.IsNullOrWhiteSpace(matKhauMoi) || string.IsNullOrWhiteSpace(matKhauMoiNhapLai))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới và xác nhận lại!");
                return -1;
            }

            if (matKhauMoiNhapLai != matKhauMoi)
            {
                MessageBox.Show("Mật khẩu mới nhập lại không khớp với mật khẩu mới, vui lòng nhập lại ");
                return -1;
            }

            nguoiDungCapNhat.MatKhau = matKhauMoi;
            return NguoiDungDAO.Instance.UpdateUser(nguoiDungCapNhat);
        }

        private void btn_luu_formCNTK_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thay đổi thông tin tài khoản không?",
                                           "Xác nhận lưu",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int check = Save_Event();
                MessageBox.Show(check != -1 ? "Cập nhật thông tin thành công!" : "Cập nhật thất bại!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                check != -1 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Bạn đã hủy thao tác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




    }
}
