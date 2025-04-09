using HeThongQuanLyGiaoHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyGiaoHang.DAO
{
    public class LichSuGHDAO
    {
        private static LichSuGHDAO instance;

        public static LichSuGHDAO Instance
        {
            get { if (instance == null) instance = new LichSuGHDAO(); return LichSuGHDAO.instance; }
            private set { LichSuGHDAO.instance = value; }
        }

        private LichSuGHDAO() { }

        public int UpdateLSGH(int madh, int trangthai)
        {
            try
            {
                string sql = "EXEC SP_THEM_LICHSUGH @MADH, @TRANGTHAIMOI";

                
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { madh, trangthai });

                Console.WriteLine("Số dòng bị ảnh hưởng: " + data);

                return data; 
            }
            catch (Exception e)
            {
                
                Console.WriteLine("Lỗi: " + e.Message);
                Console.WriteLine("StackTrace: " + e.StackTrace);

                MessageBox.Show("Lỗi: " + e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }
        }


        public DataTable loadAllLSGH(NguoiDung nguoiDung)

        {
            if (nguoiDung == null)
            {
                Console.WriteLine("Người dùng không tồn tại");
                return null;
            }

            string sql = @"SELECT LS.MALS, LS.MADH, SP.TENSP, LS.TRANGTHAIMOI,  LS.LANGIAO, LS.THOIGIANCAPNHAT  FROM LICHSUGH LS  JOIN DONHANG DH ON LS.MADH = DH.MADH JOIN CHITIET_DONHANG CTDH ON CTDH.MADH = DH.MADH JOIN SANPHAM SP ON SP.MASP = CTDH.MASP  JOIN NGUOIDUNG ND ON DH.MASHI = ND.MANGUOIDUNG   WHERE ND.TENDANGNHAP = @TENDANGNHAP ORDER BY LS.THOIGIANCAPNHAT DESC;";
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
                Console.WriteLine(" loi  : " + ex);
                return new DataTable();
            }
        }

        public DataTable fillter(NguoiDung nguoiDung, string dateFilter, int? status)
        {
            try
            {
                // **Thêm khoảng trắng sau mỗi JOIN để tránh lỗi cú pháp**
                string sql = "SELECT LS.MALS, LS.MADH, SP.TENSP, LS.TRANGTHAIMOI, LS.LANGIAO, LS.THOIGIANCAPNHAT " +
                             "FROM LICHSUGH LS " +
                             "JOIN DONHANG DH ON LS.MADH = DH.MADH " +
                             "JOIN CHITIET_DONHANG CTDH ON CTDH.MADH = DH.MADH " +  
                             "JOIN SANPHAM SP ON CTDH.MASP = SP.MASP " +
                             "JOIN NGUOIDUNG ND ON DH.MASHI = ND.MANGUOIDUNG " +  
                             "WHERE ND.TENDANGNHAP = @TenDangNhap " +
                             "AND CONVERT(Date, LS.THOIGIANCAPNHAT) = @DateFilter "; 

                if (status.HasValue)
                {
                    sql += "AND LS.TRANGTHAIMOI = @Status ";
                }
                sql += "ORDER BY LS.THOIGIANCAPNHAT DESC;";

                
                DateTime dateValue;
                if (!DateTime.TryParse(dateFilter, out dateValue))
                {
                    Console.WriteLine("Lỗi: Giá trị dateFilter không hợp lệ!");
                    return null;
                }

                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[]
                {
            nguoiDung.TenDangNhap,
            dateValue,  // ✅ Truyền kiểu DateTime thay vì string
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

        public DataTable find(string tenDangNhap, string tuKhoa)
        {
            string query = @"
                        SELECT LS.MALS, LS.MADH, SP.TENSP, LS.TRANGTHAIMOI, LS.LANGIAO, LS.THOIGIANCAPNHAT  
                             FROM LICHSUGH LS  
                             JOIN DONHANG DH ON LS.MADH = DH.MADH  
                             JOIN CHITIET_DONHANG CTDH ON CTDH.MADH = DH.MADH
                             JOIN SANPHAM SP ON CTDH.MASP = SP.MASP  
                             JOIN NGUOIDUNG ND ON DH.MASHI = ND.MANGUOIDUNG  
                             WHERE ND.TENDANGNHAP = @TenDangNhap  
                        AND ( LS.MADH LIKE '%' + @Str + '%' OR sp.TENSP COLLATE SQL_Latin1_General_CP1_CI_AI LIKE @str + '%')";

            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenDangNhap, tuKhoa });
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực hiện truy vấn: " + ex.Message);
                return null;
            }
        }

        public DataTable loadAllLSGHForAdmin()

        {

            string sql = @" SELECT 
                            lsgh.MALS as mals,
                            dh.MADH as madh,
	                        nd.TEN AS NHANVIENGIAOHANG ,  
                            lsgh.THOIGIANCAPNHAT as thoiGianCapNhat,
                            lsgh.TRANGTHAIMOI as trangThai,
                            lsgh.LANGIAO as lanGiao,
                            kh.TENKH as TenKh,
                            sp.tensp as tensp , 
                            dh.DIACHIGH AS DIACHIGIAOHANG
                            
     
                        FROM 
                            DONHANG dh
                        JOIN 
                            LICHSUGH lsgh ON dh.MADH = lsgh.MADH
                        JOIN 
                            KHACHHANG kh ON dh.MAKH = kh.MAKH
                        JOIN 
                            CHITIET_DONHANG ctdh ON dh.MADH = ctdh.MADH
                        JOIN 
                            SANPHAM sp ON ctdh.MASP = sp.MASP
                        LEFT JOIN 
                            CHITIET_KHUYENMAI ctkm ON dh.MADH = ctkm.MADH
                        LEFT JOIN 
                            KHUYENMAI km ON ctkm.MAKM = km.MAKM
                        LEFT JOIN 
                            NGUOIDUNG nd ON dh.MASHI = nd.MANGUOIDUNG  
                        GROUP BY 
                            lsgh.MALS, dh.MADH,nd.TEN  ,  lsgh.THOIGIANCAPNHAT,  sp.tensp,  lsgh.TRANGTHAIMOI, lsgh.LANGIAO, 
                            kh.TENKH, dh.DIACHIGH;

                    ";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                return data;



            }
            catch (Exception ex)
            {
                Console.WriteLine(" loi  : " + ex);
                return null;
            }
        }


        public DataTable fillterForAdmin(string dateFilter, int? status)
        {
            try
            {
                string sql = @"
            SELECT 
                lsgh.MALS as mals,
                dh.MADH as madh,
	            nd.TEN AS NHANVIENGIAOHANG ,  
                lsgh.THOIGIANCAPNHAT as thoiGianCapNhat,
                lsgh.TRANGTHAIMOI as trangThai,
                lsgh.LANGIAO as lanGiao,
                kh.TENKH as TenKh,
                sp.tensp as tensp , 
                dh.DIACHIGH AS DIACHIGIAOHANG
            FROM DONHANG dh
            JOIN LICHSUGH lsgh ON dh.MADH = lsgh.MADH
            JOIN KHACHHANG kh ON dh.MAKH = kh.MAKH
            JOIN CHITIET_DONHANG ctdh ON dh.MADH = ctdh.MADH
            JOIN SANPHAM sp ON ctdh.MASP = sp.MASP
            LEFT JOIN CHITIET_KHUYENMAI ctkm ON dh.MADH = ctkm.MADH
            LEFT JOIN KHUYENMAI km ON ctkm.MAKM = km.MAKM
            LEFT JOIN NGUOIDUNG nd ON dh.MASHI = nd.MANGUOIDUNG
            WHERE CONVERT(Date, lsgh.THOIGIANCAPNHAT) = @DateFiller ";

                if (status.HasValue)
                {
                    sql += "AND lsgh.TRANGTHAIMOI = @Status ";
                }

                sql += @"
                        GROUP BY 
                           lsgh.MALS, dh.MADH,nd.TEN  ,  lsgh.THOIGIANCAPNHAT, sp.tensp , lsgh.TRANGTHAIMOI, lsgh.LANGIAO, 
                            kh.TENKH, dh.DIACHIGH
                        ORDER BY lsgh.THOIGIANCAPNHAT DESC;";

                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { dateFilter, status.HasValue ? (object)status.Value : DBNull.Value });

                if (data.Rows.Count == 0)
                {
                    
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

        public DataTable findForAdmin(string tuKhoa)
        {
            string query = @"
                    SELECT 
                        lsgh.MALS as mals,
                        dh.MADH as madh,
	                    nd.TEN AS NHANVIENGIAOHANG ,  
                        lsgh.THOIGIANCAPNHAT as thoiGianCapNhat,
                        lsgh.TRANGTHAIMOI as trangThai,
                        lsgh.LANGIAO as lanGiao,
                        kh.TENKH as TenKh,
                        sp.tensp as tensp , 
                        dh.DIACHIGH AS DIACHIGIAOHANG

                    
                    FROM DONHANG dh
                    JOIN LICHSUGH lsgh ON dh.MADH = lsgh.MADH
                    JOIN KHACHHANG kh ON dh.MAKH = kh.MAKH
                    JOIN CHITIET_DONHANG ctdh ON dh.MADH = ctdh.MADH
                    JOIN SANPHAM sp ON ctdh.MASP = sp.MASP
                    LEFT JOIN CHITIET_KHUYENMAI ctkm ON dh.MADH = ctkm.MADH
                    LEFT JOIN KHUYENMAI km ON ctkm.MAKM = km.MAKM
                    LEFT JOIN NGUOIDUNG nd ON dh.MASHI = nd.MANGUOIDUNG
                    WHERE (sp.TENSP COLLATE SQL_Latin1_General_CP1_CI_AI like  N'%' + @str + '%' 
                        OR nd.TEN COLLATE SQL_Latin1_General_CP1_CI_AI LIKE N'%' + @str
                        OR kh.TENKH COLLATE SQL_Latin1_General_CP1_CI_AI LIKE N'%' + @str )
                    GROUP BY 
                        lsgh.MALS, dh.MADH,nd.TEN  ,  lsgh.THOIGIANCAPNHAT,sp.tensp ,  lsgh.TRANGTHAIMOI, lsgh.LANGIAO, 
                            kh.TENKH, dh.DIACHIGH
                    ORDER BY lsgh.THOIGIANCAPNHAT DESC;";

            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tuKhoa });
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực hiện truy vấn: " + ex.Message);
                return null;
            }
        }














    }
}
