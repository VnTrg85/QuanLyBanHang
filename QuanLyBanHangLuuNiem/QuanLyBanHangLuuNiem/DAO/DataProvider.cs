using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangLuuNiem.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance { get { if (instance == null) instance = new DataProvider(); return instance; } set => instance=value; }

        private string text = @"Data Source=NGUYNVNTRNGD528\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True";
        private DataProvider() { }

        public DataTable executeQuery(string query , object[]para = null)
        {
            DataTable data = new DataTable();
            using(SqlConnection conn = new SqlConnection(text))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query,conn);
                string[] temp = query.Split(" ");
                int i = 0;
                foreach (string item in temp)
                {
                    if(item.Contains("@"))
                    {
                        command.Parameters.AddWithValue(item, para[i]);
                        i++;
                    }
                }
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                sqlData.Fill(data);
                conn.Close();
            }
            return data;
        }
        public object excecuteScalar(string query , object[] para)
        {
            using(SqlConnection conn = new SqlConnection(text))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query,conn);
                string[] temp = query.Split(" ");
                int i = 0;
                foreach (string item in temp)
                {
                    if (item.Contains("@"))
                    {
                        command.Parameters.AddWithValue(item, para[i]);
                        i++;
                    }
                }
                object value = command.ExecuteScalar();
                conn.Close();
                return value;
                
            }
            
        }
        public int execueNonquery(string query , object[] para)
        {
            int rowAff = 0;
            using (SqlConnection conn = new SqlConnection(text))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query,conn);
                string[] temp = query.Split(" ");
                int i = 0;
                foreach (string item in temp)
                {
                    if(item.Contains("@"))
                    {
                        command.Parameters.AddWithValue(item, para[i]);
                        i++;
                    }
                }
                rowAff =(int)command.ExecuteNonQuery();
                conn.Close();
            }
            return rowAff;
        }
    }
}
