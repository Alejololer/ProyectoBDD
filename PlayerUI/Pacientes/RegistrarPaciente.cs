using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI.Pacientes
{
    public partial class RegistrarPaciente : Form
    {
        public RegistrarPaciente()
        {
            InitializeComponent();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Enviar un mensaje
            DialogResult result = MessageBox.Show("¿Está seguro?", "Registro de Paciente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Paciente registrado con éxito", "Registro de Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
            }
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistrarPaciente_Load(object sender, EventArgs e)
        {

        }

        private void OnKeyPress(object? sender, KeyPressEventArgs e)
        {
            // allow numerics
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                return;

            // allow lowercase characters
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                return;

            // allow uppercase characters
            if (e.KeyChar >= 'A' && e.KeyChar <= 'Z')
                return;

            // allow backspace and other special characters in the string
            if ("\b".Contains(e.KeyChar))
                return;

            e.Handled = true;
        }
    }
}
