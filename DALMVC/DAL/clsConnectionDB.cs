using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class clsConnectionDB
    {
        public static SqlConnection openConnection()
        {
            string cs = "Data Source=SIDDANT\\SQLEXPRESS;Initial Catalog=MVCPractice;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            return conn;
        }
    }
}