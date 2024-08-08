using DataAccess;
using DataAccess.Entities;
using Domain;
using PlayerUI.Pacientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI.Pedidos
{
    public partial class ConsultarProductos : Form
    {
        SqlConnection coneccion = new SqlConnection("Data Source=PCALEJO\\BDD;Initial Catalog=MarujaGuayaquil;User ID=sa;Password=P@ssw0rd");
        public ConsultarProductos()
        {
            InitializeComponent();
            llenarDGV();
            TipoExamenModel tipoExamen = new TipoExamenModel();
            txtNombre.KeyPress += OnKeyPress;
        }

        private void OnKeyPress(object? sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '\b' ||
                          e.KeyChar == 'á' || e.KeyChar == 'é' || e.KeyChar == 'í' || e.KeyChar == 'ó' || e.KeyChar == 'ú' ||
                          e.KeyChar == 'Á' || e.KeyChar == 'É' || e.KeyChar == 'Í' || e.KeyChar == 'Ó' || e.KeyChar == 'Ú' ||
                          e.KeyChar == 'ñ' || e.KeyChar == 'Ñ');
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ConsultarPedido_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            String nombre = txtNombre.Text;
            if (nombre.Length == 0)
            {
                llenarDGV();
                return;
            }
            ProductoModel pacientemod = new ProductoModel();

            if (!pacientemod.Check(txtNombre.Text.ToUpper()))
            {
                MessageBox.Show("Producto no encontrado", "Buscar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else
            {
                using (var connection = coneccion)
                {
                    {
                        connection.Open();

                        var consulta = new SqlCommand();
                        consulta.CommandText = "SELECT * FROM v_stocks_sucursales WHERE nombre = @nombre";
                        consulta.Parameters.AddWithValue("@nombre", nombre);

                        consulta.Connection = connection;  // Asignar la conexión al SqlCommand

                        SqlDataAdapter adapter = new SqlDataAdapter(consulta);

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;

                    }
                }

            }

        }

        private void llenarDGV()
        {
            string consulta = "Select * from v_stocks_sucursales";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, coneccion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "ID Producto";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].HeaderText = "Precio";
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].HeaderText = "Stock Quito";
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].HeaderText = "Stock Guayaquil";
            dataGridView1.Columns[4].Width = 150;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                if (Convert.ToString(selectedRow.Cells["nombre"].Value).Equals(""))
                {
                    MessageBox.Show("Fila no válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Extract the necessary data from the selected row
                int idProducto = Convert.ToInt32(selectedRow.Cells["id_producto"].Value);
                string nombre = Convert.ToString(selectedRow.Cells["nombre"].Value);
                decimal precio = Convert.ToDecimal(selectedRow.Cells["precio"].Value);
                object stockValue = selectedRow.Cells["stock_sucursalQ"].Value;
                int stockQuito = (stockValue == DBNull.Value) ? 0 : Convert.ToInt32(stockValue);
                stockValue = selectedRow.Cells["stock_sucursalG"].Value;
                int stockGuayaquil = (stockValue == DBNull.Value) ? 0 : Convert.ToInt32(stockValue);
                // Create an instance of the class using the extracted data
                
                Producto producto = new Producto(idProducto, nombre, (float)precio, stockGuayaquil);


                // Create an instance of the form to modify the product
                ActualizarProducto formActualizarProducto = new ActualizarProducto(producto);
                formActualizarProducto.FormClosing += FormActualizarProducto_FormClosing;
                formActualizarProducto.Show();
                
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna fila.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormActualizarProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            llenarDGV(); // Execute llenarDGV() after closing the form
        }
    }
}
