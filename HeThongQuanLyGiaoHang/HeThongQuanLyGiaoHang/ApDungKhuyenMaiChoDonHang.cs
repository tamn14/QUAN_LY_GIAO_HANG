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
    public partial class ApDungKhuyenMaiChoDonHang : Form
    {
        private DonHang donHang; 

        public ApDungKhuyenMaiChoDonHang(DonHang donHang)
        {
            InitializeComponent();
            this.donHang = donHang;
            LoadKM(); 
            

        }


        public void LoadKM()
        {
            List<KhuyenMai> list = KhuyenMaiDAO.Instance.getKhuyenMai();

            // Tắt sự kiện trước khi gán DataSource
            cb_tenkhuyenmaiFormADKMCDH.SelectedIndexChanged -= cb_tenkhuyenmaiFormADKMCDH_SelectedIndexChanged;

            cb_tenkhuyenmaiFormADKMCDH.DataSource = list;
            cb_tenkhuyenmaiFormADKMCDH.DisplayMember = "tenKM";
            cb_tenkhuyenmaiFormADKMCDH.ValueMember = "maKM";

            if (cb_tenkhuyenmaiFormADKMCDH.Items.Count > 0)
            {
                txb_makm_formADKMCDH.Text = cb_tenkhuyenmaiFormADKMCDH.SelectedValue.ToString();
            }

            // Kích hoạt lại sự kiện
            cb_tenkhuyenmaiFormADKMCDH.SelectedIndexChanged += cb_tenkhuyenmaiFormADKMCDH_SelectedIndexChanged;

            // Load dữ liệu ban đầu
            loadData();
        }

        private void cb_tenkhuyenmaiFormADKMCDH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_tenkhuyenmaiFormADKMCDH.SelectedValue != null)
            {
                // Chỉ cập nhật khi giá trị thay đổi
                if (txb_makm_formADKMCDH.Text != cb_tenkhuyenmaiFormADKMCDH.SelectedValue.ToString())
                {
                    txb_makm_formADKMCDH.Text = cb_tenkhuyenmaiFormADKMCDH.SelectedValue.ToString();
                }
                loadData();
            }
        }

        private void txb_makm_formADKMCDH_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txb_makm_formADKMCDH.Text, out int maKm))
            {
                bool found = false;

                for (int i = 0; i < cb_tenkhuyenmaiFormADKMCDH.Items.Count; i++)
                {
                    KhuyenMai khuyenMai = (KhuyenMai)cb_tenkhuyenmaiFormADKMCDH.Items[i];
                    if (khuyenMai.MaKM == maKm)
                    {
                        cb_tenkhuyenmaiFormADKMCDH.SelectedIndex = i;
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    loadData();
                }
                else
                {
                    MessageBox.Show("Mã khuyến mãi không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txb_makm_formADKMCDH.Clear();
                }
            }
        }

        public void loadData()
        {
            if (!int.TryParse(txb_makm_formADKMCDH.Text, out int makm))
            {
                MessageBox.Show("Mã khuyến mãi không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhuyenMai khuyenMai = KhuyenMaiDAO.Instance.loadKhuyenMaiByID(makm);

            if (khuyenMai == null)
            {
                MessageBox.Show("Không tìm thấy khuyến mãi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lb_ptramgiam_formADKMDH.Text = khuyenMai.PhanTramGiamGia.ToString("0.##") + " %";
            lb_TGBDFormADKMDH.Text = khuyenMai.ngayBatDau.ToString("dd/MM/yyyy");
            lb_TGKTFormADKMDH.Text = khuyenMai.ngayKetThuc.ToString("dd/MM/yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Bạn có chắc chắn muốn thêm khuyến mãi cho đơn hàng này không?",
               "Xác nhận",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                MessageBox.Show("Bạn đã hủy thao tác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

         
           
            try
            {
                int makm = Convert.ToInt32(txb_makm_formADKMCDH.Text);
                int madh = donHang.MaDH; 

                int check = ChiTiet_KhuyenMaiDao.Instance.Insert(makm, madh);   
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

        private void button_capnhat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Bạn có chắc chắn muốn xóa khuyến mãi cho đơn hàng này không?",
               "Xác nhận",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                MessageBox.Show("Bạn đã hủy thao tác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kiểm tra mã khuyến mãi nhập vào có hợp lệ không
                if (!int.TryParse(txb_makm_formADKMCDH.Text, out int makm))
                {
                    MessageBox.Show("Mã khuyến mãi không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra đơn hàng có tồn tại không
                if (donHang == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int madh = donHang.MaDH;

                // Kiểm tra xem đơn hàng có khuyến mãi không
                int count = ChiTiet_KhuyenMaiDao.Instance.check(madh);
                if (count < 0)
                {
                    MessageBox.Show("Lỗi khi kiểm tra khuyến mãi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (count == 0)
                {
                    MessageBox.Show("Khuyến mãi chưa tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thực hiện xóa khuyến mãi
                int check = ChiTiet_KhuyenMaiDao.Instance.Remove(madh);
                if (check > 0)
                {
                    MessageBox.Show("Xóa khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Xóa khuyến mãi thất bại hoặc không tìm thấy khuyến mãi cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa khuyến mãi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
