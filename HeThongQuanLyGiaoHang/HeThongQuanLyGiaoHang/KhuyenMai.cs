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
    public partial class KhuyenMaiAdmin : Form
    {
        public KhuyenMaiAdmin()
        {
            InitializeComponent();
            loadKhuyenMai();
            setKhuyenMai();
            
        }

        public void loadKhuyenMai()
        {
            dataGridView1.DataSource = KhuyenMaiDAO.Instance.loadKhuyenMai();
            dataGridView1.Columns[0].HeaderText = "Mã Khuyến Mãi";
            dataGridView1.Columns[1].HeaderText = "Tên Khuyến Mãi";
            dataGridView1.Columns[2].HeaderText = "Phần Trăm Khuyến Mãi";
            dataGridView1.Columns[3].HeaderText = "Ngày Bắt Đầu";
            dataGridView1.Columns[4].HeaderText = "Ngày Kết Thúc";


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 200;
            
            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
            
        }

        public void setTongKhuyenMai(int soluong)
        {
            lb_tongKmFormKm.DataBindings.Clear();
            lb_tongKmFormKm.Text = soluong.ToString();
        }

        public void setKhuyenMai()
        {
            lb_makmFormKM.DataBindings.Clear();
            lb_tenKmFormKm.DataBindings.Clear();
            lb_ptramgiam_formKm.DataBindings.Clear(); 
            lb_TGBDFormKM.DataBindings.Clear(); 
            lb_TGKTFormKM.DataBindings.Clear();
           



            lb_makmFormKM.DataBindings.Add("Text", dataGridView1.DataSource, "MAKM");
            lb_tenKmFormKm.DataBindings.Add("Text", dataGridView1.DataSource, "TENKM");
            lb_ptramgiam_formKm.DataBindings.Add("Text", dataGridView1.DataSource, "PHANTRAMGIAM");
            

            Binding NGAYBD = new Binding("Text", dataGridView1.DataSource, "NGAYBATDAU", true);
            NGAYBD.Format += (s, e) =>
            {
                if (e.Value != null && DateTime.TryParse(e.Value.ToString(), out DateTime date))
                {
                    e.Value = date.ToString("dd/MM/yyyy");
                }
            };
            lb_TGBDFormKM.DataBindings.Add(NGAYBD);

            Binding NGAYKT = new Binding("Text", dataGridView1.DataSource, "NGAYKETTHUC", true);
            NGAYKT.Format += (s, e) =>
            {
                if (e.Value != null && DateTime.TryParse(e.Value.ToString(), out DateTime date))
                {
                    e.Value = date.ToString("dd/MM/yyyy");
                }
            };
            lb_TGKTFormKM.DataBindings.Add(NGAYKT);

            int soluong = KhuyenMaiDAO.Instance.getCount();
            setTongKhuyenMai(soluong);


        }

        private void button1_Click(object sender, EventArgs e)
        {

            string str = textBox3.Text;
            var result = KhuyenMaiDAO.Instance.find(str);
            if (result != null && result.Rows.Count > 0)
            {
                dataGridView1.DataSource = result; 
                dataGridView1.Columns[0].HeaderText = "Mã Khuyến Mãi";
                dataGridView1.Columns[1].HeaderText = "Tên Khuyến Mãi";
                dataGridView1.Columns[2].HeaderText = "Phần Trăm Khuyến Mãi";
                dataGridView1.Columns[3].HeaderText = "Ngày Bắt Đầu";
                dataGridView1.Columns[4].HeaderText = "Ngày Kết Thúc";


                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 200;
                dataGridView1.Columns[4].Width = 200;

                dataGridView1.Font = new Font("Arial", 9);
                dataGridView1.ScrollBars = ScrollBars.Both;

                DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
                rowStyle.BackColor = Color.LightBlue;
                dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

                dataGridView1.RowTemplate.Height = 25;
            }

            else
            {
                MessageBox.Show("Không tìm thấy đơn hàng phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            setKhuyenMai(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime DateBegin = dateTimePicker2.Value.Date;
            string begin = DateBegin.ToString("yyyy-MM-dd");
            DateTime DateEnd = dateTimePicker1.Value.Date;
            string end = DateBegin.ToString("yyyy-MM-dd");


            var result = KhuyenMaiDAO.Instance.fillter(DateBegin , DateEnd);
            if (result != null && result.Rows.Count > 0)
            {
                dataGridView1.DataSource = result;
                dataGridView1.Columns[0].HeaderText = "Mã Khuyến Mãi";
                dataGridView1.Columns[1].HeaderText = "Tên Khuyến Mãi";
                dataGridView1.Columns[2].HeaderText = "Phần Trăm Khuyến Mãi";
                dataGridView1.Columns[3].HeaderText = "Ngày Bắt Đầu";
                dataGridView1.Columns[4].HeaderText = "Ngày Kết Thúc";


                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 200;
                dataGridView1.Columns[4].Width = 200;

                dataGridView1.Font = new Font("Arial", 9);
                dataGridView1.ScrollBars = ScrollBars.Both;

                DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
                rowStyle.BackColor = Color.LightBlue;
                dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

                dataGridView1.RowTemplate.Height = 25;
            }

            else
            {
                MessageBox.Show("Không tìm thấy đơn hàng phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            setKhuyenMai();
            int soluong = KhuyenMaiDAO.Instance.getCountByTime(DateBegin , DateEnd);
            setTongKhuyenMai(soluong);
        }

        public KhuyenMai getkhuyenMai()
        {
            try
            {
                int MAKM = Convert.ToInt32(lb_makmFormKM.Text);
                string tenKM = lb_tenKmFormKm.Text;
                decimal phanTramGiam = Convert.ToDecimal(lb_ptramgiam_formKm.Text);

                DateTime ngayBatDau = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["NGAYBATDAU"].Value);
                DateTime ngayKetThuc = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["NGAYKETTHUC"].Value);

                KhuyenMai khuyenMai = new KhuyenMai();
                khuyenMai.MaKM = MAKM;
                khuyenMai.tenKM = tenKM;
                khuyenMai.PhanTramGiamGia = phanTramGiam;
                khuyenMai.ngayBatDau = ngayBatDau;
                khuyenMai.ngayKetThuc = ngayKetThuc;

                

                return khuyenMai;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        private void button_capnhat_Click(object sender, EventArgs e)
        {
            ThemKhuyenMai themKhuyenMai = new ThemKhuyenMai();
            themKhuyenMai.ShowDialog();
            loadKhuyenMai();
            setKhuyenMai();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KhuyenMai khuyenMai = new KhuyenMai();
            khuyenMai = getkhuyenMai();
            CapNhatKhuyenMai capNhatKhuyenMai = new CapNhatKhuyenMai(khuyenMai);
            capNhatKhuyenMai.ShowDialog();
            loadKhuyenMai(); 
            setKhuyenMai();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa khuyến mãi này không?",
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
                int MAKM = Convert.ToInt32(lb_makmFormKM.Text);
                int check = KhuyenMaiDAO.Instance.XoaKhuyenMai(MAKM);
                MessageBox.Show(check != -1 ? "Xóa khuyến mãi thành công!" : "Xóa khuyến mãi thất bại!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                check != -1 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                loadKhuyenMai();
                setKhuyenMai();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa khuyến mãi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
