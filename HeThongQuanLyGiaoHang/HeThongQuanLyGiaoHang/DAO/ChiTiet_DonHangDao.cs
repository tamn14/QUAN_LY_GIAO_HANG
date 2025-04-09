using HeThongQuanLyGiaoHang.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyGiaoHang.DAO
{
    public class ChiTiet_DonHangDao
    {
        private static ChiTiet_DonHangDao instance;

        public static ChiTiet_DonHangDao Instance
        {
            get { if (instance == null) instance = new ChiTiet_DonHangDao(); return ChiTiet_DonHangDao.instance; }
            private set { ChiTiet_DonHangDao.instance = value; }
        }

        private ChiTiet_DonHangDao() { }



        public ChiTiet_DonHang getCTDH(int MADH)
        {
            string sql = "SELECT  SOLUONG, GIABAN, THANHTIEN, KHOILUONG FROM CHITIET_DONHANG WHERE MADH = @MADH";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { MADH });

            if (data.Rows.Count == 0)
                return null;

            try
            {
                DataRow row = data.Rows[0]; 
                ChiTiet_DonHang chiTietDonHang = new ChiTiet_DonHang();

                chiTietDonHang.soLuong = Convert.ToInt32(row["SOLUONG"]);
                chiTietDonHang.giaBan = Convert.ToDecimal(row["GIABAN"]);
                chiTietDonHang.thanhTien = Convert.ToDecimal(row["THANHTIEN"]);
                chiTietDonHang.khoiLuong = Convert.ToDecimal(row["KHOILUONG"]);

                return chiTietDonHang;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy chi tiết đơn hàng: " + ex.Message); 
                return null;
            }
        }

        public int getMaSP(int MADH)
        {
            string sql = "select masp from CHITIET_DONHANG  WHERE MADH = @MADH";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { MADH });
            
            foreach (DataRow row in data.Rows)
            {
                int maSP = Convert.ToInt32(row["MASP"]);
                return maSP;

            }
            return -1;
        }

    }
}
