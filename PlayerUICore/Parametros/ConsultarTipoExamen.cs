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
    public partial class ConsultarTipoExamen : Form
    {
        TipoExamen tipoExamen = null;
        public ConsultarTipoExamen()
        {
            InitializeComponent();
            txtNomTipo.KeyPress += OnKeyPress;
            llenarDataGridViewTodo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ConsultarTipoExamen_Load(object sender, EventArgs e)
        {

        }

        private bool obtenerPrecio()
        {
            if (txtNomTipo.Text.Length <= 1)
            {
                MessageBox.Show("Nombre de Tipo de examen inválido!", "Modificar precio Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            TipoExamenModel model = new TipoExamenModel();
            if (!model.Check(txtNomTipo.Text))
            {
                MessageBox.Show("Tipo de examen no encontrado!", "Modificar precio Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            tipoExamen = model.GetTipoExamen(txtNomTipo.Text);
            return true;
        }
        private void llenarDataGridViewTodo()
        {
            try
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Requerimientos;Integrated Security=SSPI";
                string query = "SELECT * FROM TIPOSEXAMEN";
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
                            dataGridView1.Columns[0].HeaderText = "ID";
                            dataGridView1.Columns[0].Width = 50;
                            dataGridView1.Columns[1].HeaderText = "Nombre";
                            dataGridView1.Columns[1].Width = 400;
                            dataGridView1.Columns[2].HeaderText = "Costo";
                            dataGridView1.Columns[2].Width = 150;
                            dataGridView1.Columns[2].DefaultCellStyle.Format = "N2";

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("No se encontraron parámetros para este tipo de examen!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar el DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void llenarDataGridView1(string nombreTipo)
        {
            try
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Requerimientos;Integrated Security=SSPI";
                string query = "SELECT * FROM TIPOSEXAMEN WHERE NOMBRETIPOEXAMEN = @nombreTipo";
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var consulta = new SqlCommand(query, connection))
                    {
                        consulta.Parameters.AddWithValue("@nombreTipo", nombreTipo);

                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(consulta))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            //formato
                            dataGridView1.DataSource = dt;
                            dataGridView1.Columns[0].HeaderText = "ID";
                            dataGridView1.Columns[0].Width = 50;
                            dataGridView1.Columns[1].HeaderText = "Nombre";
                            dataGridView1.Columns[1].Width = 400;
                            dataGridView1.Columns[2].HeaderText = "Costo";
                            dataGridView1.Columns[2].Width = 150;
                            dataGridView1.Columns[2].DefaultCellStyle.Format = "N2";

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("No se encontraron parámetros para este tipo de examen!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar el DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void llenarDataGridView2()
        {
            try
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Requerimientos;Integrated Security=SSPI";
                string query = "SELECT p.IDPARAMETRO, NOMBREPARAMETRO, MINPARAMETRO, MAXPARAMETRO, UNIDADPARAMETRO" +
                    " FROM TIPOSEXAMEN te JOIN TIPOEXAMEN_PARAMETRO tep ON te.IDTIPOEXAMEN = tep.IDTIPOEXAMEN" +
                    " JOIN PARAMETROSTIPOEXAMEN p ON tep.IDPARAMETRO = p.IDPARAMETRO WHERE te.IDTIPOEXAMEN = @id";
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var consulta = new SqlCommand(query, connection))
                    {
                        consulta.Parameters.AddWithValue("@id", tipoExamen.Id);

                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(consulta))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            //formato
                            dgvTipoExamen.DataSource = dt;
                            dgvTipoExamen.Columns[0].HeaderText = "ID";
                            dgvTipoExamen.Columns[0].Width = 50;
                            dgvTipoExamen.Columns[1].HeaderText = "Nombre";
                            dgvTipoExamen.Columns[1].Width = 100;
                            dgvTipoExamen.Columns[2].HeaderText = "Minimo Rango Normal";
                            dgvTipoExamen.Columns[2].Width = 175;
                            dgvTipoExamen.Columns[3].HeaderText = "Maximo Rango Normal";
                            dgvTipoExamen.Columns[3].Width = 175;
                            dgvTipoExamen.Columns[4].HeaderText = "Unidad";
                            dgvTipoExamen.Columns[4].Width = 100;

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("No se encontraron parámetros para este tipo de examen!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
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
                DataGridViewCell celda1 = filaSeleccionada.Cells[1];
                DataGridViewCell celda2 = filaSeleccionada.Cells[2];
                int id = (int)celda.Value;
                string nombre = (string)celda1.Value;
                decimal costo = (decimal)celda2.Value;
                tipoExamen = new TipoExamen(id, nombre, costo);
                llenarDataGridView2();
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar un tipo de examen!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void OnKeyPress(object? sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar switch
            {
                >= '0' and <= '9' => false, // allow numerics
                >= 'a' and <= 'z' => false, // allow lowercase characters
                >= 'A' and <= 'Z' => false, // allow uppercase characters
                '\b' => false,              // allow backspace
                '-' => false,
                '/' => false,
                ' ' => false,
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
            if (obtenerPrecio())
            {
                llenarDataGridView1(txtNomTipo.Text);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                DataGridViewCell celda = filaSeleccionada.Cells[0];
                DataGridViewCell celda1 = filaSeleccionada.Cells[1];
                DataGridViewCell celda2 = filaSeleccionada.Cells[2];
                int id = (int)celda.Value;
                string nombre = (string)celda1.Value;
                decimal costo = (decimal)celda2.Value;
                tipoExamen = new TipoExamen(id, nombre, costo);
                ModificarPrecio modificarPrecio = new ModificarPrecio(tipoExamen);
                modificarPrecio.Show();
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar un tipo de examen!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
