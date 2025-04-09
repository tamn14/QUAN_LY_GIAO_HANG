using HeThongQuanLyGiaoHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyGiaoHang.DAO
{
    public class ChiTiet_KhuyenMaiDao
    {
        private static ChiTiet_KhuyenMaiDao instance;

        public static ChiTiet_KhuyenMaiDao Instance
        {
            get { if (instance == null) instance = new ChiTiet_KhuyenMaiDao(); return ChiTiet_KhuyenMaiDao.instance; }
            private set { ChiTiet_KhuyenMaiDao.instance = value; }
        }

        private ChiTiet_KhuyenMaiDao() { }

        public int Insert(int maKm, int MaDh)
        {
            string sql = @"INSERT INTO CHITIET_KHUYENMAI (MADH  , MAKM) 
                            Values(@madh , @makm)
                        ";
            try
            {
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[]
                {
                    MaDh, maKm
                });
                return data;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực hiện truy vấn: " + ex.Message);
                return -1;
            }
        }

        public int check(int MaDh)
        {
            string sql = " SELECT COUNT(*) AS Soluong  FROM CHITIET_KHUYENMAI where  MADH = @MADH ";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] {MaDh});

            foreach (DataRow row in data.Rows)
            {
                int count = Convert.ToInt32(row["Soluong"]);
                return count;


            }
            return -1;
        }

        public int Remove( int MaDh)
        {
            string sql = " Delete FROM CHITIET_KHUYENMAI WHERE MADH = @MADH ";
            try
            {
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[]
                {
                    MaDh
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
