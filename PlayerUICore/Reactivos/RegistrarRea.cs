using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI.Reactivos
{
    public partial class RegistrarRea : Form
    {
        public RegistrarRea()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Enviar un mensaje
            DialogResult result = MessageBox.Show("¿Está seguro?", "Registro de Reactivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Reactivo registrado con éxito", "Registro de Reactivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
            }
            this.Close();
        }
    }
}
