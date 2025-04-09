using HeThongQuanLyGiaoHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyGiaoHang.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { AccountDAO.instance = value; }
        }

        private AccountDAO() { }

        public bool login(string username, string password)
        {
            string sql = "SELECT * FROM NguoiDung WHERE TenDangNhap = @TenDangNhap and MatKhau = @MatKhau";
            DataTable result = DataProvider.Instance.ExecuteQuery(sql, new object[] { username, password });
            return result.Rows.Count > 0;

        }

        public NguoiDung GetNguoiDungByName(string tenDangNhap)
        {

            string query = "SELECT * FROM NguoiDung WHERE TenDangNhap = @TenDangNhap";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenDangNhap });
            NguoiDung nguoiDung = new NguoiDung();

            if (data.Rows.Count > 0)
            {

                DataRow row = data.Rows[0];

                int maND = Convert.ToInt32(row["MANGUOIDUNG"]);
                string tenDangNhapDb = row["TenDangNhap"].ToString();
                string matkhau = row["MatKhau"].ToString();
                int vaiTro = Convert.ToInt32(row["VaiTro"]);
                string HoTen = row["TEN"].ToString();
                string SDT = row["SODIENTHOAI"].ToString(); 
                string email = row["EMAIL"].ToString();
                string CCCD = row["CCCD"].ToString();
                string diaChi = row["DIACHI"].ToString(); 


                nguoiDung.maNguoiDung = maND;
                nguoiDung.TenDangNhap = tenDangNhap;
                nguoiDung.MatKhau = matkhau;
                nguoiDung.VaiTro = vaiTro; 
                nguoiDung.ten = HoTen;
                nguoiDung.SDT = SDT;
                nguoiDung.email = email;
                nguoiDung.cccd = CCCD;
                nguoiDung.diaChi = diaChi; 

                return nguoiDung;
            }


            return null;
        }

        public int checkVoHieuHoa(string tenDangNhap)
        {

            string query = "SELECT VOHIEUHOA FROM NguoiDung WHERE TenDangNhap = @TenDangNhap";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenDangNhap });


            if (data.Rows.Count > 0)
            {

                DataRow row = data.Rows[0];



                int VoHieuHoa = Convert.ToInt32(row["VoHieuHoa"]);





                return VoHieuHoa;
            }
            return -1;


        }


        public int updateNguoidung(NguoiDung nguoiDung)
        {
            if (nguoiDung == null)
            {
                return 0;
            }

            string query = "Update NguoiDung set  MatKhau = @MatKhau where tenDangNhap = @TenDangNhap";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[]
                {
                    
                    nguoiDung.MatKhau , 
                    nguoiDung.TenDangNhap 
                });
                return 1;
            }
            catch (Exception ex)
            {

                return 0;
            }


        }

        public int Insert(NguoiDung nguoiDung)
        {
            string sql = "INSERT INTO NGUOIDUNG ( TENDANGNHAP , MATKHAU , VAITRO , VOHIEUHOA , GHICHU ) VALUES ( @TENDANGNHAP , @MATKHAU , @VAITRO , @VOHIEUHOA , @GHICHU) ; ";
            try
            {

                return DataProvider.Instance.ExecuteNonQuery(sql, new object[] {  nguoiDung.TenDangNhap , nguoiDung.MatKhau , 1  , nguoiDung.VoHieuHoa , nguoiDung.GhiChu});

            }
            catch (Exception e)
            {
                Console.WriteLine("Loi  : " + e);
                return -1;
            }
        }

        public int Update(NguoiDung nguoiDung)
        {
            string sql = @"UPDATE NGUOIDUNG  
                   SET VOHIEUHOA = @VOHIEUHOA,  
                       GHICHU = @GHICHU  
                   WHERE tendangnhap = @tendangnhap";

            try
            {
                return DataProvider.Instance.ExecuteNonQuery(sql, new object[] {
            nguoiDung.VoHieuHoa,
            nguoiDung.GhiChu,
            nguoiDung.TenDangNhap
        });
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
                return -1;
            }
        }




    }
}
