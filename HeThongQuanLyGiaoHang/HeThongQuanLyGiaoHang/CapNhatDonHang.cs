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
    public partial class CapNhatDonHang : Form
    {
        private NguoiDung nguoiDung;
        private int selectedMaDH;
        
        public CapNhatDonHang(NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
            loadDonHang();
            setDonHang();
            loadDiaChi();
        }


        public void loadDonHang()
        {


            dataGridView1.DataSource = DonHangDAO.Instance.loadDonHang(nguoiDung);
            dataGridView1.Columns[0].HeaderText = "Mã ĐH ";
            dataGridView1.Columns[1].HeaderText = "Tên Sản Phẩm";
            dataGridView1.Columns[2].HeaderText = "Tên Khách Hàng";
            dataGridView1.Columns[3].HeaderText = "Địa chỉ";
            dataGridView1.Columns[4].HeaderText = "Tổng Tiền";
            dataGridView1.Columns[5].HeaderText = "Ngày Giao";
            dataGridView1.Columns[6].HeaderText = "Khuyến Mãi";
            dataGridView1.Columns[7].HeaderText = "Số Tiền Cần Thu";
            dataGridView1.Columns[8].HeaderText = "Trạng thái";
            dataGridView1.Columns[9].HeaderText = "Phí Giao";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 50;
            dataGridView1.Columns[9].Width = 80;
            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
        }

        public void setDonHang()
        {
            lb_madh_formCNDH.DataBindings.Clear();  
            lb_tenkh_formCNDH.DataBindings.Clear();
            lb_tensp_formCNDH.DataBindings.Clear();
            lb_dcgh_formCNDH.DataBindings.Clear();
            lb_tt_formCNHD.DataBindings.Clear();
            lb_ngaygh_formCNDH.DataBindings.Clear();
            lb_phigiaoFormCNDH.DataBindings.Clear();
            lb_km_formCNDH.DataBindings.Clear(); 
            lb_phigiaoFormCNDH.DataBindings.Clear(); 
           
            lb_stct_formCNHD.DataBindings.Clear();
            lb_trangthai_formCNDH.Text = "Đang Giao Hàng"; 

            lb_madh_formCNDH.DataBindings.Add("Text", dataGridView1.DataSource, "maDH");
            lb_tensp_formCNDH.DataBindings.Add("Text", dataGridView1.DataSource, "tenSP");
            lb_dcgh_formCNDH.DataBindings.Add("Text", dataGridView1.DataSource, "diaChi");
            lb_tenkh_formCNDH.DataBindings.Add("Text", dataGridView1.DataSource, "tenKH");
            
            lb_tt_formCNHD.DataBindings.Add("Text", dataGridView1.DataSource, "tongTien");
            Binding binding = new Binding("Text", dataGridView1.DataSource, "soTienCanThu", true, DataSourceUpdateMode.Never);
            binding.Format += (s, e) =>
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    e.Value = string.Format("{0:N0} VND", Convert.ToDecimal(e.Value));
                }
            };
            lb_stct_formCNHD.DataBindings.Add(binding);

            Binding phiGiao = new Binding("Text", dataGridView1.DataSource, "phiship", true, DataSourceUpdateMode.Never);
            phiGiao.Format += (s, e) =>
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    e.Value = string.Format("{0:N0} VND", Convert.ToDecimal(e.Value));
                }
            };
            lb_phigiaoFormCNDH.DataBindings.Add(phiGiao);

            Binding ngayGiao = new Binding("Text", dataGridView1.DataSource, "ngayGiao", true);
            ngayGiao.Format += (s, e) =>
            {
                if (e.Value != null && DateTime.TryParse(e.Value.ToString(), out DateTime date))
                {
                    e.Value = date.ToString("dd/MM/yyyy");
                }
            };
            lb_ngaygh_formCNDH.DataBindings.Add(ngayGiao);

        }


        public void loadDiaChi()
        {

            List<DonHang> list = DonHangDAO.Instance.getDiaCHiGiaoHang(nguoiDung.maNguoiDung);
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "DiaChiGH";
           


            
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            {
                if (dataGridView1.CurrentRow != null)
                {
                    selectedMaDH = Convert.ToInt32(dataGridView1.CurrentRow.Cells["maDH"].Value);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = textBox3.Text;

            DataTable dataTable = DonHangDAO.Instance.find(nguoiDung.TenDangNhap, str);

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy đơn hàng phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; 
            }

            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns[0].HeaderText = "Mã ĐH";
            dataGridView1.Columns[1].HeaderText = "Tên Sản Phẩm";
            dataGridView1.Columns[2].HeaderText = "Tên Khách Hàng";
            dataGridView1.Columns[3].HeaderText = "Địa chỉ";
            dataGridView1.Columns[4].HeaderText = "Tổng Tiền";
            dataGridView1.Columns[5].HeaderText = "Ngày Giao";
            dataGridView1.Columns[6].HeaderText = "Khuyến Mãi";
            dataGridView1.Columns[7].HeaderText = "Số Tiền Cần Thu";
            dataGridView1.Columns[8].HeaderText = "Trạng thái";
            dataGridView1.Columns[9].HeaderText = "Phí Giao";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 50;
            dataGridView1.Columns[9].Width = 80;
            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
            setDonHang(); 
        }


        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {

            string khuyenmai = dataGridView1.CurrentRow.Cells["totalDiscount"].Value.ToString();
            lb_km_formCNDH.Text = (khuyenmai == "") ? " 0 " : khuyenmai;
           
            
            
        }

        public DonHang getDonHang()
        {
            DonHang donHang = new DonHang();
            string madonHang = dataGridView1.CurrentRow.Cells["maDH"].Value.ToString();
            int maDH = Convert.ToInt32(madonHang);
            donHang = DonHangDAO.Instance.getDonHangById(maDH);
            return donHang; 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DonHang donHang = getDonHang(); 
            CapNhatTrangThaiDonHang capNhatTrangThaiDonHang = new CapNhatTrangThaiDonHang(donHang , nguoiDung);
            capNhatTrangThaiDonHang.ShowDialog();
            loadDonHang();
            setDonHang(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DonHang donHang = getDonHang();
            ChiTietDonHang chiTietDonHang = new ChiTietDonHang(donHang);
            chiTietDonHang.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = comboBox1.Text;

            DataTable dataTable = DonHangDAO.Instance.FilleDonHangForShip(nguoiDung.TenDangNhap, str);

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy đơn hàng phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns[0].HeaderText = "Mã ĐH";
            dataGridView1.Columns[1].HeaderText = "Tên Sản Phẩm";
            dataGridView1.Columns[2].HeaderText = "Tên Khách Hàng";
            dataGridView1.Columns[3].HeaderText = "Địa chỉ";
            dataGridView1.Columns[4].HeaderText = "Tổng Tiền";
            dataGridView1.Columns[5].HeaderText = "Ngày Giao";
            dataGridView1.Columns[6].HeaderText = "Khuyến Mãi";
            dataGridView1.Columns[7].HeaderText = "Số Tiền Cần Thu";
            dataGridView1.Columns[8].HeaderText = "Trạng thái";
            dataGridView1.Columns[9].HeaderText = "Phí Giao";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 50;
            dataGridView1.Columns[9].Width = 80;
            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
            setDonHang();
        }
    }
}
