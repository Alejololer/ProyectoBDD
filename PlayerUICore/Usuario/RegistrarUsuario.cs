using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PlayerUI.Usuario
{
    public partial class RegistrarUsuario : Form
    {
        private bool mostrarTexto = false;
        public RegistrarUsuario()
        {

            InitializeComponent();
            txtCon.KeyPress += OnKeyPress;
            txtNom.KeyPress += OnKeyPress;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.Validating += comboBox1_Validating; // Conectar el evento Validating
            btnMostrar.MouseDown += buttonMostrar_MouseDown;
            btnMostrar.MouseUp += buttonMostrar_MouseUp;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistrarUsuario_Load(object sender, EventArgs e)
        {

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

        private void button9_Click(object sender, EventArgs e)
        {
            if (txtNom.Text.Length<=3)
            {
                MessageBox.Show("Ingrese un nombre de usuario válido!", "Registro de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNom.Text.Length<=3||!ContieneCaracterEspecial(txtCon.Text))
            {
                MessageBox.Show("Ingrese una contraseña válida!", "Registro de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Ingrese un tipo de usuario!", "Registro de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UserModel userModel = new UserModel();
            var existe = userModel.CheckUsuario(txtNom.Text);
            if (existe == true)
            {
                MessageBox.Show("Un usuario con este nombre de usuario ya está registrado", "Registro de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(userModel.RegistrarUsuario(txtNom.Text, txtCon.Text, comboBox1.Text))
            {
                MessageBox.Show("El usuario ha sido registrado con éxito", "Registro de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
                MessageBox.Show("El registro de usuario ha fallado", "Registro de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void comboBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)sender;

            // Verificar si el texto ingresado coincide con alguna de las opciones de la ComboBox
            if (!comboBox.Items.Contains(comboBox.Text))
            {
                // Si el texto no coincide con ninguna opción, mostrar un mensaje de error
                MessageBox.Show("Por favor, seleccione una opción válida de la lista de tipos de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Cancelar el evento de validación para evitar que la ComboBox pierda el foco
            }
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
