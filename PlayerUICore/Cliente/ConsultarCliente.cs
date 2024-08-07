using DataAccess;
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

namespace PlayerUI.Pacientes
{
    public partial class ConsultarCliente : Form
    {

        string cedula;
        SqlConnection coneccion = new SqlConnection("Data Source=PCALEJO\\BDD;Initial Catalog=MarujaGuayaquil;User ID=sa;Password=P@ssw0rd");


        public ConsultarCliente()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClienteDAO pacienteDAO = new ClienteDAO();
            cedula = txtCedula.Text;
  
            if (!ValidarCedulaEcuatoriana(cedula))
            {
                MessageBox.Show("La cédula no es válida.", "Verificar datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ClienteModel pacientemod = new ClienteModel();

            if (!pacientemod.Check(txtCedula.Text))
            {
                MessageBox.Show("Paciente no encontrado", "Buscar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else
                {
                    using (var connection = coneccion)
                    {
                        {
                            connection.Open();

                            var consulta = new SqlCommand();
                            consulta.CommandText = "SELECT * FROM Clientes WHERE cedula = @cedula";
                            consulta.Parameters.AddWithValue("@cedula", cedula);

                            consulta.Connection = connection;  // Asignar la conexión al SqlCommand

                            SqlDataAdapter adapter = new SqlDataAdapter(consulta);

                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgvPaciente.DataSource = dt;

                        }
                    }

                }



        }

        private void llenarDataGridView()
        {
            string consulta = "Select * from Clientes";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, coneccion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvPaciente.DataSource = dt;
            dgvPaciente.Columns[0].HeaderText = "Cédula de Identidad";
            dgvPaciente.Columns[0].Width = 100;
            dgvPaciente.Columns[1].HeaderText = "Nombres";
            dgvPaciente.Columns[1].Width = 150;
            dgvPaciente.Columns[2].HeaderText = "Teléfono";
            dgvPaciente.Columns[2].Width = 100;
            dgvPaciente.Columns[3].HeaderText = "Dirección";
            dgvPaciente.Columns[3].Width = 150;
            dgvPaciente.Columns[4].HeaderText = "ID Sucursal";
            dgvPaciente.Columns[4].Width = 100;
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void ConsultarPaciente_Load(object sender, EventArgs e)
        {
            llenarDataGridView();
        }
    }
}
