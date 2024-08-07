using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess 
{
    public class PedidoDAO : ConnectionToSQL
    {
        public void registrarPedido(string cedula)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert into PEDIDOS(CIPACIENTE) values (@cedula)";
                    command.Parameters.AddWithValue("@cedula", cedula);
                    command.ExecuteNonQuery();
                }
                
            }
        }

        public bool Check(string CI)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from PEDIDOS where CIPACIENTE=@CI AND ESTADOPEDIDO='Pendiente'";
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

        public Pedido ObtenerPedidoCI(string CIPaciente)
        {
            Pedido pedido = null;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM PEDIDOS WHERE CIPACIENTE = @cedula AND ESTADOPEDIDO='Pendiente'";
                    command.Parameters.AddWithValue("@cedula", CIPaciente);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pedido = new Pedido
                            (
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2)
                            );
                        }
                    }
                }
            }
            return pedido;
        }

        public void eliminarPedido(string ciPaciente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                Pedido pedido = null;
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM PEDIDOS WHERE CIPACIENTE = @cedula AND ESTADOPEDIDO='Pendiente'";
                    command.Parameters.AddWithValue("@cedula", ciPaciente);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pedido = new Pedido
                            (
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2)
                            );
                        }
                    }
                }
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Delete from EXAMENES WHERE IDPEDIDO=@idPedido";
                    command.Parameters.AddWithValue("@idPedido", pedido.Id);
                    command.ExecuteNonQuery();
                }
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Delete from PEDIDOS WHERE IDPEDIDO=@idPedido";
                    command.Parameters.AddWithValue("@idPedido", pedido.Id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
