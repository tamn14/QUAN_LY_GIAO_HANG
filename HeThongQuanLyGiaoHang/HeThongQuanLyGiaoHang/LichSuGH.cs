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
    public partial class LichSuGH : Form
    {
        private NguoiDung nguoiDung;
        public LichSuGH(NguoiDung nguoiDung)
        {
            this.nguoiDung = nguoiDung;
            InitializeComponent();
            loadData();

        }

        private void loadData()
        {

            DataTable dt = LichSuGHDAO.Instance.loadAllLSGH(nguoiDung);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu lịch sử giao hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].HeaderText = "Mã LS";
            dataGridView1.Columns[1].HeaderText = "Mã ĐH";
            dataGridView1.Columns[2].HeaderText = "Tên Sản Phẩm";
            dataGridView1.Columns[3].HeaderText = "Trạng Thái";
            dataGridView1.Columns[4].HeaderText = "Lần Giao";
            dataGridView1.Columns[5].HeaderText = "Thời Gian Cập Nhật";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }


        // Xử lý hiển thị trạng thái
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Trạng Thái" && e.Value != null)
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

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime dateFilter = dateTimePicker1.Value.Date;
            string dateString = dateFilter.ToString("yyyy-MM-dd");

            int? status = null;
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                status = null; 
            }
            else if (comboBox1.Text.Equals("Thành Công"))
            {
                status = 1;
            }
            else
            {
                status = 2;
            }

            
            var result = LichSuGHDAO.Instance.fillter(nguoiDung, dateString, status);

            if (result != null && result.Rows.Count > 0)
            {
                dataGridView1.DataSource = result;

                dataGridView1.Columns[0].HeaderText = "Mã LS";
                dataGridView1.Columns[1].HeaderText = "Mã ĐH";
                dataGridView1.Columns[2].HeaderText = "Tên Sản Phẩm";
                dataGridView1.Columns[3].HeaderText = "Trạng Thái";
                dataGridView1.Columns[4].HeaderText = "Lần Giao";
                dataGridView1.Columns[5].HeaderText = "Thời Gian Cập Nhật";

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 200;
                dataGridView1.Columns[3].Width = 200;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 200;
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
                    MessageBox.Show("Không có dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        private void button3_Click(object sender, EventArgs e)

        {
            string str = textBox3.Text;
                var result = LichSuGHDAO.Instance.find(nguoiDung.TenDangNhap, str);

                // Kiểm tra xem có dữ liệu không
                if (result != null && result.Rows.Count > 0)
                {
                    dataGridView1.DataSource = result;

                    //    // Thiết lập header của các cột
                    dataGridView1.Columns[0].HeaderText = "Mã LS";
                    dataGridView1.Columns[1].HeaderText = "Mã ĐH";
                    dataGridView1.Columns[2].HeaderText = "Tên Sản Phẩm";
                    dataGridView1.Columns[3].HeaderText = "Trạng Thái";
                    dataGridView1.Columns[4].HeaderText = "Lần Giao";
                    dataGridView1.Columns[5].HeaderText = "Thời Gian Cập Nhật";

                    //    // Điều chỉnh kiểu hiển thị cột
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    dataGridView1.Columns[0].Width = 100;
                    dataGridView1.Columns[1].Width = 100;
                    dataGridView1.Columns[2].Width = 200;
                    dataGridView1.Columns[3].Width = 200;
                    dataGridView1.Columns[4].Width = 100;
                    dataGridView1.Columns[5].Width = 200;
                    dataGridView1.Font = new Font("Arial", 9);
                    dataGridView1.ScrollBars = ScrollBars.Both;

                    //    // Đổi màu cho các dòng chẵn
                    DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
                    rowStyle.BackColor = Color.LightBlue;
                    dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

                    //    // Điều chỉnh chiều cao của các dòng
                    dataGridView1.RowTemplate.Height = 25;

                    //    // Gán sự kiện CellFormatting
                    dataGridView1.CellFormatting += dataGridView1_CellFormatting;
                }
                else
                    {
                        MessageBox.Show("Không có dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
    }
}
