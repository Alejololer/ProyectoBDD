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
    public partial class ActualizarPaciente : Form
    {
        public ActualizarPaciente()
        {
            InitializeComponent();
            txtNom.ReadOnly = true;
            txtApell.ReadOnly = true;
            txtFeNac.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Enviar un mensaje
            DialogResult result = MessageBox.Show("¿Está seguro?", "Actualizar información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Información de Paciente actualizada correctamente", "Eliminación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ActualizarPaciente_Load(object sender, EventArgs e)
        {

        }
    }
}
