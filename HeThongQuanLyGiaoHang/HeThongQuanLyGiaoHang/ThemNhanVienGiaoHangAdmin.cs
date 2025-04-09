using HeThongQuanLyGiaoHang.DAO;
using HeThongQuanLyGiaoHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
namespace HeThongQuanLyGiaoHang
{
    public partial class ThemNhanVienGiaoHangAdmin : Form
    {
        public ThemNhanVienGiaoHangAdmin()
        {
            InitializeComponent();
        }

        static string GenerateSecurePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder password = new StringBuilder();
            byte[] randomNumber = new byte[1];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 6; i++)
                {
                    rng.GetBytes(randomNumber);
                    int index = randomNumber[0] % chars.Length;
                    password.Append(chars[index]);
                }
            }

            return password.ToString();
        }

        public int ThemNhanVienGiaoHang()
        {
            int max = NhanVienGiaoHangDAO.Instance.getMaxMND();  
            string tenNhanVien = txb_hoNVGHFormTNVGHA.Text.Trim() + " " +  txb_tenNVGHFormTNVGH.Text.Trim();  
            string SDT  = txb_SDTFormTNVGHA.Text.Trim();
            string email = txb_email_formTNVGHA.Text.Trim();
            string cccd = txb_CCCD_formTNVGHA.Text.Trim();
            string diaChi = txb_diachiFormTNVGHA.Text.Trim();
            string TenDangNhap = txb_tenNVGHFormTNVGH.Text.Trim() + "Ship" + (max + 1);
            string matkhau = GenerateSecurePassword();
            DateTime ngaySinh = dateTimePicker2.Value;  
            
            NguoiDung nguoiDung = new NguoiDung();
            nguoiDung.TenDangNhap = TenDangNhap; 
            nguoiDung.MatKhau = matkhau;
            nguoiDung.ten = tenNhanVien; 
            nguoiDung.SDT = SDT;
            nguoiDung.email = email;    
            nguoiDung.cccd = cccd;
            nguoiDung.diaChi = diaChi;
            nguoiDung.ngaySinh = ngaySinh; 

            int check = NhanVienGiaoHangDAO.Instance.ThemNhanVienGiaoHang(nguoiDung);
            SendMail(nguoiDung); 
            return check;   

            
           

            
        }

        public void SendMail(NguoiDung nguoiDung)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Hệ Thống Quản Lý Giao Hàng", "Tamn0443@gmail.com"));
                message.To.Add(new MailboxAddress(nguoiDung.ten, nguoiDung.email));
                message.Subject = "Thông Tin Tài Khoản";

                // Định dạng đúng nội dung email
                message.Body = new TextPart("html")
                {
                    Text = $@"
                <h1>Xin chào {nguoiDung.ten}!</h1>
                <p>Đây là thông tin đăng nhập của bạn:</p>
                <p><b>Tên Đăng Nhập:</b> {nguoiDung.TenDangNhap}</p>
                <p><b>Mật Khẩu:</b> {nguoiDung.MatKhau}</p>
                <p>Vui lòng đăng nhập và đổi mật khẩu ngay sau khi nhận được tài khoản.</p>"
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate("Tamn0443@gmail.com", "tavslahvwiatvbad"); 
                    client.Send(message);
                    client.Disconnect(true);
                }

                Console.WriteLine("Email đã gửi thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi gửi email: " + ex.Message);
            }
        }

        private void button_themNVGHA_Click(object sender, EventArgs e)
        {
           

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn thêm nhân viên này không? ",
                "Xác nhận lưu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int check = ThemNhanVienGiaoHang();
                MessageBox.Show(check != -1 ? " Thêm nhân viên thành công!" : "Thêm nhân viên thất bại!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                check != -1 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                this.Close();

            }
            else
            {
                MessageBox.Show("Bạn đã hủy thao tác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
    }
}
