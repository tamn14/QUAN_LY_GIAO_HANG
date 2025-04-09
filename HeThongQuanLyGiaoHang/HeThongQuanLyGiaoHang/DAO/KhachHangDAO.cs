using HeThongQuanLyGiaoHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyGiaoHang.DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return KhachHangDAO.instance; }
            private set { KhachHangDAO.instance = value; }
        }

        private KhachHangDAO() { }

        public DataTable loadKhachHang()

        {

            string sql = @"
                           select  maKh , tenKh , Sodienthoai, diachi from KHACHHANG;
                        ";
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

        public DataTable find(string tuKhoa)
        {
            string sql = @"
                           select * from KHACHHANG where tenKh LIKE '%' + @Str + '%'
                        ";

            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { tuKhoa });
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
            string sql = "SELECT COUNT(*) AS Soluong FROM KHACHHANG;";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);

            foreach (DataRow row in data.Rows)
            {
                int count = Convert.ToInt32(row["Soluong"]);
                return count;


            }
            return -1;
        }

        public KhachHang getKH(int MAKH)
        {
            string sql = "SELECT * FROM KHACHHANG WHERE MAKH = @MAKH";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { MAKH });

            if (data.Rows.Count == 0)
                return null;

            try
            {
                DataRow row = data.Rows[0];
                KhachHang khachHang = new KhachHang();

                khachHang.MaKH = Convert.ToInt32(row["MAKH"]);
                khachHang.TenKH = row["TENKH"].ToString();
                khachHang.SoDienThoai = row["SODIENTHOAI"].ToString();
                khachHang.DiaChi = row["DIACHI"].ToString();

                return khachHang;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy chi tiết đơn hàng: " + ex.Message);
                return null;
            }
        }







    }
}
