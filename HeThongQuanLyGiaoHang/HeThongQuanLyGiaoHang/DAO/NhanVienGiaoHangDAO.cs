using HeThongQuanLyGiaoHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyGiaoHang.DAO
{
    public class NhanVienGiaoHangDAO
    {
        private static NhanVienGiaoHangDAO instance;

        public static NhanVienGiaoHangDAO Instance
        {
            get { if (instance == null) instance = new NhanVienGiaoHangDAO(); return NhanVienGiaoHangDAO.instance; }
            private set { NhanVienGiaoHangDAO.instance = value; }
        }

        private NhanVienGiaoHangDAO() { }

        public DataTable loadNhanVienGiaoHang ()
        {
            string sql = " SELECT MANGUOIDUNG, TENDANGNHAP  , TEN  , NGAYSINH, SODIENTHOAI , EMAIL , CCCD , DIACHI , VOHIEUHOA ,GHICHU FROM NGUOIDUNG WHERE VAITRO = 2"; 
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);

                return data;



            }
            catch (Exception ex)
            {
                Console.WriteLine(" Loi  :  " + ex);
                return null;

            }
        }

        public DataTable find(string str)
        {
            string sql = @"
                    SELECT MANGUOIDUNG, TENDANGNHAP, TEN,NGAYSINH, SODIENTHOAI, EMAIL, CCCD, DIACHI, VOHIEUHOA, GHICHU
                    FROM NGUOIDUNG
                    WHERE VAITRO = 2 
                    AND (MANGUOIDUNG = ISNULL(TRY_CONVERT(int, @str), -1) 
                      OR TEN COLLATE SQL_Latin1_General_CP1_CI_AI LIKE N'%' + @str)";


            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { str });
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực hiện truy vấn: " + ex.Message);
                return null;
            }
        }

        public int getCount()
        {
            string sql = "Select count(*) as Soluong from NGUOIDUNG where VAITRO =  2 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);

            foreach (DataRow row in data.Rows)
            {
                int count = Convert.ToInt32(row["Soluong"]);
                return count;


            }
            return -1;
        }

        public int getMaxMND()
        {
            string sql = "select max(MANGUOIDUNG) as max from NGUOIDUNG";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);

            foreach (DataRow row in data.Rows)
            {
                int count = Convert.ToInt32(row["max"]);
                return count;


            }
            return -1;
        }

        public int ThemNhanVienGiaoHang(NguoiDung nguoiDung)
        {
            string sql = @"INSERT INTO NGUOIDUNG (TENDANGNHAP, MATKHAU, VAITRO, TEN, SODIENTHOAI, EMAIL, CCCD, DIACHI, VOHIEUHOA, NgaySinh) 
                            Values(@TenDangNhap , @MatKhau , @VaiTro , @Ten , @SDT , @Email , @CCCD , @DiaChi , @VoHieuHoa , @NgaySinh)
                        ";
            try
            {
                int data = DataProvider.Instance.ExecuteNonQuery(sql , new object[]
            {
                nguoiDung.TenDangNhap , nguoiDung.MatKhau , 2 , nguoiDung.ten , nguoiDung.SDT ,nguoiDung.email ,  nguoiDung.cccd , nguoiDung.diaChi , nguoiDung.VoHieuHoa , nguoiDung.ngaySinh
            });

                return data; 
            }

            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực hiện truy vấn: " + ex.Message);
                return -1;
            }
        }

        public int CapNhatNhanVienGiaoHang(NguoiDung nguoiDung)
        {
            string sql = @"UPDATE NGUOIDUNG
                          SET 
                          TEN = @TEN, 
                          SODIENTHOAI = @SODIENTHOAI, 
                          EMAIL = @EMAIL, 
                          CCCD = @CCCD, 
                          DIACHI = @DIACHI 
                          WHERE MANGUOIDUNG = @MaNguoiDung ;
                        ";
            try
            {
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[]
            {
                nguoiDung.ten , nguoiDung.SDT , nguoiDung.email , nguoiDung.cccd ,nguoiDung.diaChi , nguoiDung.maNguoiDung
            });

                return data;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực hiện truy vấn: " + ex.Message);
                return -1;
            }
        }




        public int KiemTraDonHang(NguoiDung nguoiDung)
        {
            string sql = @"SELECT COUNT(DH.MADH) as SO_DON_HOAN_THANH
                   FROM DONHANG DH 
                   WHERE DH.MASHI = @MaNguoiDung 
                         AND DH.TRANGTHAIGH IN (2, 3)
                        ";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql , new object[] {nguoiDung.maNguoiDung});

            foreach (DataRow row in data.Rows)
            {
                int count = Convert.ToInt32(row["SO_DON_HOAN_THANH"]);
                return count;


            }
            return -1;
        }
    

        public int XoaNhanVien(NguoiDung nguoiDung)
        {
            string sql = " Delete from NGUOIDUNG WHERE MANGUOIDUNG = @MANGUOIDUNG ";
            try
            {
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[]
            {
                nguoiDung.maNguoiDung
            });

                return data;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực hiện truy vấn: " + ex.Message);
                return -1;
            }
        }

        public int VoHieuHoa( int vohieuhoa,  string ghichu , NguoiDung nguoiDung)
        {
            string sql = " Update  NGUOIDUNG set VOHIEUHOA = @VOHIEUHOA  ,  GHICHU = @GHICHU  WHERE MANGUOIDUNG = @MANGUOIDUNG ";
            try
            {
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[]
            {
                 vohieuhoa , ghichu,  nguoiDung.maNguoiDung
            });

                return data;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực hiện truy vấn: " + ex.Message);
                return -1;
            }
        }



    }
}
