using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyGiaoHang.DTO
{
    public class DataProvider
    {
        private static DataProvider instance;


        private String connectionStr = "Data Source= .\\SQLEXPRESS;Initial Catalog=QuanLyGiaoHang;Integrated Security=True";

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }
        private DataProvider() { }

        public DataTable ExecuteQuery(string sql, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);


                if (parameter != null)
                {
                    string[] listPara = sql.Split(new char[] { ' ', ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Where(p => p.StartsWith("@"))
                                           .ToArray();

                    for (int i = 0; i < listPara.Length; i++)
                    {
                        if (i < parameter.Length)
                        {
                            cmd.Parameters.AddWithValue(listPara[i], parameter[i]);
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                conn.Close();
            }

            return data;
        }


        public int ExecuteNonQuery(string sql, object[] parameter = null)
        {
            int affectedRows = 0; 

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                if (parameter != null)
                {
                    string[] listPara = sql.Split(new char[] { ' ', ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Where(p => p.StartsWith("@"))
                                           .ToArray();

                    for (int i = 0; i < listPara.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(listPara[i], parameter[i]);
                    }
                }

                affectedRows = cmd.ExecuteNonQuery();

                conn.Close();
            }

            return affectedRows;
        }


    }
}
