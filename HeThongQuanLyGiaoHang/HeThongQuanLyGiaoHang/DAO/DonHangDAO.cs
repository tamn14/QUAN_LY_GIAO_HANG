using HeThongQuanLyGiaoHang.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HeThongQuanLyGiaoHang.DAO
{
    public class DonHangDAO
    {
        private static DonHangDAO instance;

        public static DonHangDAO Instance
        {
            get { if (instance == null) instance = new DonHangDAO(); return DonHangDAO.instance; }
            private set { DonHangDAO.instance = value; }
        }

        private DonHangDAO() { }

        public DataTable loadDonHang(NguoiDung nguoiDung)

        {
            if (nguoiDung == null)
            {
                Console.WriteLine("Người dùng không tồn tại");
                return null;
            }
            string sql = @"SELECT DH.MADH AS maDH,   
                           SP.tenSP AS tenSP,   
                           KH.TENKH AS tenKH,   
                           DH.DIACHIGH AS diaChi,   
                           DH.TONGTIEN AS tongTien,   
                           DH.NGAYGIAO AS ngayGiao,
                           ISNULL(SUM(KM.PHANTRAMGIAM), 0) AS totalDiscount, 
                          (DH.TONGTIEN + DH.PHISHIP) - ((DH.TONGTIEN + DH.PHISHIP) * ISNULL(SUM(KM.PHANTRAMGIAM), 0) / 100) AS soTienCanThu,
                           DH.TrangThaiGH as trangthai , 
                            DH.PHISHIP as phiship
                    FROM DONHANG DH  
                    JOIN KHACHHANG KH ON DH.MAKH = KH.MAKH 
                    LEFT JOIN CHITIET_KHUYENMAI CTKM ON CTKM.MADH = DH.MADH
                    LEFT JOIN KHUYENMAI KM ON KM.MAKM = CTKM.MAKM
                    JOIN CHITIET_DONHANG CT ON CT.MADH = DH.MADH 
                    JOIN SANPHAM SP ON CT.MASP = SP.MASP 
                    JOIN NGUOIDUNG SH ON DH.MASHI = SH.MANGUOIDUNG    
                    WHERE SH.TENDANGNHAP = @tendangnhap 
                          AND DH.TRANGTHAIGH = 1  
                          AND (DH.NGAYGIAO <= CAST(GETDATE() AS DATE))  
                    GROUP BY DH.MADH, SP.tenSP, KH.TENKH, DH.PHISHIP  ,DH.DIACHIGH, DH.TONGTIEN, DH.NGAYGIAO, DH.TrangThaiGH  
                    ORDER BY DH.NGAYGIAO ASC;
                    ";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[]
                {

                    nguoiDung.TenDangNhap ,
                 });
                return data;



            }
            catch (Exception ex)
            {
                return null;
            }
        }

      

        public DonHang getDonHangById(int id)
        {
            string sql = "select * from DONHANG where MaDH  = @MaDH";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { id });
            DonHang donHang = new DonHang();
            foreach (DataRow row in data.Rows)
            {
                int maDH = Convert.ToInt32(row["MADH"]);
                int TrangThaiGH = Convert.ToInt32(row["TRANGTHAIGH"]);
                donHang.MaDH = maDH;
                donHang.TrangThaiGH= TrangThaiGH;   
               
               

            }
            return donHang;


        }

        public int getMaKH(int MADH)
        {
            string sql = "select makh from DONHANG  WHERE MADH = @MADH";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { MADH });

            foreach (DataRow row in data.Rows)
            {
                int maSP = Convert.ToInt32(row["MAKH"]);
                return maSP;

            }
            return -1;
        }




        public DataTable find(string tenDangNhap, string tuKhoa)
        {
            string sql = @"SELECT DH.MADH AS maDH,   
                           SP.tenSP AS tenSP,   
                           KH.TENKH AS tenKH,   
                           DH.DIACHIGH AS diaChi,   
                           DH.TONGTIEN AS tongTien,   
                           DH.NGAYGIAO AS ngayGiao,
                           ISNULL(SUM(KM.PHANTRAMGIAM), 0) AS totalDiscount, 
                          (DH.TONGTIEN + DH.PHISHIP) - ((DH.TONGTIEN + DH.PHISHIP) * ISNULL(SUM(KM.PHANTRAMGIAM), 0) / 100) AS soTienCanThu,
                           DH.TrangThaiGH as trangthai , 
                             DH.PHISHIP as phiship
                    FROM DONHANG DH  
                    JOIN KHACHHANG KH ON DH.MAKH = KH.MAKH 
                    LEFT JOIN CHITIET_KHUYENMAI CTKM ON CTKM.MADH = DH.MADH
                    LEFT JOIN KHUYENMAI KM ON KM.MAKM = CTKM.MAKM
                    JOIN CHITIET_DONHANG CT ON CT.MADH = DH.MADH 
                    JOIN SANPHAM SP ON CT.MASP = SP.MASP 
                    JOIN NGUOIDUNG SH ON DH.MASHI = SH.MANGUOIDUNG    
                    WHERE SH.TENDANGNHAP = @tenDangNhap 
                              AND DH.TRANGTHAIGH = 1  
                              AND (DH.NGAYGIAO <= CAST(GETDATE() AS DATE))
                              AND (SP.TENSP COLLATE SQL_Latin1_General_CP1_CI_AI LIKE @tuKhoa + '%' 
                                  OR DH.MADH = TRY_CONVERT(int, @tuKhoa))  
                    GROUP BY DH.MADH, SP.tenSP, KH.TENKH, DH.PHISHIP ,  DH.DIACHIGH, DH.TONGTIEN, DH.NGAYGIAO, DH.TrangThaiGH  
                    ORDER BY DH.NGAYGIAO ASC;
                    ";
           

            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { tenDangNhap, tuKhoa });
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực hiện truy vấn: " + ex.Message);
                return new DataTable();
            }
        }

        public List<DonHang> getDiaCHiGiaoHang(int mashi)
        {
            List<DonHang> LIST = new List<DonHang>();
            string sql = "select DISTINCT(diachigh) from Donhang,NguoiDung where MaSHI = MaNguoiDung and TRANGTHAIGH = 1  ";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { mashi});

            foreach (DataRow row in data.Rows)
            {
                DonHang donHang = new DonHang();
               
                string diaChi = (row["DIACHIGH"]).ToString();
               
                donHang.DiaChiGH = diaChi;
                LIST.Add(donHang);

            }
            return LIST;

        }

        public DataTable FilleDonHangForShip(string tenDangNhap, string str)
        {
            
            string sql = @"SELECT DH.MADH AS maDH,   
                           SP.tenSP AS tenSP,   
                           KH.TENKH AS tenKH,   
                           DH.DIACHIGH AS diaChi,   
                           DH.TONGTIEN AS tongTien,   
                           DH.NGAYGIAO AS ngayGiao,
                           ISNULL(SUM(KM.PHANTRAMGIAM), 0) AS totalDiscount, 
                         (DH.TONGTIEN + DH.PHISHIP) - ((DH.TONGTIEN + DH.PHISHIP) * ISNULL(SUM(KM.PHANTRAMGIAM), 0) / 100) AS soTienCanThu,
                           DH.TrangThaiGH as trangthai , 
                            DH.PHISHIP as phiship
                    FROM DONHANG DH  
                    JOIN KHACHHANG KH ON DH.MAKH = KH.MAKH 
                    LEFT JOIN CHITIET_KHUYENMAI CTKM ON CTKM.MADH = DH.MADH
                    LEFT JOIN KHUYENMAI KM ON KM.MAKM = CTKM.MAKM
                    JOIN CHITIET_DONHANG CT ON CT.MADH = DH.MADH 
                    JOIN SANPHAM SP ON CT.MASP = SP.MASP 
                    JOIN NGUOIDUNG SH ON DH.MASHI = SH.MANGUOIDUNG    
                    WHERE SH.TENDANGNHAP = @tenDangNhap 
                              AND DH.TRANGTHAIGH = 1 AND DH.DIACHIGH COLLATE SQL_Latin1_General_CP1_CI_AI LIKE @tuKhoa + '%'
                    GROUP BY DH.MADH, SP.tenSP, KH.TENKH, DH.PHISHIP ,  DH.DIACHIGH, DH.TONGTIEN, DH.NGAYGIAO, DH.TrangThaiGH  
                    ORDER BY DH.NGAYGIAO ASC;
                    ";


            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { tenDangNhap, str });
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực hiện truy vấn: " + ex.Message);
                return new DataTable();
            }
        }

        public DataTable findForAdmin(string tuKhoa)
        {
            string sql = @"
                             SELECT 
                            dh.MADH as maDh, 
                            sp.TENSP as tenSP, 
                            KH.TENKH as tenKH, 
                            k.TENK AS TENKHO, 
                            ND.TEN AS TENSHIPPER, 
                            dh.TONGTIEN as tongTien, 
                            ISNULL(SUM(KM.PHANTRAMGIAM), 0) AS totalDiscount, 
                            (DH.TONGTIEN + DH.PHISHIP) - ((DH.TONGTIEN + DH.PHISHIP) * ISNULL(SUM(KM.PHANTRAMGIAM), 0) / 100) AS soTienCanThu,
                            dh.TRANGTHAIGH as trangThai, 
                            dh.NGAYTAO as ngayTao, 
                            dh.DIACHIGH as diaChi, 
                            dh.NGAYGIAO as ngayGiao, 
                            dh.PHISHIP as phiShip 
                        FROM DONHANG dh
                        LEFT JOIN CHITIET_DONHANG CTDH ON CTDH.MADH = DH.MADH
                        LEFT JOIN KHACHHANG KH ON KH.MAKH = DH.MAKH
                        LEFT JOIN SANPHAM sp ON CTDH.MASP = sp.MASP
                        LEFT JOIN NGUOIDUNG ND ON ND.MANGUOIDUNG = DH.MASHI
                        LEFT JOIN KHO k ON dh.MAK = k.MAK
                        LEFT JOIN CHITIET_KHUYENMAI CTKM ON CTKM.MADH = DH.MADH
                        LEFT JOIN KHUYENMAI KM ON KM.MAKM = CTKM.MAKM
                        WHERE 
                              (SP.TENSP COLLATE SQL_Latin1_General_CP1_CI_AI LIKE @tuKhoa + '%' 
                                  OR DH.MADH = TRY_CONVERT(int, @tuKhoa))
                        GROUP BY 
                            dh.MADH, sp.TENSP, KH.TENKH, k.TENK, ND.TEN, dh.TONGTIEN, 
                            dh.TRANGTHAIGH, dh.NGAYTAO, dh.DIACHIGH, dh.NGAYGIAO, dh.PHISHIP
                         ORDER BY 
                            CASE 
                                WHEN dh.NGAYGIAO IS NULL THEN 0  
                                ELSE 1 
                            END,
                            dh.NGAYTAO DESC;
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


        public DataTable loadDonHangForAdmin()

        {

            string sql = @"
                           SELECT 
                            dh.MADH as maDh, 
                            sp.TENSP as tenSP, 
                            KH.TENKH as tenKH, 
                            k.TENK AS TENKHO, 
                            ND.TEN AS TENSHIPPER, 
                            dh.TONGTIEN as tongTien, 
                            ISNULL(SUM(KM.PHANTRAMGIAM), 0) AS totalDiscount, 
                          (dh.TONGTIEN + dh.PHISHIP) - (dh.PHISHIP * ISNULL(SUM(KM.PHANTRAMGIAM), 0) / 100) AS soTienCanThu,
                            dh.TRANGTHAIGH as trangThai, 
                            dh.NGAYTAO as ngayTao, 
                            dh.DIACHIGH as diaChi, 
                            dh.NGAYGIAO as ngayGiao, 
                            dh.PHISHIP as phiShip 
                        FROM DONHANG dh
                        LEFT JOIN CHITIET_DONHANG CTDH ON CTDH.MADH = DH.MADH
                        LEFT JOIN KHACHHANG KH ON KH.MAKH = DH.MAKH
                        LEFT JOIN SANPHAM sp ON CTDH.MASP = sp.MASP
                        LEFT JOIN NGUOIDUNG ND ON ND.MANGUOIDUNG = DH.MASHI
                        LEFT JOIN KHO k ON dh.MAK = k.MAK
                        LEFT JOIN CHITIET_KHUYENMAI CTKM ON CTKM.MADH = DH.MADH
                        LEFT JOIN KHUYENMAI KM ON KM.MAKM = CTKM.MAKM
                        GROUP BY 
                            dh.MADH, sp.TENSP, KH.TENKH, k.TENK, ND.TEN, dh.TONGTIEN, 
                            dh.TRANGTHAIGH, dh.NGAYTAO, dh.DIACHIGH, dh.NGAYGIAO, dh.PHISHIP 
                        ORDER BY 
                            CASE 
                                WHEN dh.NGAYGIAO IS NULL THEN 0  
                                ELSE 1 
                            END,
                            dh.NGAYTAO DESC;

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

        public int updateTTGH(int TrangThai)
        {


            try
            {
                string sql = " Update  DONHANG   set  TRANGTHAIGH = @TRANGTHAIGH ";
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { TrangThai });
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi :  " + e);
                return -1;

            }




        }

        public int update(int maShip, DateTime ngayGiao, int MaDH)
        {


            try
            {
                string sql = " Update  DONHANG   set  MASHI = @MaShip , NGAYGIAO  = @NgayGiao  where MaDH = @MaDH";
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { maShip, ngayGiao, MaDH });
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi :  " + e);
                return -1;

            }




        }

        public DataTable fillter(string dateFilter, int? status)
        {
            

            try
            {
                string sql = @"
                           SELECT 
                            dh.MADH as maDh, 
                            sp.TENSP as tenSP, 
                            KH.TENKH as tenKH, 
                            k.TENK AS TENKHO, 
                            ND.TEN AS TENSHIPPER, 
                            dh.TONGTIEN as tongTien, 
                            ISNULL(SUM(KM.PHANTRAMGIAM), 0) AS totalDiscount, 
                           (DH.TONGTIEN + DH.PHISHIP) - ((DH.TONGTIEN + DH.PHISHIP) * ISNULL(SUM(KM.PHANTRAMGIAM), 0) / 100) AS soTienCanThu,
                            dh.TRANGTHAIGH as trangThai, 
                            dh.NGAYTAO as ngayTao, 
                            dh.DIACHIGH as diaChi, 
                            dh.NGAYGIAO as ngayGiao, 
                            dh.PHISHIP as phiShip 
                        FROM DONHANG dh
                        LEFT JOIN CHITIET_DONHANG CTDH ON CTDH.MADH = DH.MADH
                        LEFT JOIN KHACHHANG KH ON KH.MAKH = DH.MAKH
                        LEFT JOIN SANPHAM sp ON CTDH.MASP = sp.MASP
                        LEFT JOIN NGUOIDUNG ND ON ND.MANGUOIDUNG = DH.MASHI
                        LEFT JOIN KHO k ON dh.MAK = k.MAK
                        LEFT JOIN CHITIET_KHUYENMAI CTKM ON CTKM.MADH = DH.MADH
                        LEFT JOIN KHUYENMAI KM ON KM.MAKM = CTKM.MAKM
                        Where  CONVERT(Date, dh.NGAYGIAO) = @dateFiller 
                        ";

                if (status.HasValue)
                {
                    sql += " AND dh.TRANGTHAIGH = @Status ";
                }
                sql += " GROUP BY  dh.MADH, sp.TENSP, KH.TENKH, k.TENK, ND.TEN, dh.TONGTIEN,  dh.TRANGTHAIGH, dh.NGAYTAO, dh.DIACHIGH, dh.NGAYGIAO, dh.PHISHIP   ORDER BY   CASE   WHEN dh.NGAYGIAO IS NULL THEN 0  ELSE 1 END, dh.NGAYTAO DESC;";

                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[]
                {

            dateFilter,
            status.HasValue ? (object)status.Value : DBNull.Value
                });

                if (data.Rows.Count == 0)
                {
                    Console.WriteLine(sql);
                    Console.WriteLine($"Status: {status}, DateFilter: {dateFilter}");
                    return new DataTable();
                }

                return data;
            }




            catch (Exception ex)
            {
                Console.WriteLine("Lỗi : " + ex);

                return null;
            }
        }



        public DataTable Thongke(DateTime dateFilter)
        {
            string sql = @"
                           SELECT 
                           COUNT(*) AS TongSoDonHang,
                           SUM(CASE WHEN TRANGTHAIGH = 2 THEN 1 ELSE 0 END) AS SoDonThanhCong,
                            SUM(CASE WHEN TRANGTHAIGH = 3 THEN 1 ELSE 0 END) AS SoDonThatBai,
                             SUM(CASE WHEN TRANGTHAIGH = 1 THEN 1 ELSE 0 END) AS SoDonDangGiao,
                            SUM(CASE WHEN TRANGTHAIGH = 2 THEN TONGTIEN ELSE 0 END) AS TongTien,
                            SUM(CASE WHEN TRANGTHAIGH = 2 
                               THEN PHISHIP - (PHISHIP * ISNULL(KM.TongPhanTramGiam, 0) / 100) 
                                 ELSE 0 END) AS TongPhiShipSauGiam
                            FROM DONHANG DH
                            LEFT JOIN (
                            SELECT CTKM.MADH, SUM(KM.PHANTRAMGIAM) AS TongPhanTramGiam
                              FROM CHITIET_KHUYENMAI CTKM
                            JOIN KHUYENMAI KM ON CTKM.MAKM = KM.MAKM
                            GROUP BY CTKM.MADH
                             ) KM ON DH.MADH = KM.MADH
                             WHERE CAST(NGAYGIAO AS DATE) = @dateFiller ";

            try
            {
                // Sử dụng SqlParameter để tránh lỗi kiểu dữ liệu
                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { dateFilter });
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return null;
            }
        }


        public DataTable BaoCaoThongKe()
        {
            string sql = @"SELECT 
                        COUNT(*) AS TongSoDonHang,
                        SUM(CASE WHEN TRANGTHAIGH = 2 THEN 1 ELSE 0 END) AS SoDonThanhCong,
                        SUM(CASE WHEN TRANGTHAIGH = 2 THEN TONGTIEN ELSE 0 END) AS TongTien,
                        SUM(CASE WHEN TRANGTHAIGH = 2 THEN PHISHIP ELSE 0 END) AS TongPhiShip
                    FROM DONHANG
                    ";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                return data;



            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi  : " + ex);
                return null;
            }
        }

        public Dictionary<DateTime, int> ThongKeDoanhThu()
        {
            string sql = "SELECT YEAR(NGAYTAO) AS NAM, MONTH(NGAYTAO) AS THANG, SUM(PhiShip) AS DOANHTHU " +
                         "FROM DONHANG " +
                         "WHERE TRANGTHAIGH = 2 " +
                         "GROUP BY YEAR(NGAYTAO), MONTH(NGAYTAO) " +
                         "ORDER BY NAM ASC, THANG ASC";

            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                Dictionary<DateTime, int> list = new Dictionary<DateTime, int>();

                foreach (DataRow row in data.Rows)
                {
                    int nam = Convert.ToInt32(row["NAM"]);
                    int thang = Convert.ToInt32(row["THANG"]);
                    int doanhThu = Convert.ToInt32(row["DOANHTHU"]);

                    DateTime key = new DateTime(nam, thang, 1);  // Sử dụng cả năm và tháng

                    if (list.ContainsKey(key))
                    {
                        list[key] += doanhThu;
                    }
                    else
                    {
                        list.Add(key, doanhThu);
                    }
                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e);
                return new Dictionary<DateTime, int>();
            }
        }

        public Dictionary<string, double> ThongKeTyLeDonHang()
        {
            string sql = "SELECT TRANGTHAIGH, COUNT(*) AS SoLuong " +
                         "FROM DONHANG " +
                         "GROUP BY TRANGTHAIGH";

            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                Dictionary<string, double> list = new Dictionary<string, double>();

                int tongSoDonHang = data.AsEnumerable().Sum(row => row.Field<int>("SoLuong"));

                foreach (DataRow row in data.Rows)
                {
                    int trangThai = Convert.ToInt32(row["TRANGTHAIGH"]);
                    int soLuong = Convert.ToInt32(row["SoLuong"]);
                    double tyLe = (soLuong * 100.0) / tongSoDonHang;

                    string trangThaiText = "";

                    switch (trangThai)
                    {
                        case 2:
                            trangThaiText = "Thành Công";
                            break;
                        case 3:
                            trangThaiText = "Thất Bại";
                            break;
                        case 1:
                            trangThaiText = "Đang Giao";
                            break;
                        default:
                            trangThaiText = "Khác";
                            break;
                    }

                    list[trangThaiText] = tyLe;
                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e);
                return new Dictionary<string, double>();
            }
        }



        public DataTable BaoCaoThongKeTheoKhoanThoiGian(string dateBegin, string dateEnd)
        {
            string sql = @" SELECT COUNT(*) AS TongSoDonHang, SUM(CASE WHEN TRANGTHAIGH = 2 THEN 1 ELSE 0 END) AS SoDonThanhCong, SUM(CASE WHEN TRANGTHAIGH = 2 THEN TONGTIEN ELSE 0 END) AS TongTien, SUM(CASE WHEN TRANGTHAIGH = 2 THEN PHISHIP ELSE 0 END) AS TongPhiShip  FROM DONHANG  WHERE NGAYGIAO BETWEEN @DateBegin AND @DateEnd ";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { dateBegin, dateEnd });
                return data;



            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi  : " + ex);
                Console.WriteLine(dateBegin + "   " + dateEnd);
                return new DataTable();
            }
        }




        public Dictionary<DateTime, int> ThongKeDoanhThuTheoKhoanThoiGian(string dateBegin, string dateEnd)
        {
            string sql = "SELECT CAST(NGAYTAO AS DATE) AS NGAY, SUM(PhiShip) AS DOANHTHU FROM DONHANG WHERE TRANGTHAIGH = 2 AND NGAYGIAO BETWEEN @DateBegin AND @DateEnd GROUP BY CAST(NGAYTAO AS DATE) ORDER BY NGAY ASC;";

            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { dateBegin, dateEnd });
                Dictionary<DateTime, int> list = new Dictionary<DateTime, int>();

                foreach (DataRow row in data.Rows)
                {
                    DateTime ngay = Convert.ToDateTime(row["NGAY"]);

                    int doanhThu = Convert.ToInt32(row["DOANHTHU"]);

                    if (list.ContainsKey(ngay))
                    {
                        list[ngay] += doanhThu;
                    }
                    else
                    {
                        list.Add(ngay, doanhThu);
                    }
                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e);
                return new Dictionary<DateTime, int>();
            }
        }


        public Dictionary<string, double> ThongKeTyLeDonHangTheoKhoanThoiGian(string dateBegin, string dateEnd)
        {
            string sql = "SELECT TRANGTHAIGH, COUNT(*) AS SoLuong  FROM DONHANG WHERE NGAYGIAO BETWEEN @DateBegin AND @DateEnd GROUP BY TRANGTHAIGH";

            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { dateBegin, dateEnd });
                Dictionary<string, double> list = new Dictionary<string, double>();

                int tongSoDonHang = data.AsEnumerable().Sum(row => row.Field<int>("SoLuong"));

                foreach (DataRow row in data.Rows)
                {
                    int trangThai = Convert.ToInt32(row["TRANGTHAIGH"]);
                    int soLuong = Convert.ToInt32(row["SoLuong"]);
                    double tyLe = (soLuong * 100.0) / tongSoDonHang;

                    string trangThaiText = "";

                    switch (trangThai)
                    {
                        case 2:
                            trangThaiText = "Thành Công";
                            break;
                        case 3:
                            trangThaiText = "Thất Bại";
                            break;
                        case 1:
                            trangThaiText = "Đang Giao";
                            break;
                        default:
                            trangThaiText = "Khác";
                            break;
                    }

                    list[trangThaiText] = tyLe;
                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e);
                return new Dictionary<string, double>();
            }
        }

        public int CapNhatDonHang(NguoiDung nguoiDung)
        {
            string sql = "UPDATE donhang SET mashi = NULL WHERE mashi = @Mashi";
            try
            {
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { nguoiDung.maNguoiDung });

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
