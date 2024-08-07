using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class IVADAO : ConnectionToSQL
    {
        public IVA getIVA()
        {
            IVA iva = null;
            using(var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT TOP 1 * FROM IVA ORDER BY [FECHAIVA] DESC";
                    command.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            iva = new IVA
                            (
                                reader.GetInt32(1)
                            );
                        }
                    }
                }
            }
            return iva;
        }

        public bool registrarIVA(int valor)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert into IVA(VALORIVA, FECHAIVA) values (@valor, CAST(GETDATE() AS DATE))";
                    command.Parameters.AddWithValue("@valor", valor);
                    int filasAfectadas = command.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }


}
