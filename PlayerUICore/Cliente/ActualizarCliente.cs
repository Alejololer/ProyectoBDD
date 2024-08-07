using DataAccess.Entities;
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

namespace PlayerUI.Pacientes
{
    public partial class ActualizarCliente : Form
    {
        Cliente cliente = null;
        public ActualizarCliente()
        {
            InitializeComponent();
            txtNom.ReadOnly = true;
            txtDir.ReadOnly = true;
            txtTel.ReadOnly = true;
            txtCed.KeyPress += OnKeyPressNum;
            txtTel.KeyPress += OnKeyPressNum;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cliente == null) {
                // Realizar acciones si el formato es válido
                MessageBox.Show("Primero consulte un paciente!", "Actualizar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtTel.Text.Length <= 6)
            {
                // Realizar acciones si el formato es válido
                MessageBox.Show("El formato del teléfono no es válido.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }




            // Enviar un mensaje
            DialogResult result = MessageBox.Show("¿Está seguro?", "Actualizar información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ClienteModel pacienteModel = new ClienteModel();
                pacienteModel.actualizarCliente(txtCed.Text, txtTel.Text, txtDir.Text);
                MessageBox.Show("Información de Paciente actualizada correctamente", "Actualizar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ActualizarPaciente_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClienteModel pacientemod = new ClienteModel();

            if (!pacientemod.Check(txtCed.Text))
            {
                MessageBox.Show("Paciente no encontrado", "Buscar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            //Validar cedula
            string cedula = txtCed.Text;
            if (!ValidarCedulaEcuatoriana(cedula))
            {
                // Realizar acciones si el formato es válido
                MessageBox.Show("La cédula no es válida.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cliente = new Cliente();
            cliente = pacientemod.obtenerClienteCI(cedula);
            txtNom.Text = cliente.nombresCliente;
            txtDir.Text = cliente.direccionClientee;
            txtTel.Text = cliente.telefonoCliente;
            txtTel.ReadOnly = false;
            txtDir.ReadOnly = false;

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


        private void OnKeyPressNum(object? sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar switch
            {
                >= '0' and <= '9' => false, // allow numerics
                '\b' => false,              // allow backspace
                _ => true
            };
        }
    }
}
