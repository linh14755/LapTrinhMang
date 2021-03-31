using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Server
{
    public class DataProVider
    {
        public static DataProVider instance = new DataProVider();

        public static DataProVider Instance { get => instance; set => instance = value; }

        public static string connectSRT = "Data Source=.;Initial Catalog=DsThi;Integrated Security=True";

        public DataTable ExcuteQuery(string query, object[] paramaters = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connect = new SqlConnection(connectSRT))
            {
                connect.Open();
                SqlCommand command = new SqlCommand(query, connect);
                if (paramaters != null)
                {
                    int i = 0;
                    string[] listpara = query.Split(' ');
                    foreach (string item in listpara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, paramaters[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connect.Close();
            }

            return data;
        }
    }
}
