using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ExamenDAO : ConnectionToSQL
    {
        public void registrarExamenesPedido(Pedido pedido, BindingList<TipoExamen> tiposExamen)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                foreach (TipoExamen tipoExamen in tiposExamen)
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO EXAMENES(IDTIPOEXAMEN, IDPEDIDO) values (@idtipoexamen, @idpedido)";
                        command.Parameters.AddWithValue("@idtipoexamen", tipoExamen.Id);
                        command.Parameters.AddWithValue("@idpedido", pedido.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void registrarExamenPedido(Pedido pedido, TipoExamen tipoExamen)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO EXAMENES(IDTIPOEXAMEN, IDPEDIDO) values (@idtipoexamen, @idpedido)";
                        command.Parameters.AddWithValue("@idtipoexamen", tipoExamen.Id);
                        command.Parameters.AddWithValue("@idpedido", pedido.Id);
                        command.ExecuteNonQuery();
                    }
            }
        }

        public BindingList<Examen> obtenerExamenesPedido(int idPedido)
        {
            BindingList<Examen> examenes = null;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT IDEXAMEN, NOMBRETIPOEXAMEN, COSTOTIPOEXAMEN, ESTADOEXAMEN " +
                        "FROM EXAMENES JOIN TIPOSEXAMEN" +
                        " ON EXAMENES.IDTIPOEXAMEN = TIPOSEXAMEN.IDTIPOEXAMEN WHERE EXAMENES.IDPEDIDO = @idPedido";
                    command.Parameters.AddWithValue("@idPedido", idPedido);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        examenes = new BindingList<Examen>();
                        while (reader.Read())
                        {

                            Examen examen = new Examen(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetString(3));
                            examenes.Add(examen);
                        }
                    }
                }
            }
            return examenes;
        }

        public void EliminarExamenID(int idExamen)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM EXAMENES WHERE IDEXAMEN=@idExamen";
                    command.Parameters.AddWithValue("@idExamen", idExamen);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
