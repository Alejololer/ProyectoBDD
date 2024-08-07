using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class ConsultarInstrumento : Form
    {
        string nombreInstrumento;

        public ConsultarInstrumento()
        {
            InitializeComponent();
        }

        private void btnConsultarInstrumento_Click(object sender, EventArgs e)
        {
            nombreInstrumento = txtNombreInstrumento.Text;
            if(nombreInstrumento == null || nombreInstrumento == "")
            {
                MessageBox.Show("Nombre de instrumento inválido");
            }
            else
            {
                MessageBox.Show("Instrumento no encontrado");
            }



        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvConsultarInstrumentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }
    }
}
