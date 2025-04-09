using HeThongQuanLyGiaoHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyGiaoHang.DAO
{
    public class NhaPhanPhoiDAO
    {
        private static NhaPhanPhoiDAO instance;

        public static NhaPhanPhoiDAO Instance
        {
            get { if (instance == null) instance = new NhaPhanPhoiDAO(); return NhaPhanPhoiDAO.instance; }
            private set { NhaPhanPhoiDAO.instance = value; }
        }

        private NhaPhanPhoiDAO() { }

        public NhaPhanPhoi getNhaPhanPhoi(int id)
        {
            string sql = " select nhaphanphoi.MANPP , TENNPP from DONHANG , NhaPhanPhoi  where NHAPHANPHOI.MANPP = DONHANG.MANPP and  MaDH  = @id ";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { id });
           NhaPhanPhoi nhaPhanPhoi = new NhaPhanPhoi();  
            foreach (DataRow row in data.Rows)
            {
                int maNPP = Convert.ToInt32(row["MANPP"]);
                string tenNPP =(row["TENNPP"]).ToString();
                nhaPhanPhoi.maNPP = maNPP;
                nhaPhanPhoi.tenNPP = tenNPP;    



            }
            return nhaPhanPhoi;
        }


        public DataTable loadNPP()

        {

            string sql = @"
                           select  * from NHAPHANPHOI;
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

        public DataTable find(string STR)

        {

            string sql = @"
                           select  * from NHAPHANPHOI WHERE TENNPP COLLATE SQL_Latin1_General_CP1_CI_AI like  '%' +   @STR + '%';
                        ";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { STR });

                return data;



            }
            catch (Exception ex)
            {
                Console.WriteLine(" Loi  :  " + ex);
                return null;

            }
        }
    }
}
