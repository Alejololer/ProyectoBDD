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
        public RegistrarTipoExamen()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tipo de Examen registrado correctamente", "Registrar Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
