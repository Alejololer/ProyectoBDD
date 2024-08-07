﻿using System;
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
            panelPacientesSubMenu.Visible = false;
            panelPedidosSubMenu.Visible = false;
            panelReactivosSubMenu.Visible = false;
            panelUsuariosSubMenu.Visible = false;
            panelParámetrosSubMenu.Visible = false;
            panelVentasSubMenu.Visible = false;
            panelInstrumentosSubMenu.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelPacientesSubMenu.Visible == true)
                panelPacientesSubMenu.Visible = false;

            if (panelPedidosSubMenu.Visible == true)
                panelPedidosSubMenu.Visible = false;

            //if (//panelResultadosSubMenu.Visible == true)
            //  panelResultadosSubMenu.Visible = false;

            if (panelReactivosSubMenu.Visible == true)
                panelReactivosSubMenu.Visible = false;

            if (panelUsuariosSubMenu.Visible == true)
                panelUsuariosSubMenu.Visible = false;

            if (panelParámetrosSubMenu.Visible == true)
                panelParámetrosSubMenu.Visible = false;

            if (panelVentasSubMenu.Visible == true)
                panelVentasSubMenu.Visible = false;

            if (panelInstrumentosSubMenu.Visible == true)
                panelInstrumentosSubMenu.Visible = false;

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
            showSubMenu(panelPacientesSubMenu);
        }

        #region MediaSubMenu
        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new RegistrarPaciente());
            //..
            //your codes
            //..
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new ConsultarPaciente());

        }

        private void button4_Click(object sender, EventArgs e)
        {

            openChildForm(new ActualizarPaciente());
            
        }


        #endregion

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPedidosSubMenu);
        }

        #region PlayListManagemetSubMenu
        private void button8_Click(object sender, EventArgs e)
        {
            openChildForm(new RegistrarPedido());
            //..
            //your codes
            //..
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new EstadisticaPedido());
            //..
            //your codes
            //..
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new ConsultarPedido());
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

        private void button16_Click(object sender, EventArgs e)
        {
            openChildForm(new ModificarResul());
        }

        private void button21_Click(object sender, EventArgs e)
        {
            openChildForm(new RegistrarRea());
        }

        private void panelPacientesSubPacientes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReactivos_Click(object sender, EventArgs e)
        {
            showSubMenu(panelReactivosSubMenu);
        }

        private void btnInstrumentos_Click(object sender, EventArgs e)
        {
            showSubMenu(panelInstrumentosSubMenu);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            showSubMenu(panelVentasSubMenu);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            showSubMenu(panelUsuariosSubMenu);
        }

        private void btnParámetros_Click(object sender, EventArgs e)
        {
            if (usuario.tipoUsuario == "Jefe de laboratorio")
            {
                showSubMenu(panelParámetrosSubMenu);
            }
            else
            {
                MessageBox.Show("Solo el Jefe de laboratorio puede acceder a esta sección", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

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
            showSubMenu(panelPacientesSubMenu);
        }



        private void button17_Click(object sender, EventArgs e)
        {
            openChildForm(new ConsultarResul());
        }


        private void button11_Click(object sender, EventArgs e)
        {
            openChildForm(new EliminarPedido());
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
            if (usuario.tipoUsuario == "Jefe de laboratorio")
            {
                openChildForm(new ConsultarVentas());
            }
            else
            {
                MessageBox.Show("Solo el Jefe de laboratorio puede acceder a esta sección", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            penChildForm(new ConsultarInformeVentas());
        }

        private void button24_Click_1(object sender, EventArgs e)
        {
            openChildForm(new RegistrarUsuario());
        }

        private void button19_Click(object sender, EventArgs e)
        {
            openChildForm(new ConsultarUsuario());
        }

        private void button29_Click_1(object sender, EventArgs e)
        {
            openChildForm(new RegistrarIVA());
        }

        private void button28_Click(object sender, EventArgs e)
        {
            openChildForm(new ModificarIVA());
        }

        private void button5_Click_2(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(panel3);
        }
    }
}
