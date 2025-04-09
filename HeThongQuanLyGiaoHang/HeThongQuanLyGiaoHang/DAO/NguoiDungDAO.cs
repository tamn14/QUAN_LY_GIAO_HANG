using HeThongQuanLyGiaoHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyGiaoHang.DAO
{
    public class NguoiDungDAO
    {
        private static NguoiDungDAO instance;

        public static NguoiDungDAO Instance
        {
            get { if (instance == null) instance = new NguoiDungDAO(); return NguoiDungDAO.instance; }
            private set { NguoiDungDAO.instance = value; }
        }

        private NguoiDungDAO() { }

        public int UpdateUserName (NguoiDung nguoiDung)
        {
           
            try
            {
                string sql = "Update NGUOIDUNG set TENDANGNHAP = @TENDANGNHAP WHERE MANGUOIDUNG = @MANGUOIDUNG ";
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { nguoiDung.TenDangNhap , nguoiDung.maNguoiDung });
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi :  " + e);
                return -1;

            }
        }

        public int UpdateUser(NguoiDung nguoiDung)
        {

            try
            {
                string sql = "Update NGUOIDUNG set TENDANGNHAP = @TENDANGNHAP, MATKHAU = @MATKHAU  WHERE MANGUOIDUNG = @MANGUOIDUNG ";
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { nguoiDung.TenDangNhap, nguoiDung.MatKhau ,nguoiDung.maNguoiDung });
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi :  " + e);
                return -1;

            }
        }

        public List<NguoiDung> getNguoiDung()
        {
            List<NguoiDung> LIST = new List<NguoiDung>();
            string sql = "select * from NGUOIDUNG WHERE VAITRO = 2 AND VOHIEUHOA = 0 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
           
            foreach (DataRow row in data.Rows)
            {
                NguoiDung nguoiDung = new NguoiDung();
                int maND = Convert.ToInt32(row["MANGUOIDUNG"]);
                string ten = (row["TEN"]).ToString();   
                nguoiDung.maNguoiDung = maND;
                nguoiDung.ten = ten; 
                LIST.Add(nguoiDung);


            }
            return LIST;

        }



       


    }
}
