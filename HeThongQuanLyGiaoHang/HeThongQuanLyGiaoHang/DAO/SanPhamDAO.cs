using HeThongQuanLyGiaoHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyGiaoHang.DAO
{
    public class SanPhamDAO
    {
        private static SanPhamDAO instance;

        public static SanPhamDAO Instance
        {
            get { if (instance == null) instance = new SanPhamDAO(); return SanPhamDAO.instance; }
            private set { SanPhamDAO.instance = value; }
        }

        private SanPhamDAO() { }

        public DataTable loadSanPham()

        {

            string sql = @"
                           SELECT sp.MASP as maSP, 
                           sp.TENSP as tenSP, 
                           ctdh.GIABAN as giaBan, 
                           sp.THOIDIEMMUA as thoiDiemMua, 
                           ctdh.SOLUONG as soLuong, 
                           ctdh.KHOILUONG as khoiLuong, 
                           sp.MOTA as moTa, 
                           dh.MADH as maDH, 
                           npp.TENNPP as tenNPP, 
                           ctdh.THANHTIEN as thanhTien
                    FROM SANPHAM sp
                    JOIN CHITIET_DONHANG ctdh ON ctdh.MASP = sp.MASP 
                    JOIN DONHANG dh ON dh.MADH = ctdh.MADH
                    LEFT JOIN NHAPHANPHOI npp ON npp.MANPP = dh.MANPP;
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
                            SELECT sp.MASP as maSP, 
                           sp.TENSP as tenSP, 
                           ctdh.GIABAN as giaBan, 
                           sp.THOIDIEMMUA as thoiDiemMua, 
                           ctdh.SOLUONG as soLuong, 
                           ctdh.KHOILUONG as khoiLuong, 
                           sp.MOTA as moTa, 
                           dh.MADH as maDH, 
                           npp.TENNPP as tenNPP, 
                           ctdh.THANHTIEN as thanhTien
                    FROM SANPHAM sp
                    JOIN CHITIET_DONHANG ctdh ON ctdh.MASP = sp.MASP 
                    JOIN DONHANG dh ON dh.MADH = ctdh.MADH
                    LEFT JOIN NHAPHANPHOI npp ON npp.MANPP = dh.MANPP
                    WHERE sp.MASP = TRY_CONVERT(int, @str) OR SP.TENSP COLLATE SQL_Latin1_General_CP1_CI_AI like @str + '%'  
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

        public SanPham getSP(int masp)
        {
            string sql = "SELECT  MASP , TENSP, MOTA, THOIDIEMMUA  FROM SANPHAM WHERE MASP = @MASP";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { masp });

            if (data.Rows.Count == 0)
                return null;

            try
            {
                DataRow row = data.Rows[0];
                SanPham sanPham = new SanPham();

                sanPham.MaSP = Convert.ToInt32(row["MASP"]);
                sanPham.TenSP = (row["TENSP"]).ToString();
                sanPham.Mota = (row["MOTA"]).ToString();
                sanPham.thoiDiemMua = Convert.ToDateTime(row["THOIDIEMMUA"]);

                return sanPham;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy chi tiết đơn hàng: " + ex.Message);
                return null;
            }
        }

    }
}
