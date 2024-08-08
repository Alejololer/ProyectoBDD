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
    public partial class ConsultarEmpleados : Form
    {
        public ConsultarEmpleados()
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
                string query = "SELECT * FROM v_empleados";
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
                            dataGridView1.Columns[0].HeaderText = "Número de Cédula";
                            dataGridView1.Columns[0].Width = 200;
                            dataGridView1.Columns[1].HeaderText = "Nombres";
                            dataGridView1.Columns[1].Width = 200;
                            dataGridView1.Columns[2].HeaderText = "Apellidos";
                            dataGridView1.Columns[2].Width = 200;
                            dataGridView1.Columns[3].HeaderText = "ID Sucursal";
                            dataGridView1.Columns[3].Width = 50;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar el DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void llenarDataGridView1(string cedula)
        {
            try
            {
                string connectionString = "Data Source=PCALEJO\\BDD;Initial Catalog=MarujaGuayaquil;User ID=sa;Password=P@ssw0rd";
                string query = "SELECT * FROM v_empleados where cedula= @id";
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var consulta = new SqlCommand(query, connection))
                    {
                        consulta.Parameters.AddWithValue("@id", cedula);
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(consulta))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            //formato
                            dataGridView1.DataSource = dt;
                            dataGridView1.Columns[0].HeaderText = "Número de Cédula";
                            dataGridView1.Columns[0].Width = 200;
                            dataGridView1.Columns[1].HeaderText = "Nombres";
                            dataGridView1.Columns[1].Width = 200;
                            dataGridView1.Columns[2].HeaderText = "Apellidos";
                            dataGridView1.Columns[2].Width = 200;
                            dataGridView1.Columns[3].HeaderText = "ID Sucursal";
                            dataGridView1.Columns[3].Width = 50;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar el DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void llenarDataGridView2(string id)
        {
            try
            {
                string connectionString = "Data Source=PCALEJO\\BDD;Initial Catalog=MarujaGuayaquil;User ID=sa;Password=P@ssw0rd";
                string query = "SELECT * FROM telefonos_emp_2 where cedula_empleado = @id";
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
                            dgvTipoExamen.Columns[0].HeaderText = "ID Telefono";
                            dgvTipoExamen.Columns[0].Width = 50;
                            dgvTipoExamen.Columns[1].HeaderText = "Cedula Empleado";
                            dgvTipoExamen.Columns[1].Width = 200;
                            dgvTipoExamen.Columns[2].HeaderText = "ID Sucursal";
                            dgvTipoExamen.Columns[2].Width = 50;
                            dgvTipoExamen.Columns[3].HeaderText = "Telefono";
                            dgvTipoExamen.Columns[3].Width = 100;
                            dgvTipoExamen.Columns[4].HeaderText = "Tipo";
                            dgvTipoExamen.Columns[4].Width = 100;

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
                string id = (string)celda.Value;
                llenarDataGridView2(id);
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar un empleado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }else if (ValidarCedulaEcuatoriana(txtID.Text) == false)
            {
                MessageBox.Show("Cedula incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            EmpleadoModel facturaModel = new EmpleadoModel();

            if (!facturaModel.Check(txtID.Text))
            {
                MessageBox.Show("No se encontro una factura con este numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            llenarDataGridView1(txtID.Text);
        }

        public bool ValidarCedulaEcuatoriana(string cedula)
        {
            // Verificar longitud
            if (cedula.Length != 10)
            {
                return false;
            }

            // Verificar que todos los caracteres sean dígitos
            foreach (char c in cedula)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            // Extraer el dígito verificador
            int digitoVerificador = int.Parse(cedula.Substring(9, 1));

            // Calcular el dígito verificador esperado
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int suma = 0;
            for (int i = 0; i < coeficientes.Length; i++)
            {
                int valor = int.Parse(cedula.Substring(i, 1)) * coeficientes[i];
                suma += (valor >= 10) ? valor - 9 : valor;
            }
            int residuo = suma % 10;
            int digitoEsperado = (residuo == 0) ? 0 : 10 - residuo;

            // Comparar con el dígito verificador proporcionado
            return digitoVerificador == digitoEsperado;
        }


    }
}
