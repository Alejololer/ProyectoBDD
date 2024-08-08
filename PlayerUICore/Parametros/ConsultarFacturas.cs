using DataAccess.Entities;
using Domain;
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


namespace PlayerUI.Parametros
{
    public partial class ConsultarFacturas : Form
    {
        public ConsultarFacturas()
        {
            InitializeComponent();
            txtID.KeyPress += OnKeyPressNum;
            llenarDataGridViewTodo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ConsultarTipoExamen_Load(object sender, EventArgs e)
        {

        }
        private void llenarDataGridViewTodo()
        {
            try
            {
                string connectionString = "Data Source=PCALEJO\\BDD;Initial Catalog=MarujaGuayaquil;User ID=sa;Password=P@ssw0rd";
                string query = "SELECT * FROM v_facturas";
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var consulta = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(consulta))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            //formato
                            dataGridView1.DataSource = dt;
                            dataGridView1.Columns[0].HeaderText = "Número Factura";
                            dataGridView1.Columns[0].Width = 100;
                            dataGridView1.Columns[1].HeaderText = "Fecha";
                            dataGridView1.Columns[1].Width = 100;
                            dataGridView1.Columns[2].HeaderText = "Total";
                            dataGridView1.Columns[2].Width = 100;
                            dataGridView1.Columns[3].HeaderText = "ID Sucursal";
                            dataGridView1.Columns[3].Width = 50;
                            dataGridView1.Columns[4].HeaderText = "Cedula Empleado";
                            dataGridView1.Columns[4].Width = 100;
                            dataGridView1.Columns[5].HeaderText = "Cedula Cliente";
                            dataGridView1.Columns[5].Width = 100;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar el DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void llenarDataGridView1(int id)
        {
            try
            {
                string connectionString = "Data Source=PCALEJO\\BDD;Initial Catalog=MarujaGuayaquil;User ID=sa;Password=P@ssw0rd";
                string query = "SELECT * FROM v_facturas where numero_factura = @id";
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var consulta = new SqlCommand(query, connection))
                    {
                        consulta.Parameters.AddWithValue("@id", id);
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(consulta))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            //formato
                            dataGridView1.DataSource = dt;
                            dataGridView1.Columns[0].HeaderText = "Número Factura";
                            dataGridView1.Columns[0].Width = 100;
                            dataGridView1.Columns[1].HeaderText = "Fecha";
                            dataGridView1.Columns[1].Width = 100;
                            dataGridView1.Columns[2].HeaderText = "Total";
                            dataGridView1.Columns[2].Width = 100;
                            dataGridView1.Columns[3].HeaderText = "ID Sucursal";
                            dataGridView1.Columns[3].Width = 50;
                            dataGridView1.Columns[4].HeaderText = "Cedula Empleado";
                            dataGridView1.Columns[4].Width = 125;
                            dataGridView1.Columns[5].HeaderText = "Cedula Cliente";
                            dataGridView1.Columns[5].Width = 125;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar el DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void llenarDataGridView2(int id)
        {
            try
            {
                string connectionString = "Data Source=PCALEJO\\BDD;Initial Catalog=MarujaGuayaquil;User ID=sa;Password=P@ssw0rd";
                string query = "SELECT * FROM detalles_fac_2 where numero_factura = @id";
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var consulta = new SqlCommand(query, connection))
                    {
                        consulta.Parameters.AddWithValue("@id", id);
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(consulta))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            //formato
                            dgvTipoExamen.DataSource = dt;
                            dgvTipoExamen.Columns[0].HeaderText = "ID Detalle";
                            dgvTipoExamen.Columns[0].Width = 50;
                            dgvTipoExamen.Columns[1].HeaderText = "Numero Factura";
                            dgvTipoExamen.Columns[1].Width = 50;
                            dgvTipoExamen.Columns[2].HeaderText = "ID Producto";
                            dgvTipoExamen.Columns[2].Width = 50;
                            dgvTipoExamen.Columns[3].HeaderText = "ID Sucursal";
                            dgvTipoExamen.Columns[3].Width = 50;
                            dgvTipoExamen.Columns[4].HeaderText = "Unidades";
                            dgvTipoExamen.Columns[4].Width = 100;
                            dgvTipoExamen.Columns[5].HeaderText = "Precio unitario";
                            dgvTipoExamen.Columns[5].Width = 100;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar el DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                DataGridViewCell celda = filaSeleccionada.Cells[0];
                int id = (int)celda.Value;
                llenarDataGridView2(id);
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar una factura!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void OnKeyPressNum(object? sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar switch
            {
                >= '0' and <= '9' => false, // allow numerics
                '\b' => false,              // allow backspace
                _ => true
            };
        }



        private void dgvTipoExamen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvTipoExamen_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtID.Text.Equals(""))
            {
                llenarDataGridViewTodo();
                dgvTipoExamen.DataSource = null;
                dgvTipoExamen.Rows.Clear();
                dgvTipoExamen.Columns.Clear();
                return;
            }
            FacturaModel facturaModel = new FacturaModel();

            if (!facturaModel.Check(int.Parse(txtID.Text)))
            {
                MessageBox.Show("No se encontro una factura con este numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            llenarDataGridView1(int.Parse(txtID.Text));
        }

        
    }
}
