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
    public partial class LichSuGiaoHangAdmin : Form
    {
        public LichSuGiaoHangAdmin()
        {
            InitializeComponent();
            loadData();
            setLSGh();
        }

        public void loadData()
        {
            dataGridView1.DataSource = LichSuGHDAO.Instance.loadAllLSGHForAdmin();
            dataGridView1.Columns[0].HeaderText = "Mã LS";
            dataGridView1.Columns[1].HeaderText = "Mã ĐH";
            dataGridView1.Columns[2].HeaderText = "Shipper";
            dataGridView1.Columns[3].HeaderText = "Thời Gian Cập Nhật";
            dataGridView1.Columns[4].HeaderText = "Trạng Thái";
            dataGridView1.Columns[5].HeaderText = "Lần Giao";
            dataGridView1.Columns[6].HeaderText = "Tên Khách Hàng";
            dataGridView1.Columns[7].HeaderText = "Tên SP";
            dataGridView1.Columns[8].HeaderText = "Địa Chỉ";
            






            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Width = 120;
            dataGridView1.Columns[8].Width = 120;



            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Trạng Tháit" && e.Value != null)
            {
                switch (e.Value.ToString())
                {

                    case "1":
                        e.Value = "Thành Công";
                        break;
                    case "2":
                        e.Value = "Thất Bại";
                        break;
                }
                e.FormattingApplied = true;
            }
        }

        public void setLSGh()
        {
            lb_malsFormLSGHA.DataBindings.Clear();
            lb_maDHFormLSGHA.DataBindings.Clear();
            lb_shipper_formLSGHA.DataBindings.Clear();
            lb_TGCNFormLSGHA.DataBindings.Clear();
            lb_ttFormLSGHA.DataBindings.Clear();
            lb_langiaoFormLSGHA.DataBindings.Clear();
            lb_tenkh_formLSGHA.DataBindings.Clear();
            llb_dc_formLSGHA.DataBindings.Clear();
            lb_tensp_formLSGHA.DataBindings.Clear(); 
            
           




            lb_malsFormLSGHA.DataBindings.Add("Text", dataGridView1.DataSource, "mals");
            lb_maDHFormLSGHA.DataBindings.Add("Text", dataGridView1.DataSource, "madh");
            lb_shipper_formLSGHA.DataBindings.Add("Text", dataGridView1.DataSource, "NHANVIENGIAOHANG");
            lb_langiaoFormLSGHA.DataBindings.Add("Text", dataGridView1.DataSource, "lanGiao");
            lb_tenkh_formLSGHA.DataBindings.Add("Text", dataGridView1.DataSource, "TenKh");
            llb_dc_formLSGHA.DataBindings.Add("Text", dataGridView1.DataSource, "DIACHIGIAOHANG");
            lb_tensp_formLSGHA.DataBindings.Add("Text", dataGridView1.DataSource, "tensp");



            Binding trangThaiBinding = new Binding("Text", dataGridView1.DataSource, "trangthai", true);
            trangThaiBinding.Format += (s, e) =>
            {
                if (e.Value != null)
                {
                    switch (e.Value.ToString())
                    {

                        case "1":
                            e.Value = "Thành Công";
                            break;
                        case "2":
                            e.Value = "Thất Bại";
                            break;
                        default:
                            e.Value = "Không xác định";
                            break;
                    }
                }
            };
            lb_ttFormLSGHA.DataBindings.Add(trangThaiBinding);

            Binding ThoiGianCapNhat = new Binding("Text", dataGridView1.DataSource, "thoiGianCapNhat", true);
            ThoiGianCapNhat.Format += (s, e) =>
            {
                if (e.Value != null && DateTime.TryParse(e.Value.ToString(), out DateTime date))
                {
                    e.Value = date.ToString("dd/MM/yyyy"); // Định dạng ngày
                }
                else
                {
                    e.Value = "Chưa có";
                }
            };
            lb_TGCNFormLSGHA.DataBindings.Add(ThoiGianCapNhat);

           



        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = textBox3.Text;
            var result = LichSuGHDAO.Instance.findForAdmin(str);
            if (result != null && result.Rows.Count > 0)
            {
                dataGridView1.DataSource = result;
                dataGridView1.Columns[0].HeaderText = "Mã LS";
                dataGridView1.Columns[1].HeaderText = "Mã ĐH";
                dataGridView1.Columns[2].HeaderText = "Shipper";
                dataGridView1.Columns[3].HeaderText = "Thời Gian Cập Nhật";
                dataGridView1.Columns[4].HeaderText = "Trạng Thái";
                dataGridView1.Columns[5].HeaderText = "Lần Giao";
                dataGridView1.Columns[6].HeaderText = "Tên Khách Hàng";
                dataGridView1.Columns[7].HeaderText = "Tên SP";
                dataGridView1.Columns[8].HeaderText = "Địa Chỉ";







                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].Width = 80;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 80;
                dataGridView1.Columns[5].Width = 80;
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[7].Width = 120;
                dataGridView1.Columns[8].Width = 120;


                dataGridView1.Font = new Font("Arial", 9);
                dataGridView1.ScrollBars = ScrollBars.Both;

                DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
                rowStyle.BackColor = Color.LightBlue;
                dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

                dataGridView1.RowTemplate.Height = 25;
                dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            }
        
            else
            {
                MessageBox.Show("Không tìm thấy lịch sử phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            setLSGh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime dateFilter = dateTimePicker2.Value.Date;
            string dateString = dateFilter.ToString("yyyy-MM-dd");

            int? status = null;
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                status = null;
            }
            else if (comboBox2.Text.Equals("Thành Công"))
            {
                status = 1;
            }
            else if (comboBox2.Text.Equals("Thất Bại"))
            {
                status = 2;
            }



            var result = LichSuGHDAO.Instance.fillterForAdmin(dateString, status);
            if (result != null && result.Rows.Count > 0)
            {
                dataGridView1.DataSource = result;
                dataGridView1.Columns[0].HeaderText = "Mã LS";
                dataGridView1.Columns[1].HeaderText = "Mã ĐH";
                dataGridView1.Columns[2].HeaderText = "Shipper";
                dataGridView1.Columns[3].HeaderText = "Thời Gian Cập Nhật";
                dataGridView1.Columns[4].HeaderText = "Trạng Thái";
                dataGridView1.Columns[5].HeaderText = "Lần Giao";
                dataGridView1.Columns[6].HeaderText = "Tên Khách Hàng";
                dataGridView1.Columns[7].HeaderText = "Tên SP";
                dataGridView1.Columns[8].HeaderText = "Địa Chỉ";







                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].Width = 80;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 80;
                dataGridView1.Columns[5].Width = 80;
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[7].Width = 120;
                dataGridView1.Columns[8].Width = 120;


                dataGridView1.Font = new Font("Arial", 9);
                dataGridView1.ScrollBars = ScrollBars.Both;

                DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
                rowStyle.BackColor = Color.LightBlue;
                dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

                dataGridView1.RowTemplate.Height = 25;
                dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            }

            else
            {
                MessageBox.Show("Không tìm thấy lịch sử phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            setLSGh(); 
        }
    }
}
