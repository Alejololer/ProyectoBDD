using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EmpleadoDAO : ConnectionToSQL
    {
        public bool Check(string CI)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from v_empleados where cedula=@CI and sucursal = 2";
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

        public bool registrarEmpleado(string cedula, string nombres, string apellidos, BindingList<TelefonoEmpleado> telefonos)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "set XACT_ABORT on begin distributed tran Insert into v_empleados(cedula, nombres, apellidos, sucursal) values (@cedula, @nombres, @apellidos, 2) commit tran";
                    command.Parameters.AddWithValue("@cedula", cedula);
                    command.Parameters.AddWithValue("@nombres", nombres);
                    command.Parameters.AddWithValue("@apellidos", apellidos);
                    command.ExecuteNonQuery();
                }
                foreach (TelefonoEmpleado telefono in telefonos)
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "insert into telefonos_emp_2 (cedula_empleado, sucursal, telefono, tipo) values (@cedula, 2, @telefono, @tipo)";
                        command.Parameters.AddWithValue("@cedula", cedula);
                        command.Parameters.AddWithValue("@telefono", telefono.telefono);
                        command.Parameters.AddWithValue("@tipo", telefono.tipo);
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
        }
    }
}
