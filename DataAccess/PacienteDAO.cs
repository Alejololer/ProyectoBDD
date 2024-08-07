using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PacienteDAO : ConnectionToSQL
    {
        public bool Check(string CI)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Pacientes where CIPACIENTE=@CI";
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
        public bool registrarPaciente(string cedula, string nombres, string apellidos, string telefono, string direccion,
            string correo, string fechanac)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert into Pacientes(CIPACIENTE, NOMBRESPACIENTE, APELLIDOSPACIENTE, TELEFONOPACIENTE, CORREOPACIENTE, DIRECCIONPACIENTE, FECHANACPACIENTE) values (@cedula, @nombres, @apellidos, @telefono, @correo, @direccion, @fechanac)";
                    command.Parameters.AddWithValue("@cedula", cedula);
                    command.Parameters.AddWithValue("@nombres", nombres);
                    command.Parameters.AddWithValue("@apellidos", apellidos);
                    command.Parameters.AddWithValue("@telefono", telefono);
                    command.Parameters.AddWithValue("@direccion", direccion);
                    command.Parameters.AddWithValue("@correo", correo);
                    command.Parameters.AddWithValue("@fechanac", fechanac);
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

        public Paciente ObtenerPacienteCI(string CIPaciente)
        {
            Paciente paciente = null;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Pacientes WHERE CIPACIENTE = @cedula";
                    command.Parameters.AddWithValue("@cedula", CIPaciente);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            paciente = new Paciente
                            (
                                reader.GetString(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5),
                                reader.GetDateTime(6).ToString("yyyy-MM-dd")
                            );
                        }
                    }
                }
            }
            return paciente;
        }

        public void actualizarPaciente(string cedula, string telefono, string correo , string direccion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Pacientes set TELEFONOPACIENTE = @telefono, CORREOPACIENTE = @correo, DIRECCIONPACIENTE = @direccion WHERE CIPACIENTE = @cedula";
                    command.Parameters.AddWithValue("@cedula", cedula);
                    command.Parameters.AddWithValue("@telefono", telefono);
                    command.Parameters.AddWithValue("@correo", correo);
                    command.Parameters.AddWithValue("@direccion", direccion);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
