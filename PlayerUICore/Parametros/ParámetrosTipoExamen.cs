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

namespace PlayerUICore.Parametros
{
    public partial class ParámetrosTipoExamen : Form
    {
        bool parametroTipo  = false;
        TipoExamen tipoExamen = null;
        public ParámetrosTipoExamen(TipoExamen tipoexamen)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            tipoExamen = tipoexamen;
            txtNomPar.KeyPress += OnKeyPress;
            txtvalMax.KeyPress += OnKeyPressNum;
            txtValMin.KeyPress += OnKeyPressNum;
        }

        private void OnKeyPress(object? sender, KeyPressEventArgs e)
        {
            // Obtener el carácter ingresado
            char keyPressed = e.KeyChar;

            // Verificar si el carácter es un número, letra minúscula, letra mayúscula, espacio, backspace, guión o barra inclinada
            bool isValidInput = (keyPressed >= '0' && keyPressed <= '9') ||      // Números
                                (keyPressed >= 'a' && keyPressed <= 'z') ||      // Letras minúsculas
                                (keyPressed >= 'A' && keyPressed <= 'Z') ||      // Letras mayúsculas
                                (keyPressed == ' ') ||                           // Espacio
                                (keyPressed == '\b') ||                          // Retroceso (backspace)
                                (keyPressed == '-') ||                           // Guion
                                (keyPressed == '/');                             // Barra inclinada

            // Establecer si se manejará el evento o no
            e.Handled = !isValidInput;
        }

        private void OnKeyPressNum(object? sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar switch
            {
                >= '0' and <= '9' => false, // allow numerics
                '\b' => false,              // allow backspace
                '.' => false,
                _ => true
            };

        }

        private void ParámetrosTipoExamen_Load(object sender, EventArgs e)
        {

        }

        private bool EsNumeroDecimalValido(string texto)
        {
            // Verificar si el texto está vacío
            if (texto == "")
                return true;

            // Verificar si el texto representa un número decimal válido
            return decimal.TryParse(texto, out _);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!EsNumeroDecimalValido(txtValMin.Text))
            {
                MessageBox.Show("Valor mínimo no válido!", "Registrar Parámetro de Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!EsNumeroDecimalValido(txtvalMax.Text))
            {
                MessageBox.Show("Valor máximo no válido!", "Registrar Parámetro de Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtvalMax.Text == "" && txtValMin.Text != "")
            {
                MessageBox.Show("Si registra un valor mínimo, registre un valor máximo!", "Registrar Parámetro de Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtvalMax.Text != "" && txtValMin.Text == "")
            {
                MessageBox.Show("Si registra un valor máximo, registre un valor mínimo!", "Registrar Parámetro de Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtvalMax.Text != "")
            {
                if (float.Parse(txtvalMax.Text) <= float.Parse(txtValMin.Text))
                {
                    MessageBox.Show("El valor máximo debe ser mayor al valor mínimo!", "Registrar Parámetro de Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txtNomPar.Text == "")
            {
                MessageBox.Show("Nombre de parámetro inválido!", "Registrar Parámetro de Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("¿Está seguro?", "Registrar Parámetro de Tipo de Examen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ParametroTipoExamenModel parametroTipoExamenModel = new ParametroTipoExamenModel();
                if (txtvalMax.Text != "" && txtValMin.Text != "" && txtUn.Text != "")
                    parametroTipoExamenModel.registrarParTipoExamen(tipoExamen.Id, txtNomPar.Text, float.Parse(txtValMin.Text), float.Parse(txtvalMax.Text), txtUn.Text.Trim());
                else if (txtvalMax.Text != "" && txtValMin.Text != "")
                    parametroTipoExamenModel.registrarParTipoExamenRango(tipoExamen.Id, txtNomPar.Text, float.Parse(txtValMin.Text), float.Parse(txtvalMax.Text));
                else if (txtUn.Text != "")
                    parametroTipoExamenModel.registrarParTipoExamenUnidad(tipoExamen.Id, txtNomPar.Text, txtUn.Text.Trim());
                else
                    parametroTipoExamenModel.registrarParTipoExamenNull(tipoExamen.Id, txtNomPar.Text);
                MessageBox.Show("Parámetro registrado correctamente!", "Registrar Parámetro de Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNomPar.Text = "";
                txtvalMax.Text = "";
                txtValMin.Text = "";
                txtUn.Text = "";
                llenarDGV();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (parametroTipo == true)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("El tipo de examen debe contener al menos un parámetro!", "Registrar Parámetro de Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void llenarDGV()
        {
            parametroTipo = true;
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

                    }
                }
            }

        }
    }
}
