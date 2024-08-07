using DataAccess.Entities;
using Domain;
using PlayerUICore.Parametros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI.Parametros
{
    public partial class RegistrarTipoExamen : Form
    {
        TipoExamen tipoExamen = null;
        public RegistrarTipoExamen()
        {
            InitializeComponent();
            txtNomTipo.KeyPress += OnKeyPress;
            txtCostoTipo.KeyPress += OnKeyPressNum;
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (txtNomTipo.Text.Length <= 1)
            {
                MessageBox.Show("Nombre de Tipo de examen inválido!", "Registrar Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtCostoTipo.Text == "" || !EsPrecioValido(txtCostoTipo.Text))
            {
                MessageBox.Show("Costo de Tipo de examen inválido!", "Registrar Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("¿Está seguro?", "Registro de Paciente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                TipoExamenModel model = new TipoExamenModel();
                if (model.Check(txtNomTipo.Text))
                {
                    MessageBox.Show("Tipo de Examen ya registrado!", "Registrar Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                model.RegistrarTipoExamen(txtNomTipo.Text, decimal.Parse(txtCostoTipo.Text));
                tipoExamen = model.GetTipoExamen(txtNomTipo.Text);
                MessageBox.Show("Tipo de Examen registrado correctamente", "Registrar Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ParámetrosTipoExamen a = new ParámetrosTipoExamen(tipoExamen);
            a.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNomTipo_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegistrarTipoExamen_Load(object sender, EventArgs e)
        {

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

        private bool EsPrecioValido(string texto)
        {
            // Verificar si el texto está vacío
            if (string.IsNullOrWhiteSpace(texto))
                return false;

            // Verificar si el texto contiene solo dígitos y un solo punto
            bool puntoEncontrado = false;
            foreach (char caracter in texto)
            {
                if (caracter == '.')
                {
                    // Permitir solo un punto en la cadena
                    if (puntoEncontrado)
                        return false;
                    puntoEncontrado = true;
                }
                else if (!char.IsDigit(caracter))
                {
                    // Permitir solo dígitos y un punto en la cadena
                    return false;
                }
            }

            // Verificar si el texto representa un número válido
            return decimal.TryParse(texto, out _);
        }



        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
