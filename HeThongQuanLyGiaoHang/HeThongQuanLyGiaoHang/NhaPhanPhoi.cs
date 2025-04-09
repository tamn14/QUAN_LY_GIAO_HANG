using HeThongQuanLyGiaoHang.DAO;
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
    public partial class NhaPhanPhoiAdmin : Form
    {
        public NhaPhanPhoiAdmin()
        {
            InitializeComponent();
            loadData();
            setnPP(); 
        }

        public void loadData()
        {
            dataGridView1.DataSource = NhaPhanPhoiDAO.Instance.loadNPP();
            dataGridView1.Columns[0].HeaderText = "Mã NPP";
            dataGridView1.Columns[1].HeaderText = "Tên NPP";
            dataGridView1.Columns[2].HeaderText = "Địa Chỉ";
            dataGridView1.Columns[3].HeaderText = "SDT";
            dataGridView1.Columns[4].HeaderText = "Email";
            




            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 150;
           
            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
        }


        public void setnPP()
        {
            lb_maNPPFormNPP.DataBindings.Clear();
            lb_tenNppFormNPP.DataBindings.Clear();
            lb_dcNPPFormNPP.DataBindings.Clear();
            lb_sdtNPPFormNPP.DataBindings.Clear();
            lb_EmailNPPFormNPP.DataBindings.Clear();


            lb_maNPPFormNPP.DataBindings.Add("Text", dataGridView1.DataSource, "MANPP");
            lb_tenNppFormNPP.DataBindings.Add("Text", dataGridView1.DataSource, "TENNPP");
            lb_dcNPPFormNPP.DataBindings.Add("Text", dataGridView1.DataSource, "DIACHI");
            lb_sdtNPPFormNPP.DataBindings.Add("Text", dataGridView1.DataSource, "SODIENTHOAI");
            lb_EmailNPPFormNPP.DataBindings.Add("Text", dataGridView1.DataSource, "EMAIL");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = textBox3.Text;
            DataTable dataTable = NhaPhanPhoiDAO.Instance.find(str);

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy NPP phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dataGridView1.DataSource = dataTable; 
            dataGridView1.Columns[0].HeaderText = "Mã NPP";
            dataGridView1.Columns[1].HeaderText = "Tên NPP";
            dataGridView1.Columns[2].HeaderText = "Địa Chỉ";
            dataGridView1.Columns[3].HeaderText = "SDT";
            dataGridView1.Columns[4].HeaderText = "Email";





            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 150;

            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
        }
    }
}
