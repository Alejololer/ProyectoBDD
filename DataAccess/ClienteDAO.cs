using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ClienteDAO : ConnectionToSQL
    {
        public bool Check(string CI)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Clientes where cedula=@CI";
                    command.Parameters.AddWithValue("@CI", CI);
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
        public bool registrarCliente(string cedula, string nombre, string telefono, string direccion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert into Clientes(cedula, nombre, telefono, direccion, id_sucursal) values (@cedula, @nombres, @telefono, @direccion, 2)";
                    command.Parameters.AddWithValue("@cedula", cedula);
                    command.Parameters.AddWithValue("@nombres", nombre);
                    command.Parameters.AddWithValue("@telefono", telefono);
                    command.Parameters.AddWithValue("@direccion", direccion);
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

        public Cliente ObtenerClienteCI(string CICliente)
        {
            Cliente Cliente = null;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Clientes WHERE cedula = @cedula";
                    command.Parameters.AddWithValue("@cedula", CICliente);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            Cliente = new Cliente
                            (
                                reader.GetString(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetInt32(4)
                            );
                        }
                    }
                }
            }
            return Cliente;
        }

        public void actualizarCliente(string cedula, string telefono, string direccion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Clientes set telefono = @telefono, direccion = @direccion WHERE cedula = @cedula";
                    command.Parameters.AddWithValue("@cedula", cedula);
                    command.Parameters.AddWithValue("@telefono", telefono);
                    command.Parameters.AddWithValue("@direccion", direccion);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
