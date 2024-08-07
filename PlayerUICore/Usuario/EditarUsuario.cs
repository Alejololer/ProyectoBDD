using DataAccess.Entities;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUICore.Usuario
{
    public partial class Editar_Usuario : Form
    {
        private bool mostrarTexto = false;

        private User user;
        public Editar_Usuario(User user)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.user = user;
            txtNom.Text = user.nombreUsuario;
            txtNom.ReadOnly = true;
            txtCon.Text = user.claveUsuario;
            txtTipo.Text = user.tipoUsuario;
            txtTipo.ReadOnly = true;
            txtCon.KeyPress += OnKeyPress;
            btnMostrar.MouseDown += buttonMostrar_MouseDown;
            btnMostrar.MouseUp += buttonMostrar_MouseUp;
        }

        private bool ContieneCaracterEspecial(string texto)
        {
            // Lista de caracteres especiales permitidos
            char[] caracteresEspeciales = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '+', '=', '[', ']', '{', '}', ':', ';', ',', '.', '/', '?', '|', '\\', '<', '>', '`', '~', '\'', '\"', ' ' };

            // Verificar si el texto contiene al menos un carácter especial
            return texto.Any(c => caracteresEspeciales.Contains(c));
        }

        private void OnKeyPress(object? sender, KeyPressEventArgs e)
        {
            bool isSpecialChar = e.KeyChar switch
            {
                >= '0' and <= '9' => false, // allow numerics
                >= 'a' and <= 'z' => false, // allow lowercase characters
                >= 'A' and <= 'Z' => false, // allow uppercase characters
                '\b' => false,              // allow backspace
                '!' or '@' or '#' or '$' or '%' or '^' or '&' or '*' or '(' or ')' or '-' or '_' or '+' or '=' or '[' or ']' or '{' or '}' or ':' or ';' or ',' or '.' or '/' or '?' or '|' or '\\' or '<' or '>' or '`' or '~' or '\'' or '\"' or ' ' => false, // allow special characters

                _ => true
            };

            e.Handled = isSpecialChar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNom.Text.Length <= 3 || !ContieneCaracterEspecial(txtCon.Text))
            {
                MessageBox.Show("Ingrese una contraseña válida!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            DialogResult result = MessageBox.Show("¿Está seguro?", "Actualizar Usuario", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                UserModel userModel = new UserModel();
                
                userModel.ActualizarUser(user.Id, txtCon.Text);
                MessageBox.Show("Usuario editado correctamente!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Editar_Usuario_Load(object sender, EventArgs e)
        {

        }

        private void buttonMostrar_MouseDown(object sender, MouseEventArgs e)
        {
            mostrarTexto = true; // Mostrar el texto
            MostrarOcultarTexto();
        }

        private void buttonMostrar_MouseUp(object sender, MouseEventArgs e)
        {
            mostrarTexto = false; // Ocultar el texto
            MostrarOcultarTexto();
        }

        private void MostrarOcultarTexto()
        {
            if (mostrarTexto)
            {
                txtCon.PasswordChar = '\0'; // Mostrar el texto sin enmascarar
            }
            else
            {
                txtCon.PasswordChar = '*'; // Enmascarar el texto
            }
        }
    }
}
