using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ParametroTipoExamenDOA : ConnectionToSQL
    {
        public void registrarParTipoExamenNull(int IDTipoExamen, string nombre)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                // Iniciar la transacción
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.Transaction = transaction;

                        // 1. Insertar un nuevo parámetro en la tabla PARAMETROSTIPOEXAMEN
                        command.CommandText = "INSERT INTO PARAMETROSTIPOEXAMEN (NOMBREPARAMETRO) VALUES (@nombre)";
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.ExecuteNonQuery();

                        // 2. Seleccionar el parámetro recién insertado de la tabla PARAMETROSTIPOEXAMEN
                        command.CommandText = "SELECT @@IDENTITY";
                        int parametroId = Convert.ToInt32(command.ExecuteScalar());

                        // 3. Insertar una nueva relación en la tabla intermedia TIPOEXAMEN_PARAMETRO
                        command.CommandText = "INSERT INTO TIPOEXAMEN_PARAMETRO (IDTIPOEXAMEN, IDPARAMETRO) VALUES (@idexamen, @idparametro)";
                        command.Parameters.Clear(); // Limpiar parámetros anteriores
                        command.Parameters.AddWithValue("@idexamen", IDTipoExamen);
                        command.Parameters.AddWithValue("@idparametro", parametroId);
                        command.ExecuteNonQuery();

                        // Commit de la transacción si todas las consultas se completaron con éxito
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    // Rollback de la transacción en caso de error
                    transaction.Rollback();
                    Console.WriteLine($"Error al ejecutar transacción: {ex.Message}");
                }
            }
        }

        public void registrarParTipoExamen(int IDTipoExamen, string nombre, float min, float max, string unidades)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                // Iniciar la transacción
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.Transaction = transaction;

                        // 1. Insertar un nuevo parámetro en la tabla PARAMETROSTIPOEXAMEN
                        command.CommandText = "INSERT INTO PARAMETROSTIPOEXAMEN (NOMBREPARAMETRO, MINPARAMETRO, MAXPARAMETRO, UNIDADPARAMETRO) " +
                            "VALUES (@nombre, @min, @max, @unidad)";
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@min", min);
                        command.Parameters.AddWithValue("max", max);
                        command.Parameters.AddWithValue("@unidad", unidades);
                        command.ExecuteNonQuery();

                        // 2. Seleccionar el parámetro recién insertado de la tabla PARAMETROSTIPOEXAMEN
                        command.CommandText = "SELECT @@IDENTITY";
                        int parametroId = Convert.ToInt32(command.ExecuteScalar());

                        // 3. Insertar una nueva relación en la tabla intermedia TIPOEXAMEN_PARAMETRO
                        command.CommandText = "INSERT INTO TIPOEXAMEN_PARAMETRO (IDTIPOEXAMEN, IDPARAMETRO) VALUES (@idexamen, @idparametro)";
                        command.Parameters.Clear(); // Limpiar parámetros anteriores
                        command.Parameters.AddWithValue("@idexamen", IDTipoExamen);
                        command.Parameters.AddWithValue("@idparametro", parametroId);
                        command.ExecuteNonQuery();

                        // Commit de la transacción si todas las consultas se completaron con éxito
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    // Rollback de la transacción en caso de error
                    transaction.Rollback();
                    Console.WriteLine($"Error al ejecutar transacción: {ex.Message}");
                }
            }
        }

        public void registrarParTipoExamenRango(int IDTipoExamen, string nombre, float min, float max)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                // Iniciar la transacción
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.Transaction = transaction;

                        // 1. Insertar un nuevo parámetro en la tabla PARAMETROSTIPOEXAMEN
                        command.CommandText = "INSERT INTO PARAMETROSTIPOEXAMEN (NOMBREPARAMETRO, MINPARAMETRO, MAXPARAMETRO) " +
                            "VALUES (@nombre, @min, @max)";
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@min", min);
                        command.Parameters.AddWithValue("max", max);
                        command.ExecuteNonQuery();

                        // 2. Seleccionar el parámetro recién insertado de la tabla PARAMETROSTIPOEXAMEN
                        command.CommandText = "SELECT @@IDENTITY";
                        int parametroId = Convert.ToInt32(command.ExecuteScalar());

                        // 3. Insertar una nueva relación en la tabla intermedia TIPOEXAMEN_PARAMETRO
                        command.CommandText = "INSERT INTO TIPOEXAMEN_PARAMETRO (IDTIPOEXAMEN, IDPARAMETRO) VALUES (@idexamen, @idparametro)";
                        command.Parameters.Clear(); // Limpiar parámetros anteriores
                        command.Parameters.AddWithValue("@idexamen", IDTipoExamen);
                        command.Parameters.AddWithValue("@idparametro", parametroId);
                        command.ExecuteNonQuery();

                        // Commit de la transacción si todas las consultas se completaron con éxito
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    // Rollback de la transacción en caso de error
                    transaction.Rollback();
                    Console.WriteLine($"Error al ejecutar transacción: {ex.Message}");
                }
            }
        }

        public void registrarParTipoExamenUnidad(int IDTipoExamen, string nombre, string unidades)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                // Iniciar la transacción
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.Transaction = transaction;

                        // 1. Insertar un nuevo parámetro en la tabla PARAMETROSTIPOEXAMEN
                        command.CommandText = "INSERT INTO PARAMETROSTIPOEXAMEN (NOMBREPARAMETRO, UNIDADPARAMETRO) " +
                            "VALUES (@nombre, @unidad)";
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@unidad", unidades);
                        command.ExecuteNonQuery();

                        // 2. Seleccionar el parámetro recién insertado de la tabla PARAMETROSTIPOEXAMEN
                        command.CommandText = "SELECT @@IDENTITY";
                        int parametroId = Convert.ToInt32(command.ExecuteScalar());

                        // 3. Insertar una nueva relación en la tabla intermedia TIPOEXAMEN_PARAMETRO
                        command.CommandText = "INSERT INTO TIPOEXAMEN_PARAMETRO (IDTIPOEXAMEN, IDPARAMETRO) VALUES (@idexamen, @idparametro)";
                        command.Parameters.Clear(); // Limpiar parámetros anteriores
                        command.Parameters.AddWithValue("@idexamen", IDTipoExamen);
                        command.Parameters.AddWithValue("@idparametro", parametroId);
                        command.ExecuteNonQuery();

                        // Commit de la transacción si todas las consultas se completaron con éxito
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    // Rollback de la transacción en caso de error
                    transaction.Rollback();
                    Console.WriteLine($"Error al ejecutar transacción: {ex.Message}");
                }
            }
        }


    }
}
