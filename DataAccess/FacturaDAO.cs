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
    public class FacturaDAO : ConnectionToSQL
    {
        public bool Check(int id)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("SELECT * FROM v_facturas WHERE numero_factura = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
        }
        public bool ExecuteInsertFacturaSP(decimal total, string cedula_empleado, string cedula_cliente, BindingList<DetalleFactura> detalles)
        {
            int numero_factura = 0;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("sp_insert_v_facturas", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@total", total);
                command.Parameters.AddWithValue("@id_sucursal", 2);
                command.Parameters.AddWithValue("@cedula_empleado", cedula_empleado);
                command.Parameters.AddWithValue("@cedula_cliente", cedula_cliente);

                SqlParameter outputParameter = new SqlParameter("@new_numero_factura", SqlDbType.Int);
                outputParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(outputParameter);

                connection.Open();
                command.ExecuteNonQuery();

                numero_factura = (int)outputParameter.Value;

                bool success = true;
                foreach (DetalleFactura detalle in detalles)
                {
                    command = new SqlCommand("sp_insert_v_det_facturas", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@numero_factura", numero_factura);
                    command.Parameters.AddWithValue("@id_producto", detalle.id_producto);
                    command.Parameters.AddWithValue("@id_sucursal", 2);
                    command.Parameters.AddWithValue("@unidades", detalle.unidades);
                    command.Parameters.AddWithValue("@precio_unitario", detalle.precio_unitario);
                    command.ExecuteNonQuery();
                }

                return success;
            }

        }
    }
}
