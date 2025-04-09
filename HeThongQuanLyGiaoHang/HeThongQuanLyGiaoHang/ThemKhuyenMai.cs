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
    public partial class ThemKhuyenMai : Form
    {
        public ThemKhuyenMai()
        {
            InitializeComponent();
        }

        public int InsertKhuyenMai()
        {
            string tenkh = txb_tenKm_formTKH.Text; 
            Decimal pTramMienGiam = Convert.ToDecimal(txb_ptramKM_FormTKM.Text);
            DateTime ngayBatDau = dt_TGBD_formTKM.Value;  
            DateTime ngayKetThuc = dt_TGKT_formTKM.Value; 
            KhuyenMai khuyenMai = new KhuyenMai();

            khuyenMai.tenKM = tenkh;
            khuyenMai.PhanTramGiamGia = pTramMienGiam; 
            khuyenMai.ngayBatDau = ngayBatDau;
            khuyenMai.ngayKetThuc = ngayKetThuc; 

            int ckeck = KhuyenMaiDAO.Instance.ThemKhuyenMai(khuyenMai);
            return ckeck; 


        }

        private void button_capnhat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thêm khuyến mãi này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                MessageBox.Show("Bạn đã hủy thao tác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            if (!decimal.TryParse(txb_ptramKM_FormTKM.Text, out decimal pTramMienGiam))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số cho phần trăm khuyến mãi!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pTramMienGiam < 0 || pTramMienGiam > 100)
            {
                MessageBox.Show("Phần trăm miễn giảm phải nằm trong khoảng từ 0 đến 100%!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngayBatDau = dt_TGBD_formTKM.Value;
            DateTime ngayKetThuc = dt_TGKT_formTKM.Value;

            if (ngayBatDau > ngayKetThuc)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int check = InsertKhuyenMai();
                MessageBox.Show(check != -1 ? "Thêm khuyến mãi thành công!" : "Thêm khuyến mãi thất bại!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                check != -1 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                if (check != -1)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm khuyến mãi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
