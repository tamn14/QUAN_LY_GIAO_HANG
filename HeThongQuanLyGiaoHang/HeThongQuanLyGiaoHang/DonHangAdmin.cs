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
    public partial class DonHangAdmin : Form
    {
        NguoiDung nguoiDung; 
        public DonHangAdmin(NguoiDung nguoiDung)
        {
            InitializeComponent();
            loadData();
            setDonHang();
            this.nguoiDung = nguoiDung;

            ThongKe();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        public void loadData()
        {
            dataGridView1.DataSource = DonHangDAO.Instance.loadDonHangForAdmin();
            dataGridView1.Columns[0].HeaderText = "Mã Đơn Hàng";
            dataGridView1.Columns[1].HeaderText = "Tên SP";
            dataGridView1.Columns[2].HeaderText = "Tên KH";
            dataGridView1.Columns[3].HeaderText = "Kho";
            dataGridView1.Columns[4].HeaderText = "Tên Shipper";
            dataGridView1.Columns[5].HeaderText = "Tổng Tiền";
            dataGridView1.Columns[6].HeaderText = "Khuyến Mãi";
            dataGridView1.Columns[7].HeaderText = "Cần Thu";
            dataGridView1.Columns[8].HeaderText = "Trạng Thái";
            dataGridView1.Columns[9].HeaderText = "Ngày Tạo";
            dataGridView1.Columns[10].HeaderText = "Địa Chỉ";
            dataGridView1.Columns[11].HeaderText = "Ngày Giao";
            dataGridView1.Columns[12].HeaderText = "Phí Ship";




            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 80;
            dataGridView1.Columns[8].Width = 180;
            dataGridView1.Columns[9].Width = 80;
            dataGridView1.Columns[10].Width = 80;
            dataGridView1.Columns[11].Width = 80;
            dataGridView1.Columns[12].Width = 80;
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
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Trạng Thái" && e.Value != null)
            {
                switch (e.Value.ToString())
                {
                    case "1":
                        e.Value = "Đang Giao";
                        break;
                    case "2":
                        e.Value = "Thành Công";
                        break;
                    case "3":
                        e.Value = "Thất Bại";
                        break;
                }
                e.FormattingApplied = true;
            }
        }

        public void setDonHang()
        {
            lb_MaDHFormDHA.DataBindings.Clear();
            lb_tenKhFormDHA.DataBindings.Clear();
            lb_tenspFormDHA.DataBindings.Clear();
            lb_kformDHA.DataBindings.Clear();
            lb_tenShipFormDHA.DataBindings.Clear();
            lb_tongtien_formDHA.DataBindings.Clear();
            lb_dc_formDHA.DataBindings.Clear();
            lb_khuyenmaiFormDHA.DataBindings.Clear();
            lb_Canthu_formDHA.DataBindings.Clear();
            lb_ngayTaoFormDHA.DataBindings.Clear();
            lb_ngaygiaoFormDHA.DataBindings.Clear();
            lb_phishipFormDHA.DataBindings.Clear();
            lb_trangtFormDHA.DataBindings.Clear();  




            lb_MaDHFormDHA.DataBindings.Add("Text", dataGridView1.DataSource, "maDH");
            lb_tenspFormDHA.DataBindings.Add("Text", dataGridView1.DataSource, "tenSP");
            lb_tenKhFormDHA.DataBindings.Add("Text", dataGridView1.DataSource, "tenKH");
            lb_kformDHA.DataBindings.Add("Text", dataGridView1.DataSource, "TENKHO");

           
          
            lb_khuyenmaiFormDHA.DataBindings.Add("Text", dataGridView1.DataSource, "totalDiscount");

            Binding binding = new Binding("Text", dataGridView1.DataSource, "soTienCanThu", true, DataSourceUpdateMode.Never);
            binding.Format += (s, e) =>
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    e.Value = string.Format("{0:N0} VND", Convert.ToDecimal(e.Value));
                }
            };
            lb_Canthu_formDHA.DataBindings.Add(binding);

            Binding ngayTaoBinding = new Binding("Text", dataGridView1.DataSource, "ngayTao", true);
            ngayTaoBinding.Format += (s, e) =>
            {
                if (e.Value != null && DateTime.TryParse(e.Value.ToString(), out DateTime date))
                {
                    e.Value = date.ToString("dd/MM/yyyy");
                }
            };
            lb_ngayTaoFormDHA.DataBindings.Add(ngayTaoBinding);
           
            // Xử lý trạng thái đơn hàng
            Binding trangThaiBinding = new Binding("Text", dataGridView1.DataSource, "trangThai", true);
            trangThaiBinding.Format += (s, e) =>
            {
                if (e.Value != null)
                {
                    switch (e.Value.ToString())
                    {
                        case "1":
                            e.Value = "Đang Giao";
                            break;
                        case "2":
                            e.Value = "Hoàn Thành";
                            break;
                        case "3":
                            e.Value = "Thất Bại";
                            break;
                        default:
                            e.Value = "Không xác định";
                            break;
                    }
                }
            };
            lb_trangtFormDHA.DataBindings.Add(trangThaiBinding);


            Binding Shipper = new Binding("Text", dataGridView1.DataSource, "TENSHIPPER", true);
            Shipper.Format += (s, e) =>
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
            lb_tenShipFormDHA.DataBindings.Add(Shipper);

            Binding ngayGiao = new Binding("Text", dataGridView1.DataSource, "ngayGiao", true);
            ngayGiao.Format += (s, e) =>
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
            lb_ngaygiaoFormDHA.DataBindings.Add(ngayGiao);







            lb_dc_formDHA.DataBindings.Add("Text", dataGridView1.DataSource, "diaChi");
            


            Binding tongTienBinding = new Binding("Text", dataGridView1.DataSource, "tongTien", true);
            tongTienBinding.Format += (s, e) =>
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal tien))
                {
                    e.Value = string.Format("{0:N0} VND", tien);
                }
            };
            lb_tongtien_formDHA.DataBindings.Add(tongTienBinding);

            Binding phiShipBinding = new Binding("Text", dataGridView1.DataSource, "phiShip", true);
            phiShipBinding.Format += (s, e) =>
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal phi))
                {
                    e.Value = string.Format("{0:N0} VND", phi);
                }
            };
            lb_phishipFormDHA.DataBindings.Add(phiShipBinding);



        }

       



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
        }






        private void button_capnhat_Click(object sender, EventArgs e)
        {

            string trangthai = lb_trangtFormDHA.Text;
            if(!trangthai.Equals("Đang Giao"))
            {
                MessageBox.Show("Đơn hàng đang có trang thái " + trangthai.ToUpper() + " . Chỉ được phép cập nhật đơn hàng khi trang thái là 'ĐANG GIAO' "); 
            }
            else
            {
                DonHang donHang = getDonHang();
                ThemShipperVaNgayGiao themShipperVaNgayGiao = new ThemShipperVaNgayGiao(donHang);
                themShipperVaNgayGiao.ShowDialog(); 
                loadData();
                setDonHang();
            }
           





        }
        public DonHang getDonHang()
        {
            DonHang donHang = new DonHang();
            string madonHang = dataGridView1.CurrentRow.Cells["maDH"].Value.ToString();
            int maDH = Convert.ToInt32(madonHang);
            donHang = DonHangDAO.Instance.getDonHangById(maDH);
            return donHang;

        }
        private void button1_Click(object sender, EventArgs e)
        {
           DonHang donHang = getDonHang();  
            ChiTietDonHang chiTietDonHang = new ChiTietDonHang(donHang);  
            chiTietDonHang.ShowDialog();    
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
                status = 2;
            }
            else if (comboBox2.Text.Equals("Thất Bại"))
            {
                status = 3;
            }
            else
            {
                status = 1;
            }
           

            var result = DonHangDAO.Instance.fillter(dateString, status);
            if (result != null && result.Rows.Count > 0)
            {
                dataGridView1.DataSource = result;
                dataGridView1.Columns[0].HeaderText = "Mã Đơn Hàng";
                dataGridView1.Columns[1].HeaderText = "Tên SP";
                dataGridView1.Columns[2].HeaderText = "Tên KH";
                dataGridView1.Columns[3].HeaderText = "Kho";
                dataGridView1.Columns[4].HeaderText = "Tên Shipper";
                dataGridView1.Columns[5].HeaderText = "Tổng Tiền";
                dataGridView1.Columns[6].HeaderText = "Khuyến Mãi";
                dataGridView1.Columns[7].HeaderText = "Cần Thu";
                dataGridView1.Columns[8].HeaderText = "Trạng Thái";
                dataGridView1.Columns[9].HeaderText = "Ngày Tạo";
                dataGridView1.Columns[10].HeaderText = "Địa Chỉ";
                dataGridView1.Columns[11].HeaderText = "Ngày Giao";
                dataGridView1.Columns[12].HeaderText = "Phí Ship";




                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 50;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 80;
                dataGridView1.Columns[6].Width = 80;
                dataGridView1.Columns[7].Width = 80;
                dataGridView1.Columns[8].Width = 180;
                dataGridView1.Columns[9].Width = 80;
                dataGridView1.Columns[10].Width = 80;
                dataGridView1.Columns[11].Width = 80;
                dataGridView1.Columns[12].Width = 80;
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
                MessageBox.Show("Không tìm thấy đơn hàng phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            setDonHang();
            ThongKe();

        }

        private void button3_Click(object sender, EventArgs e)

        {
            string str = textBox3.Text;
            dataGridView1.DataSource = DonHangDAO.Instance.findForAdmin(str);
            dataGridView1.Columns[0].HeaderText = "Mã Đơn Hàng";
            dataGridView1.Columns[1].HeaderText = "Tên SP";
            dataGridView1.Columns[2].HeaderText = "Tên KH";
            dataGridView1.Columns[3].HeaderText = "Kho";
            dataGridView1.Columns[4].HeaderText = "Tên Shipper";
            dataGridView1.Columns[5].HeaderText = "Tổng Tiền";
            dataGridView1.Columns[6].HeaderText = "Khuyến Mãi";
            dataGridView1.Columns[7].HeaderText = "Cần Thu";
            dataGridView1.Columns[8].HeaderText = "Trạng Thái";
            dataGridView1.Columns[9].HeaderText = "Ngày Tạo";
            dataGridView1.Columns[10].HeaderText = "Địa Chỉ";
            dataGridView1.Columns[11].HeaderText = "Ngày Giao";
            dataGridView1.Columns[12].HeaderText = "Phí Ship";




            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 80;
            dataGridView1.Columns[8].Width = 180;
            dataGridView1.Columns[9].Width = 80;
            dataGridView1.Columns[10].Width = 80;
            dataGridView1.Columns[11].Width = 80;
            dataGridView1.Columns[12].Width = 80;
            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            setDonHang();

        }



        private void ThongKe()
        {
            DateTime dateFilter = dateTimePicker2.Value.Date;
            string dateString = dateFilter.ToString("yyyy-MM-dd");
            DataTable dt = DonHangDAO.Instance.Thongke(dateFilter);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                lb_tongDHFormDHA.Text = row["TongSoDonHang"].ToString();
                lb_tcFormDHA.Text = row["SoDonThanhCong"].ToString();
                lb_tbFormDHA.Text = row["SoDonThatBai"].ToString();
                lb_danggiao.Text = row["SoDonDangGiao"].ToString();
                lb_ttth_formDHA.Text = String.Format("{0:N0} VND", row["TongTien"]); 
                lb_doanhthu_formDHA.Text = String.Format("{0:N0} VND", row["TongPhiShipSauGiam"]);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            DonHang donHang = getDonHang();
            DonHang don = DonHangDAO.Instance.getDonHangById(donHang.MaDH);

            if (don.TrangThaiGH == 1)
            {
                ApDungKhuyenMaiChoDonHang apDungKhuyenMaiChoDonHang = new ApDungKhuyenMaiChoDonHang(donHang);
                apDungKhuyenMaiChoDonHang.ShowDialog();
                loadData();
                setDonHang();
            }
            else
            {
                MessageBox.Show(" Đơn hàng đã hoàn thành không được câp nhật khuyến mãi ");
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
