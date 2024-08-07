using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI.ConeccionBD
{
    internal class DataAccess
    {
        // todos son static porque no voy a instanciar nunca esta clase
        public static string strconn = "Data Source=PCALEJO\\BDD;Initial Catalog=MarujaGuayaquil;User ID=sa;Password=P@ssw0rd";
        public static SqlConnection conn = null;
        public static string strcomm = "";
        public static SqlCommand comm = null;

        public static SqlConnection GetConnection()
        {
            conn = new SqlConnection(strconn);
            return conn;
        }

    }
}