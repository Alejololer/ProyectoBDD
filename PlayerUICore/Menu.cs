using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Entities;
using PlayerUI.Instrumento;
using PlayerUI.Pacientes;
using PlayerUI.Parametros;
using PlayerUI.Pedidos;
using PlayerUI.Reactivos;
using PlayerUI.Resultados;
using PlayerUI.Usuario;
using PlayerUI.Ventas;

namespace PlayerUI
{
    public partial class Menu : Form
    {
        User usuario = new User();
        public Menu()
        {
            InitializeComponent();
            customizeDesign();
            hideSubMenu();
        }
        private void customizeDesign()
        {
            panelClientesSubMenu.Visible = false;
            panelProductosSubMenu.Visible = false;
            panelFacturaciónSubMenu.Visible = false;
            panelEmpleadosSubMenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelClientesSubMenu.Visible == true)
                panelClientesSubMenu.Visible = false;

            if (panelProductosSubMenu.Visible == true)
                panelProductosSubMenu.Visible = false;

            if (panelFacturaciónSubMenu.Visible == true)
                panelFacturaciónSubMenu.Visible = false;

            if (panelEmpleadosSubMenu.Visible == true)
                panelEmpleadosSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            showSubMenu(panelClientesSubMenu);
        }

        #region MediaSubMenu
        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new RegistrarCliente());
            //..
            //your codes
            //..
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new ConsultarCliente());

        }

        private void button4_Click(object sender, EventArgs e)
        {

            openChildForm(new ActualizarCliente());

        }


        #endregion

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            showSubMenu(panelProductosSubMenu);
        }

        #region PlayListManagemetSubMenu
        private void button8_Click(object sender, EventArgs e)
        {
            openChildForm(new RegistrarProducto());
            //..
            //your codes
            //..
        }


        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new ConsultarProductos());
            //..
            //your codes
            //..
        }

        #endregion

        private void btnTools_Click(object sender, EventArgs e)
        {
            //showSubMenu(panelResultadosSubMenu);
        }
        #region ToolsSubMenu
        private void button13_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
        }
        #endregion

        private void btnEqualizer_Click(object sender, EventArgs e)
        {
            //showSubMenu(panelResultadosSubMenu);

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.AutoScaleMode = AutoScaleMode.None;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnParámetros_Click(object sender, EventArgs e)
        {
            showSubMenu(panelFacturaciónSubMenu);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            openChildForm(new RegistrarInstrumento());

        }

        private void btnPaciente_Click(object sender, EventArgs e)
        {
            showSubMenu(panelClientesSubMenu);
        }



        private void button17_Click(object sender, EventArgs e)
        {
            openChildForm(new ConsultarResul());
        }


        private void button18_Click(object sender, EventArgs e)
        {
            openChildForm(new RegistrarResul());
        }

        private void button20_Click(object sender, EventArgs e)
        {
            openChildForm(new ConsultarRea());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            openChildForm(new ModificarRea());
        }

        private void button22_Click(object sender, EventArgs e)
        {
            openChildForm(new EliminarReactivo());
        }



        private void button26_Click(object sender, EventArgs e)
        {
            openChildForm(new ConsultarInstrumento());
        }

        private void button25_Click(object sender, EventArgs e)
        {
            openChildForm(new ActualizarInstrumento());
        }

        private void button23_Click(object sender, EventArgs e)
        {
            openChildForm(new EliminarInstrumento());
        }

        private void button29_Click(object sender, EventArgs e)
        {
            openChildForm(new ConsultarInformeVentas());
        }

        private void button33_Click(object sender, EventArgs e)
        {
            openChildForm(new GenerarVenta(usuario));
        }



        private void button31_Click(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {


        }

        private void button37_Click(object sender, EventArgs e)
        {
            openChildForm(new RegistrarTipoExamen());
        }

        private void button36_Click(object sender, EventArgs e)
        {
            openChildForm(new ConsultarTipoExamen());
        }


        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new ModificarIVA());
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            openChildForm(new RegistrarIVA());
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            openChildForm(new GenerarResul());
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            openChildForm(new ConsultarVentas());
        }

        private void button13_Click_1(object sender, EventArgs e)
        {

            openChildForm(new ConsultarVentas());
            MessageBox.Show("Solo el Jefe de laboratorio puede acceder a esta sección", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(panelEmpleadosSubMenu);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
