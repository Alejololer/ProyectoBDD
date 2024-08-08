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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI.Pacientes
{
    public partial class AñadirTelefonoEmpleado : Form
    {
        BindingList<TelefonoEmpleado> telefonos = new BindingList<TelefonoEmpleado>();
        public AñadirTelefonoEmpleado(BindingList<TelefonoEmpleado> telefonos)
        {
            InitializeComponent();
            txtNum.KeyPress += OnKeyPressNum;
            this.telefonos = telefonos;
        }

        public TelefonoEmpleado TelefonoEmpleado = null;
        private void button1_Click(object sender, EventArgs e)
        {
            // Enviar un mensaje
            DialogResult result = MessageBox.Show("¿Está seguro?", "Añadir Telefono Empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (TelefonoEmpleado telefono in telefonos)
                {
                    if (txtNum.Text == telefono.telefono)
                    {
                        // El producto ya está en la lista de detalles
                        MessageBox.Show("El telefono ya está en la lista de telefonos.", "Añadir Telefono Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                TelefonoEmpleado = new TelefonoEmpleado(txtNum.Text, txtTipo.Text);
                MessageBox.Show("Telefono añadido con exito!", "Añadir Telefono Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ActualizarPaciente_Load(object sender, EventArgs e)
        {

        }


        private void OnKeyPressNumDec(object? sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar switch
            {
                >= '0' and <= '9' => false, // allow numerics
                '\b' => false,              // allow backspace
                '.' => false,               // allow decimal separator
                _ => true
            };
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
    }
}
