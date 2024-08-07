using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Domain;
using System.Text.RegularExpressions;


namespace PlayerUI.Pacientes
{
    public partial class RegistrarCliente : Form
    {
        public RegistrarCliente()
        {
            InitializeComponent();
            txtCed.KeyPress += OnKeyPressNum;
            txtTel.KeyPress += OnKeyPressNum;
            txtNom.KeyPress += OnKeyPress;
        }

        private void button9_Click(object sender, EventArgs e)
        {

            //Validar cedula
            string cedula = txtCed.Text;
            if (!ValidarCedulaEcuatoriana(cedula))
            {
                // Realizar acciones si el formato es válido
                MessageBox.Show("La cédula no es válida.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Validar nombres
            if (!ValidarFormatoNombre(txtNom))
            {
                // Realizar acciones si el formato es válido
                MessageBox.Show("El formato de los nombres no es válido.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtTel.Text.Length <= 6)
            {
                // Realizar acciones si el formato es válido
                MessageBox.Show("El formato del teléfono no es válido.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ClienteModel user = new ClienteModel();
            var existe = user.Check(txtCed.Text);
            if (existe == true)
            {
                MessageBox.Show("Un cliente con esta cédula ya está registrado.", "Registro de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro?", "Registro de cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ClienteModel model = new ClienteModel();
                var validRegister = model.registrarCliente(cedula, txtNom.Text, txtTel.Text, txtDir.Text);
                if (validRegister)
                {
                    MessageBox.Show("Cliente registrado con éxito.", "Registro de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error en el registro de cliente.", "Registro de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

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

        private void OnKeyPress(object? sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '\b' ||
                          e.KeyChar == 'á' || e.KeyChar == 'é' || e.KeyChar == 'í' || e.KeyChar == 'ó' || e.KeyChar == 'ú' ||
                          e.KeyChar == 'Á' || e.KeyChar == 'É' || e.KeyChar == 'Í' || e.KeyChar == 'Ó' || e.KeyChar == 'Ú' ||
                          e.KeyChar == 'ñ' || e.KeyChar == 'Ñ');
        }


        private bool ValidarFormatoNombre(System.Windows.Forms.TextBox textBox)
        {
            // Verificar si el texto está en el formato "Nombre Apellido"
            string[] partes = textBox.Text.Split(' ');
            if (partes.Length != 2)
            {
                return false;
            }
            else
            {
                bool formatoCorrecto = partes.All(part =>
                    !string.IsNullOrWhiteSpace(part) &&
                    part.All(char.IsLetter) &&
                    char.IsUpper(part[0])); // Verificar si la primera letra es mayúscula
                if (!formatoCorrecto)
                {
                    return false;
                }
            }
            return true;
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


        private void RegistrarPaciente_Load(object sender, EventArgs e)
        {

        }

        private void txtCed_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegistrarPaciente_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}