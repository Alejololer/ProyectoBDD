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
    public partial class ModificarRea : Form
    {
        public ModificarRea()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Enviar un mensaje
            DialogResult result = MessageBox.Show("¿Está seguro?", "Modificación de Reactivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Reactivo modificado con éxito", "Modificación de Reactivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
            }
            this.Close();
        }
    }
}
