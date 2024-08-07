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
    public partial class ModificarIVA : Form
    {
        public ModificarIVA()
        {
            InitializeComponent();
            txtIVA.ReadOnly = true;
            txtIVANew.KeyPress += OnKeyPressNum;
            getIVA();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            // Enviar un mensaje
            DialogResult result = MessageBox.Show("¿Está seguro?", "Modificar IVA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                IVAModel model = new IVAModel();    
                model.registrarIVA(int.Parse(txtIVANew.Text));
                MessageBox.Show("IVA modificado correctamente", "Modificar IVA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getIVA();
                txtIVANew.Text = "";
            }
            else
            {

            };
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidadInstrumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void ModificarIVA_Load(object sender, EventArgs e)
        {
            getIVA();   
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

        private void getIVA()
        {
            IVAModel model = new IVAModel();
            IVA iva = model.getIVA();
            if(iva == null)
            {
                MessageBox.Show("Debe registrar un valor de IVA", "Modificar IVA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIVA.Text = "No hay valor IVA registrado";
                return;
            }
            txtIVA.Text = iva.valor.ToString();
        }
    }
}
