using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class RegistrarInstrumento : Form
    {
        string nombreInsrumento;
        string cantidadInstrumento;
        public RegistrarInstrumento()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            nombreInsrumento = txtNombreInstrumento.Text;
            cantidadInstrumento = txtCantidadInstrumento.Text;

            if (nombreInsrumento != null || nombreInsrumento != "")
            {
                MessageBox.Show("Instrumento registrado con exito");
            }
            else
            {
                MessageBox.Show("Nombre de instrumento invalido");
            }
            if (cantidadInstrumento != null || cantidadInstrumento != "")
            {
                MessageBox.Show("Instrumento registrado con exito");
            }
            else
            {
                MessageBox.Show("Cantidad de instrumento invalido");
            }

        }

        private void RegistrarInstrumento_Load(object sender, EventArgs e)
        {

        }
    }
}
