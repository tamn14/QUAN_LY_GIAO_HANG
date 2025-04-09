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
    public partial class CapNhatTrangThaiDonHang : Form
    {
        private DonHang donHang;
        private NguoiDung nguoiDung; 
        public CapNhatTrangThaiDonHang(DonHang donHang, NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.donHang = donHang;
            LoadDonHang();
            this.nguoiDung = nguoiDung;
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
        public KhachHang khachHang()
        {
            KhachHang khachHang = new KhachHang();
            int maKh = DonHangDAO.Instance.getMaKH(donHang.MaDH);
            KhachHang KH = KhachHangDAO.Instance.getKH(maKh);
            return KH;  

        }

        public void LoadDonHang()
        {
            ChiTiet_DonHang chiTiet_DonHang = chiTietDonHang();
            KhachHang kh = khachHang(); 
            lb_madh_formCNTTGH.Text = chiTiet_DonHang.DonHang.MaDH.ToString(); 
            lb_tensp_formCNTTGH.Text = chiTiet_DonHang.SanPham.TenSP.ToString();
            lb_tenkh_formCNTTGH.Text = kh.TenKH; 
        }

        public int UpdateDonHang()
        {
            // Kiểm tra xem comboBox1 có giá trị hợp lệ không
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1; // Không thực hiện cập nhật nếu chưa chọn giá trị
            }

            string trangThai = comboBox1.Text; 
            int trangThaiDonHang = (trangThai == "Thành Công") ? 1 : 2;

            // Kiểm tra `donHang` có hợp lệ không
            if (donHang == null)
            {
                MessageBox.Show("Dữ liệu đơn hàng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            // Gọi cập nhật lịch sử giao hàng
            int check = LichSuGHDAO.Instance.UpdateLSGH(donHang.MaDH, trangThaiDonHang);

            // Trả về kết quả cập nhật
            return check;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string trangThai = comboBox1.Text;
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn cập nhât đơn hàng này không?\n\nTrạng thái giao hàng : **{trangThai.ToUpper()}**",
                "Xác nhận lưu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int check = UpdateDonHang();
                MessageBox.Show(check != -1 ? "Cập nhật thành công!" : "Cập nhật thất bại!",
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
