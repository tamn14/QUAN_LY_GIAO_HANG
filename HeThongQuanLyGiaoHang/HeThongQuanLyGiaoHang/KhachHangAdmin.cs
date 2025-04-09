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
    public partial class KhachHangAdmin : Form
    {
        public KhachHangAdmin()
        {
            InitializeComponent();
            loadData();
            setKH();
            setCount();
        }

        public void loadData()
        {
            dataGridView1.DataSource = KhachHangDAO.Instance.loadKhachHang();
            dataGridView1.Columns[0].HeaderText = "Mã KH";
            dataGridView1.Columns[1].HeaderText = "Tên KH";
            dataGridView1.Columns[2].HeaderText = "Số Điện Thoại";
            dataGridView1.Columns[3].HeaderText = "Địa Chỉ";




            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 400;

            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
        }

        public void setKH()
        {
            lb_makhFormKHA.DataBindings.Clear();
            lb_tenKHFormKHA.DataBindings.Clear();
            lb_sdtKhFormKHA.DataBindings.Clear();
            lb_dcKhFormKHA.DataBindings.Clear();




            lb_makhFormKHA.DataBindings.Add("Text", dataGridView1.DataSource, "makh");
            lb_tenKHFormKHA.DataBindings.Add("Text", dataGridView1.DataSource, "tenkh");
            lb_sdtKhFormKHA.DataBindings.Add("Text", dataGridView1.DataSource, "sodienthoai");
            lb_dcKhFormKHA.DataBindings.Add("Text", dataGridView1.DataSource, "diachi");




        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = textBox3.Text;
            dataGridView1.DataSource = KhachHangDAO.Instance.find(str);
            dataGridView1.Columns[0].HeaderText = "Mã KH";
            dataGridView1.Columns[1].HeaderText = "Tên KH";
            dataGridView1.Columns[2].HeaderText = "Số Điện Thoại";
            dataGridView1.Columns[3].HeaderText = "Địa Chỉ";




            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 400;

            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
            setKH();
        }

        public void setCount()
        {
            int soLuongKh = KhachHangDAO.Instance.getCount();
            lb_slFormKHA.Text = soLuongKh + "";
        }


    }
}
