using HeThongQuanLyGiaoHang.DAO;
using HeThongQuanLyGiaoHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace HeThongQuanLyGiaoHang
{
    public partial class NhanVienGiaoHangAdmin : Form
    {

        
        public NhanVienGiaoHangAdmin()
        {
            InitializeComponent();
            loadData();
            setNhanVienGiaoHang();
            setCount();
        }

        public void loadData()
        {
            dataGridView1.DataSource = NhanVienGiaoHangDAO.Instance.loadNhanVienGiaoHang();
            dataGridView1.Columns[0].HeaderText = "Mã NVGH";
            dataGridView1.Columns[1].HeaderText = "Tên Đăng Nhập";
            dataGridView1.Columns[2].HeaderText = "Tên";
            dataGridView1.Columns[3].HeaderText = "Ngày Sinh";
            dataGridView1.Columns[4].HeaderText = "SDT";
            dataGridView1.Columns[5].HeaderText = "Email";
            dataGridView1.Columns[6].HeaderText = "CCCD";
            dataGridView1.Columns[7].HeaderText = "Địa Chỉ";
            dataGridView1.Columns[8].HeaderText = "Vô Hiệu Hóa";
            dataGridView1.Columns[9].HeaderText = "Ghi Chú";





            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].Width = 120;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Width = 120;
            dataGridView1.Columns[8].Width = 80;
            dataGridView1.Columns[9].Width = 200;

            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
        }

        public void setNhanVienGiaoHang()
        {
            lb_maNVGHFormNVGHA.DataBindings.Clear();    
            lb_tendangnhap_formNVGHA.DataBindings.Clear();
            lb_tenNVGH_formNVGHA.DataBindings.Clear();
            lb_sdt_formNVGHA.DataBindings.Clear();
            lb_email_formNVGHA.DataBindings.Clear();
            lb_CCCD_formNVGHA.DataBindings.Clear();
            lb_diachi_formNVGHA.DataBindings.Clear();
            lb_vohieuhoaformNVGHA.DataBindings.Clear();
            lb_lydo_formNVGHA.DataBindings.Clear();
            lb_ngaysinhformNCGHA.DataBindings.Clear();  

            lb_maNVGHFormNVGHA.DataBindings.Add("Text", dataGridView1.DataSource, "MANGUOIDUNG");
            lb_tenNVGH_formNVGHA.DataBindings.Add("Text", dataGridView1.DataSource, "TEN");
            lb_sdt_formNVGHA.DataBindings.Add("Text", dataGridView1.DataSource, "SODIENTHOAI");
            lb_email_formNVGHA.DataBindings.Add("Text", dataGridView1.DataSource, "EMAIL");

            lb_tendangnhap_formNVGHA.DataBindings.Add("Text", dataGridView1.DataSource, "TENDANGNHAP");
            lb_diachi_formNVGHA.DataBindings.Add("Text", dataGridView1.DataSource, "DIACHI");
            lb_CCCD_formNVGHA.DataBindings.Add("Text", dataGridView1.DataSource, "CCCD");


            Binding Vohieuhoa = new Binding("Text", dataGridView1.DataSource, "VOHIEUHOA", true);
            Vohieuhoa.Format += (s, e) =>
            {
                if (e.Value != null)
                {
                    switch (e.Value.ToString())
                    {
                        case "1":
                            e.Value = "Tài khoản nay đã bị vô hiệu hóa";
                            break;
                        case "0":
                            e.Value = "Không có";
                            break;
                      
                    }
                }
            };
            lb_vohieuhoaformNVGHA.DataBindings.Add(Vohieuhoa);


            Binding ghichu = new Binding("Text", dataGridView1.DataSource, "GHICHU", true);
            ghichu.Format += (s, e) =>
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    e.Value = e.Value.ToString(); 
                }
                else
                {
                    e.Value = "Chưa có";
                }
            };
            lb_lydo_formNVGHA.DataBindings.Add(ghichu);


            Binding ngaySInh = new Binding("Text", dataGridView1.DataSource, "NGAYSINH", true);
            ngaySInh.Format += (s, e) =>
            {
                if (e.Value != null && DateTime.TryParse(e.Value.ToString(), out DateTime date))
                {
                    e.Value = date.ToString("dd/MM/yyyy"); 
                }
                else
                {
                    e.Value = "Chưa có";
                }
            };
            lb_ngaysinhformNCGHA.DataBindings.Add(ngaySInh);

            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        public NguoiDung getNguoiDung()
        {
            int maNguoiDung = Convert.ToInt32(lb_maNVGHFormNVGHA.Text);
            string tenNguoidung = lb_tenNVGH_formNVGHA.Text;
            string sdt = lb_sdt_formNVGHA.Text;
            string email = lb_email_formNVGHA.Text;
            string cccd = lb_CCCD_formNVGHA.Text;
            string diachi = lb_diachi_formNVGHA.Text;
            string date = lb_ngaysinhformNCGHA.Text;
            DateTime ngaySinh;

            if (DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh))
            {
               
            }
            else
            {
                MessageBox.Show("Ngày sinh không hợp lệ! Vui lòng nhập đúng định dạng dd/MM/yyyy.");
            }

            NguoiDung nguoiDung = new NguoiDung();
            nguoiDung.maNguoiDung = maNguoiDung;
            nguoiDung.ten = tenNguoidung;
            nguoiDung.SDT = sdt;  
            nguoiDung.email = email;    
            nguoiDung.cccd = cccd;  
            nguoiDung.diaChi = diachi;
            nguoiDung.ngaySinh = ngaySinh;
             
            return nguoiDung;
        }


       

        private void button_capnhat_Click(object sender, EventArgs e)
        {
            ThemNhanVienGiaoHangAdmin themNhanVienGiaoHangAdmin = new ThemNhanVienGiaoHangAdmin();
            themNhanVienGiaoHangAdmin.ShowDialog();
            
            loadData();
            setNhanVienGiaoHang();


        }



        private void button2_Click(object sender, EventArgs e)
        {
            NguoiDung nguoiDung = getNguoiDung();  
            CapNhatNhanVienGiaoHangAdmin capNhatNhanVienGiaoHangAdmin = new CapNhatNhanVienGiaoHangAdmin(nguoiDung);  
            capNhatNhanVienGiaoHangAdmin.ShowDialog();  
            loadData();
            setNhanVienGiaoHang();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            NguoiDung nguoiDung = getNguoiDung();
            VoHieuHoaNhanVienGiaoHangAdmin voHieuHoaNhanVienGiaoHangAdmin = new VoHieuHoaNhanVienGiaoHangAdmin(nguoiDung);  
            voHieuHoaNhanVienGiaoHangAdmin.ShowDialog();
            loadData(); 
            setNhanVienGiaoHang () ;


        }


        private void button4_Click(object sender, EventArgs e)
        {
            string str = textBox3.Text;
            DataTable dataTable = NhanVienGiaoHangDAO.Instance.find(str);


            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].HeaderText = "Mã NVGH";
            dataGridView1.Columns[1].HeaderText = "Tên Đăng Nhập";
            dataGridView1.Columns[2].HeaderText = "Tên";
            dataGridView1.Columns[3].HeaderText = "Ngày Sinh";
            dataGridView1.Columns[4].HeaderText = "SDT";
            dataGridView1.Columns[5].HeaderText = "Email";
            dataGridView1.Columns[6].HeaderText = "CCCD";
            dataGridView1.Columns[7].HeaderText = "Địa Chỉ";
            dataGridView1.Columns[8].HeaderText = "Vô Hiệu Hóa";
            dataGridView1.Columns[9].HeaderText = "Ghi Chú";





            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].Width = 120;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Width = 120;
            dataGridView1.Columns[8].Width = 80;
            dataGridView1.Columns[9].Width = 200;

            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
            setNhanVienGiaoHang();

        }

        public int KiemDonHang()
        {
            NguoiDung nguoiDung = getNguoiDung();
            int soDonHoanThanh = NhanVienGiaoHangDAO.Instance.KiemTraDonHang(nguoiDung);  
            return soDonHoanThanh;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
              $"Bạn có chắc chắn muốn cập nhật nhân viên này không? ",
              "Xác nhận lưu",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (KiemDonHang() > 0)
                {
                    MessageBox.Show(" Không thể xóa người dùng này, vui lòng chọn chức năng VÔ HIỆU HÓA !",
                    "Thông báo",
                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                   
                }
                else
                {
                    int check = NhanVienGiaoHangDAO.Instance.XoaNhanVien(getNguoiDung());
                    MessageBox.Show(check != -1 ? " Xóa nhân viên thành công!" : " Xóa nhân viên thất bại!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    check != -1 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                    loadData(); 
                }


            }
            else
            {
                MessageBox.Show("Bạn đã hủy thao tác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }

        }

        public void setCount()
        {
            int soLuongKh = NhanVienGiaoHangDAO.Instance.getCount();
            lb_tsnvgh.Text = soLuongKh + "";
        }
    }
}
