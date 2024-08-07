using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccess
{
    public class TipoExamenDOA : ConnectionToSQL
    {
        public bool Check(string nombre)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from TIPOSEXAMEN where NOMBRETIPOEXAMEN=@nombre";
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.CommandType = System.Data.CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public TipoExamen GetTipoExamen(string nombre) {
            TipoExamen tipoExamen = null;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM TIPOSEXAMEN WHERE NOMBRETIPOEXAMEN = @nombre";
                    command.Parameters.AddWithValue("@nombre", nombre);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tipoExamen = new TipoExamen
                            (
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetDecimal(2)
                            );
                        }
                    }
                }
            }
            return tipoExamen;
        }

        public void RegistrarTipoExamen(string nombre, decimal costo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO TIPOSEXAMEN(NOMBRETIPOEXAMEN, COSTOTIPOEXAMEN) VALUES (@nombre, @costo)";
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@costo", costo);
                    command.CommandType = System.Data.CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarPrecioTipoExamen(string nombre, decimal costo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE TIPOSEXAMEN SET COSTOTIPOEXAMEN=@costo where NOMBRETIPOEXAMEN=@nombre";
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@costo", costo);
                    command.CommandType = System.Data.CommandType.Text;
                    command.ExecuteNonQuery();

                }
            }
        }

        public List<TipoExamen> ObtenerTiposExamen()
        {
            List<TipoExamen> TiposExamen = null;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM TIPOSEXAMEN";
                    command.CommandType = System.Data.CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    TiposExamen = new List<TipoExamen>();
                    while (reader.Read())
                    {
                        
                        TipoExamen tipo = new TipoExamen(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2));
                        TiposExamen.Add(tipo);
                    }

                }
            }
            return TiposExamen;
        }


    }
}
