using DataAccess.Entities;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI.Pacientes
{
    public partial class ActualizarProducto : Form
    {
        Producto producto = null;
        public ActualizarProducto(Producto producto)
        {
            InitializeComponent();
            txtNom.ReadOnly = true;
            txtPrecio.ReadOnly = true;
            txtPrecio.KeyPress += OnKeyPressNumDec;
            txtStock.KeyPress += OnKeyPressNum;
            this.producto=producto;
            txtNom.Text = producto.Nombre;
            txtStock.Text = producto.Stock.ToString();
            txtPrecio.Text = producto.Precio.ToString();
            txtStock.ReadOnly = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Enviar un mensaje
            DialogResult result = MessageBox.Show("¿Está seguro?", "Actualizar información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ProductoModel productoModel = new ProductoModel();
                if (productoModel.CheckLocal(producto.Id))
                {
                    if(productoModel.actualizarProductoStockExiste(producto.Id, int.Parse(txtStock.Text)))
                    {
                        MessageBox.Show("Stock de producto actualizado con éxito!.", "Registro de Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (productoModel.actualizarProductoStockNoExiste(producto.Id, int.Parse(txtStock.Text)))
                    {
                        MessageBox.Show("Stock de producto actualizado con éxito!.", "Registro de Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ActualizarPaciente_Load(object sender, EventArgs e)
        {

        }


        private void OnKeyPressNumDec(object? sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar switch
            {
                >= '0' and <= '9' => false, // allow numerics
                '\b' => false,              // allow backspace
                '.' => false,               // allow decimal separator
                _ => true
            };
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
    }
}
