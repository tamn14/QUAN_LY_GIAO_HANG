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
    
    public partial class VoHieuHoaNhanVienGiaoHangAdmin : Form
    {
        private NguoiDung nguoiDung; 
        public VoHieuHoaNhanVienGiaoHangAdmin(NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
            setData(); 
        }

        public void setData()
        {
            lb_maNVGHFormVHHNVGHA.Text = nguoiDung.maNguoiDung.ToString();
            lb_tenNVGH_formVHHNVGHA.Text = nguoiDung.ten; 
        }

        private void button_themNVGHA_Click(object sender, EventArgs e)
        {
            string Ghichu = txb_lydoFormVHHNVGHA.Text;

            DialogResult result = MessageBox.Show(
               $"Bạn có chắc chắn muốn vô hiệu hóa nhân viên này không? ",
               "Xác nhận lưu",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int check1 = DonHangDAO.Instance.CapNhatDonHang(nguoiDung);
                int check2 = NhanVienGiaoHangDAO.Instance.VoHieuHoa(1, Ghichu, nguoiDung);

                MessageBox.Show((check1 != -1 && check2 != -1) ? "Cập nhật nhân viên thành công!" : "Cập nhật nhân viên thất bại!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                (check1 != -1 && check2 != -1) ? MessageBoxIcon.Information : MessageBoxIcon.Error);
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
