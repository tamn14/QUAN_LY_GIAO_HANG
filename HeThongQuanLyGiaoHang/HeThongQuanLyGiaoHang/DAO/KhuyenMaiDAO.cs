using HeThongQuanLyGiaoHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyGiaoHang.DAO
{
    public class KhuyenMaiDAO
    {
        private static KhuyenMaiDAO instance;

        public static KhuyenMaiDAO Instance
        {
            get { if (instance == null) instance = new KhuyenMaiDAO(); return KhuyenMaiDAO.instance; }
            private set { KhuyenMaiDAO.instance = value; }
        }

        private KhuyenMaiDAO() { }


        public DataTable loadKhuyenMai()
        {
            string sql = @"Select * from KHUYENMAI ORDER BY NGAYKETTHUC DESC;
                    ";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[]
                {

                   
                 });
                return data;



            }
            catch (Exception ex)
            {
                return null;
            }
        }

       

        public int getCount()
        {
            string sql = "SELECT COUNT(*) AS Soluong FROM KHUYENMAI;";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);

            foreach (DataRow row in data.Rows)
            {
                int count = Convert.ToInt32(row["Soluong"]);
                return count;


            }
            return -1;
        }

        public int getCountByTime(DateTime DateBegin, DateTime DateEnd)
        {
            string sql = "SELECT COUNT(*) AS Soluong FROM KHUYENMAI WHERE NGAYBATDAU BETWEEN @DateBegin AND @DateEnd";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[]
                {
                    DateBegin , DateEnd

                 });

            foreach (DataRow row in data.Rows)
            {
                int count = Convert.ToInt32(row["Soluong"]);
                return count;


            }
            return -1;
        }

        public DataTable find(string str)
        {
            string sql = " select * from KHUYENMAI WHERE MAKM = TRY_CONVERT(int, @str) OR TENKM  COLLATE SQL_Latin1_General_CP1_CI_AI LIKE + '%' + @str + '%' ";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[]
                {

                    str
                 });
                return data;



            }
            catch (Exception ex)
            {
                Console.WriteLine( "Loi  : " + ex.Message);
                return null;
               
            }
        }

        public DataTable fillter(DateTime DateBegin , DateTime DateEnd)
        {
            string sql = " select * from KHUYENMAI WHERE NGAYBATDAU BETWEEN @DateBegin AND @DateEnd ";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[]
                {
                    DateBegin , DateEnd
                    
                 });
                return data;



            }
            catch (Exception ex)
            {
                return null;
            }
        }




        public int ThemKhuyenMai(KhuyenMai khuyenMai)
        {
            string sql = @"INSERT INTO KHUYENMAI (TENKM , PHANTRAMGIAM , NGAYBATDAU, NGAYKETTHUC) 
                            Values(@TENKM , @PHANTRAMGIAM , @NGAYBATDAU , @NGAYKETTHUC)
                        ";
            try
            {
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[]
            {
                khuyenMai.tenKM , khuyenMai.PhanTramGiamGia , khuyenMai.ngayBatDau , khuyenMai.ngayKetThuc
            });

                return data;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực hiện truy vấn: " + ex.Message);
                return -1;
            }
        }


        public int CapNhatKhuyenMai(KhuyenMai khuyenMai)
        {
            string sql = "UPDATE KHUYENMAI SET TENKM = @TENKM, PHANTRAMGIAM = @PHANTRAMGIAM , NGAYBATDAU = @NGAYBATDAU , NGAYKETTHUC = @NGAYKETTHUC WHERE MAKM = @MAKM ";
            try
            {
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { khuyenMai.tenKM , khuyenMai.PhanTramGiamGia , khuyenMai.ngayBatDau , khuyenMai.ngayKetThuc , khuyenMai.MaKM });
                Console.WriteLine(sql);
                return data;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực hiện truy vấn: " + ex.Message);
                return -1;
            }
        }

        public int XoaKhuyenMai(int  maKm)
        {
            string sql = " Delete from KHUYENMAI WHERE MAKM = @MAKM ";
            try
            {
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[]
            {
                maKm
            });

                return data;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực hiện truy vấn: " + ex.Message);
                return -1;
            }
        }



        public List<KhuyenMai> getKhuyenMai()
        {
            List<KhuyenMai> LIST = new List<KhuyenMai>();
            string sql = "SELECT * FROM KHUYENMAI WHERE NGAYKETTHUC >= GETDATE(); ";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);

            foreach (DataRow row in data.Rows)
            {
                KhuyenMai khuyenMai = new KhuyenMai();
                int maKm = Convert.ToInt32(row["MAKM"]);
                string ten = (row["TENKM"]).ToString();
                decimal phanTramGiam = Convert.ToDecimal(row["PHANTRAMGIAM"]);
                DateTime ngayBatDau = Convert.ToDateTime(row["NGAYBATDAU"]);
                DateTime ngayKetThuc = Convert.ToDateTime(row["NGAYKETTHUC"]);
                khuyenMai.MaKM = maKm;
                khuyenMai.tenKM = ten; 
                khuyenMai.PhanTramGiamGia = phanTramGiam;
                khuyenMai.ngayBatDau = ngayBatDau;  
                khuyenMai.ngayKetThuc = ngayKetThuc;

                LIST.Add(khuyenMai);


            }
            return LIST;

        }

        public KhuyenMai loadKhuyenMaiByID(int maKm)
        {
            string sql = "SELECT * FROM KHUYENMAI WHERE MAKM = @maKM";

            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { maKm });

                // Nếu không có dữ liệu, trả về null
                if (data.Rows.Count == 0)
                {
                    return null;
                }

                // Lấy dòng dữ liệu đầu tiên
                DataRow row = data.Rows[0];

                // Tạo đối tượng KhuyenMai
                KhuyenMai khuyenMai = new KhuyenMai
                {
                    MaKM = Convert.ToInt32(row["MAKM"]),
                    tenKM = row["TENKM"].ToString(),
                    PhanTramGiamGia = Convert.ToDecimal(row["PHANTRAMGIAM"]),
                    ngayBatDau = Convert.ToDateTime(row["NGAYBATDAU"]),
                    ngayKetThuc = Convert.ToDateTime(row["NGAYKETTHUC"])
                };

                return khuyenMai;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tải khuyến mãi: " + ex.Message);
                return null;
            }
        }






    }
}
