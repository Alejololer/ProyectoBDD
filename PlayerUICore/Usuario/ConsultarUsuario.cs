using DataAccess;
using DataAccess.Entities;
using Domain;
using PlayerUICore.Usuario;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PlayerUI.Usuario
{
    public partial class ConsultarUsuario : Form
    {
        string nombreUsuario;

        public ConsultarUsuario()
        {
            InitializeComponent();
            txtNombreUsuario.KeyPress += OnKeyPress;

        }
        private void ConsultarUsuario_Load(object sender, EventArgs e)
        {
            llenarDataGridView();
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                // Obtener el nombre del usuario seleccionado (ajusta esto según tu estructura de datos)
                string nombreUsuario = dgvUsuarios.SelectedRows[0].Cells["NOMBREUSER"].Value.ToString();
                if(nombreUsuario == "admin")
                {
                    MessageBox.Show("No puede eliminar al administrador!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Cerrar el formulario actual
                    llenarDataGridView();
                }
                // Mostrar mensaje de confirmación
                DialogResult result = MessageBox.Show($"¿Está seguro de que desea eliminar al usuario '{nombreUsuario}'?", "Eliminar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Verificar la respuesta del usuario
                if (result == DialogResult.Yes)
                {
                    UserModel userModel = new UserModel();
                    if (userModel.EliminarUsuario(nombreUsuario))
                    {
                        MessageBox.Show("Usuario eliminado correctamente!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Cerrar el formulario actual
                        llenarDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar usuario!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila antes de intentar eliminar un usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        private void consultarUsuarios()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Requerimientos;Integrated Security=SSPI";
            using (var connection = new SqlConnection(connectionString))
            {
                using (var consulta = new SqlCommand("SELECT * FROM Users WHERE NOMBREUSER = @user", connection))
                {
                    consulta.Parameters.AddWithValue("@user", nombreUsuario);

                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(consulta))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvUsuarios.DataSource = dt;
                        //Formato
                        dgvUsuarios.Columns[0].HeaderText = "ID";
                        dgvUsuarios.Columns[0].Width = 50;
                        dgvUsuarios.Columns[1].HeaderText = "Nombre de Usuario";
                        dgvUsuarios.Columns[1].Width = 150;
                        dgvUsuarios.Columns[2].HeaderText = "Contraseña";
                        dgvUsuarios.Columns[3].HeaderText = "Tipo de Usuario";
                        dgvUsuarios.Columns[3].Width = 250;

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No se encontró un usuario con ese nombre.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }



        private void btnConsultar_Click(object sender, EventArgs e)
        {
            nombreUsuario = txtNombreUsuario.Text;

            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                llenarDataGridView();
                return;
            }

            consultarUsuarios();
        }

        private void llenarDataGridView()
        {
            try
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Requerimientos;Integrated Security=SSPI";
                string consulta = "SELECT * FROM dbo.USERS";

                using (var connection = new SqlConnection(connectionString))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(consulta, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvUsuarios.DataSource = dt;
                        //Formato
                        dgvUsuarios.Columns[0].HeaderText = "ID";
                        dgvUsuarios.Columns[0].Width = 50;
                        dgvUsuarios.Columns[1].HeaderText = "Nombre de Usuario";
                        dgvUsuarios.Columns[1].Width = 150;
                        dgvUsuarios.Columns[2].HeaderText = "Contraseña";
                        dgvUsuarios.Columns[3].HeaderText = "Tipo de Usuario";
                        dgvUsuarios.Columns[3].Width = 250;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar el DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnKeyPress(object? sender, KeyPressEventArgs e)
        {
            bool isSpecialChar = e.KeyChar switch
            {
                >= '0' and <= '9' => false, // allow numerics
                >= 'a' and <= 'z' => false, // allow lowercase characters
                >= 'A' and <= 'Z' => false, // allow uppercase characters
                '\b' => false,              // allow backspace
                '!' or '@' or '#' or '$' or '%' or '^' or '&' or '*' or '(' or ')' or '-' or '_' or '+' or '=' or '[' or ']' or '{' or '}' or ':' or ';' or ',' or '.' or '/' or '?' or '|' or '\\' or '<' or '>' or '`' or '~' or '\'' or '\"' => false, // allow special characters

                _ => true
            };

            e.Handled = isSpecialChar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                // Obtener el nombre del usuario seleccionado (ajusta esto según tu estructura de datos)
                int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["IDUSER"].Value);
                UserModel userModel = new UserModel();
                User user = userModel.ObtenerUserUsername(idUsuario);
                Editar_Usuario editar_Usuario = new Editar_Usuario(user);
                editar_Usuario.FormClosed += FormularioSecundario_Cerrado;
                editar_Usuario.ShowDialog();

            }
            else
            {
                MessageBox.Show("Seleccione una fila antes de intentar editar usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormularioSecundario_Cerrado(object sender, FormClosedEventArgs e)
        {
            llenarDataGridView();
        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
