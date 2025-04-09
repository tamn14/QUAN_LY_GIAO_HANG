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
    public partial class SanPhamAdmin : Form
    {
        public SanPhamAdmin()
        {
            InitializeComponent();
            loadData();
            setSP();
        }

        public void loadData()
        {
            dataGridView1.DataSource = SanPhamDAO.Instance.loadSanPham();
            dataGridView1.Columns[0].HeaderText = "Mã SP";
            dataGridView1.Columns[1].HeaderText = "Tên SP";
            dataGridView1.Columns[2].HeaderText = "Giá Bán";
            dataGridView1.Columns[3].HeaderText = "Ngày Mua";
            dataGridView1.Columns[4].HeaderText = "Số Lượng";
            dataGridView1.Columns[5].HeaderText = "Khối Lượng";
            dataGridView1.Columns[6].HeaderText = "Mô Tả";
            dataGridView1.Columns[7].HeaderText = "Mã ĐH";
            dataGridView1.Columns[8].HeaderText = "Nhà Phân Phối";
            dataGridView1.Columns[9].HeaderText = "Tổng Tiền";





            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].Width = 120;
            dataGridView1.Columns[7].Width = 80;
            dataGridView1.Columns[8].Width = 100;
            dataGridView1.Columns[9].Width = 100;


            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = textBox3.Text;
            DataTable dataTable = SanPhamDAO.Instance.find(str);

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy đơn hàng phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dataGridView1.DataSource = dataTable; 
            dataGridView1.Columns[0].HeaderText = "Mã SP";
            dataGridView1.Columns[1].HeaderText = "Tên SP";
            dataGridView1.Columns[2].HeaderText = "Giá Bán";
            dataGridView1.Columns[3].HeaderText = "Ngày Mua";
            dataGridView1.Columns[4].HeaderText = "Số Lượng";
            dataGridView1.Columns[5].HeaderText = "Khối Lượng";
            dataGridView1.Columns[6].HeaderText = "Mô Tả";
            dataGridView1.Columns[7].HeaderText = "Mã ĐH";
            dataGridView1.Columns[8].HeaderText = "Nhà Phân Phối";
            dataGridView1.Columns[9].HeaderText = "Tổng Tiền";





            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].Width = 120;
            dataGridView1.Columns[7].Width = 80;
            dataGridView1.Columns[8].Width = 100;
            dataGridView1.Columns[9].Width = 100;


            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
            setSP();
        }

        public void setSP()
        {
            lb_maSPFormSPA.DataBindings.Clear();
            lb_tenspFormSPA.DataBindings.Clear();
            lb_GiaBanFormSPA.DataBindings.Clear();
            lb_NPPFormSPA.DataBindings.Clear();
            lb_tdm_formSA.DataBindings.Clear(); 
            lb_sl_formSA.DataBindings.Clear();
            lb_khoiluongFormSA.DataBindings.Clear();
            lb_motaFormSA.DataBindings.Clear();
            lb_madh_formSA.DataBindings.Clear();
            lb_tongtienFormSA.DataBindings.Clear(); 




            lb_maSPFormSPA.DataBindings.Add("Text", dataGridView1.DataSource, "maSP");
            lb_tenspFormSPA.DataBindings.Add("Text", dataGridView1.DataSource, "tenSP");
            lb_GiaBanFormSPA.DataBindings.Add("Text", dataGridView1.DataSource, "giaBan");
            lb_NPPFormSPA.DataBindings.Add("Text", dataGridView1.DataSource, "tenNPP");

            lb_tdm_formSA.DataBindings.Add("Text", dataGridView1.DataSource, "thoiDiemMua");
            lb_sl_formSA.DataBindings.Add("Text", dataGridView1.DataSource, "soLuong");
            lb_khoiluongFormSA.DataBindings.Add("Text", dataGridView1.DataSource, "khoiLuong");
            lb_motaFormSA.DataBindings.Add("Text", dataGridView1.DataSource, "moTa");
            lb_madh_formSA.DataBindings.Add("Text", dataGridView1.DataSource, "maDH");

            Binding thanhTien = new Binding("Text", dataGridView1.DataSource, "thanhTien", true, DataSourceUpdateMode.Never);
            thanhTien.Format += (s, e) =>
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    e.Value = string.Format("{0:N0} VND", Convert.ToDecimal(e.Value));
                }
            };
            lb_tongtienFormSA.DataBindings.Add(thanhTien);



        }
    }
}
