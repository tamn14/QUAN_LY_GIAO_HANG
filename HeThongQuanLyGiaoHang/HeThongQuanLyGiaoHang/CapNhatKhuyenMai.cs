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
    public partial class CapNhatKhuyenMai : Form
    {
        private KhuyenMai khuyenMai;  
        public CapNhatKhuyenMai(KhuyenMai khuyenMai)
        {
            InitializeComponent();
            this.khuyenMai = khuyenMai;
            setData(); 
        }

        public void setData()
        {
            txb_tenKm_formCNKH.Text = khuyenMai.tenKM;
            txb_ptramKM_FormCNKM.Text = khuyenMai.PhanTramGiamGia.ToString();
            // Định dạng DateTimePicker theo dd/MM/yyyy
            dt_TGBD_formCNKM.Format = DateTimePickerFormat.Custom;
            dt_TGBD_formCNKM.CustomFormat = "dd/MM/yyyy";

            dt_TGKT_formCNKM.Format = DateTimePickerFormat.Custom;
            dt_TGKT_formCNKM.CustomFormat = "dd/MM/yyyy";

            // Gán giá trị ngày
            dt_TGBD_formCNKM.Value = khuyenMai.ngayBatDau;
            dt_TGKT_formCNKM.Value = khuyenMai.ngayKetThuc;


        }

        public int CapNhat()
        {
            string tenkh = txb_tenKm_formCNKH.Text;
            Decimal pTramMienGiam = Convert.ToDecimal(txb_ptramKM_FormCNKM.Text);
            DateTime ngayBatDau = dt_TGBD_formCNKM.Value;
            DateTime ngayKetThuc = dt_TGKT_formCNKM.Value;
            KhuyenMai khuyenMai1 = new KhuyenMai();

            khuyenMai1.tenKM = tenkh;
            khuyenMai1.PhanTramGiamGia = pTramMienGiam;
            khuyenMai1.ngayBatDau = ngayBatDau;
            khuyenMai1.ngayKetThuc = ngayKetThuc;
            khuyenMai1.MaKM = khuyenMai.MaKM;



            int ckeck = KhuyenMaiDAO.Instance.CapNhatKhuyenMai(khuyenMai1);
            return ckeck;
        }

        private void button_capnhat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn cập nhật khuyến mãi này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                MessageBox.Show("Bạn đã hủy thao tác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            if (!decimal.TryParse(txb_ptramKM_FormCNKM.Text, out decimal pTramMienGiam))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số cho phần trăm khuyến mãi!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pTramMienGiam < 0 || pTramMienGiam > 100)
            {
                MessageBox.Show("Phần trăm miễn giảm phải nằm trong khoảng từ 0 đến 100%!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngayBatDau = dt_TGBD_formCNKM.Value;
            DateTime ngayKetThuc = dt_TGKT_formCNKM.Value;

            if (ngayBatDau > ngayKetThuc)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int check = CapNhat();
                MessageBox.Show(check != -1 ? "Cập nhật khuyến mãi thành công!" : "Cập nhật khuyến mãi thất bại!",
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
