using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI.Instrumento
{
    public partial class EliminarInstrumento : Form
    {


        public EliminarInstrumento()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizarInstrumento_Click(object sender, EventArgs e)
        {
            // Enviar un mensaje
            DialogResult result = MessageBox.Show("¿Está seguro?", "Eliminar Instrumento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Instrumento eliminado correctamente", "Eliminar Instrumento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

            };
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
