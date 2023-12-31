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
            string str = "Data Source=SIDDANT\\SQLEXPRESS;Initial Catalog=MVCPractice;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            return conn;    
        }
    }
}