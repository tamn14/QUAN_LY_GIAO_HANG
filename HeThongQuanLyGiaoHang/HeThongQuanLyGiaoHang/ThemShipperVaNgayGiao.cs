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
    public partial class ThemShipperVaNgayGiao : Form
    {
        private DonHang donHang;  
        public ThemShipperVaNgayGiao(DonHang donHang)
        {
            InitializeComponent();
            this.donHang = donHang;
            loadDonHang();  
            loadNguoiDung();    
        }

        private void lb_kformDHA_Click(object sender, EventArgs e)
        {

        }

        

        public void loadDonHang()
        {
            lb_MaDHFormTSVNG.Text = donHang.MaDH.ToString();
        }

        public void loadNguoiDung()
        {
            List<NguoiDung> list = NguoiDungDAO.Instance.getNguoiDung();
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "ten";  
            comboBox1.ValueMember = "maNguoiDung";

           
            if (comboBox1.Items.Count > 0)
            {
                textBox1.Text = comboBox1.SelectedValue.ToString();
            }

           
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            textBox1.TextChanged += textBox1_TextChanged;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                textBox1.Text = comboBox1.SelectedValue.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int maND))
            {
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    NguoiDung nguoiDung = (NguoiDung)comboBox1.Items[i];
                    if (nguoiDung.maNguoiDung == maND)
                    {
                        comboBox1.SelectedIndex = i;
                        return;
                    }
                }
            }
        }
        public int update()
        {
            int maship = Convert.ToInt32(comboBox1.SelectedValue);
            DateTime ngayGiao = dateTimePicker1_formTSVNG.Value;
            int maDH = donHang.MaDH;
            string date = dateTimePicker1_formTSVNG.Value.ToString("yyyy-MM-dd");
            DialogResult result = MessageBox.Show(
               $"Bạn có chắc chắn muốn cập nhât đơn hàng này không?\n\n Mã Shipper  : **{maship.ToString().ToUpper()}** \n\n Ngày Giao : **{date.ToUpper()}** \n\n Mã Đơn Hàng : **{maDH.ToString().ToUpper()}**",
               "Xác nhận lưu",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            { 
                int check = DonHangDAO.Instance.update(maship, ngayGiao, maDH); 
                return check;


            }
            else
            {
                MessageBox.Show("Bạn đã hủy thao tác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return -1;
            }
                
           
        }

        private void button_capnhat_Click(object sender, EventArgs e)
        {
            
            int check  = update();
            if(check != -1)
            {
                MessageBox.Show("Cập nhật đơn hàng thành công !!!!");  
            }
            else
            {
                MessageBox.Show("Cập nhật đơn hàng thất bại "); 
            }
            this.Close();   
           
           
        }
    }
}
