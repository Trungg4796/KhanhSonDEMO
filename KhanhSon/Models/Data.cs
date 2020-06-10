using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KhanhSon.Models
{
    public class Data
    {
        static string _ConnectionString = @"Data Source=DESKTOP-81S46E7\SQLEXPRESS;Initial Catalog=KhanhSon;Integrated Security=True;Max Pool Size=50000;Pooling=True;";
        public static string ConnectionString
        {
            get
            {
                return Data._ConnectionString;
            }
            set
            {
                Data._ConnectionString = value;
            }
        }
        public static SqlConnection Connection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
    }
}
