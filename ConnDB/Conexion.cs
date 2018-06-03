using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.ConnDB
{
    class Conexion
    {
        SqlConnection conn = null;
        public SqlConnection OpenConn()
        {
            string cadena = "DATA SOURCE = DESKTOP-0PJ296C\\SQLEXPRESS;" +
                           "INITIAL CATALOG = veterinaria;" +
                           "Integrated Security = Yes;";
            //string conn = "DATA SOURCE = localhost;" + "INITIAL CATALOG = misjuegos;" + "User ID=sa;Password=root;";
            conn = new SqlConnection(cadena);
            conn.Open();
            return conn;
        }

        public void CloseConn()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}
