using DataAccess.Entities;
using Domain;
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
    public partial class RegistrarIVA : Form
    {
        public RegistrarIVA()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Enviar un mensaje
            IVAModel model = new IVAModel();
            IVA iva = model.getIVA();
            if (iva != null)
            {
                MessageBox.Show("Un valor de IVA ya está registrado, modifíquelo desde Modificar IVA", "Registrar IVA", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            DialogResult result = MessageBox.Show("¿Está seguro?", "Registrar IVA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                model.registrarIVA(int.Parse(txtIVA.Text));
                MessageBox.Show("IVA registrado correctamente", "Registrar IVA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

            };
        }
    }
}
