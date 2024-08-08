using DataAccess;
using DataAccess.Entities;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI.Pedidos
{
    public partial class RegistrarProducto : Form
    {
        public RegistrarProducto()
        {
            InitializeComponent();
            txtPrecio.KeyPress += OnKeyPressNumDecimal;
            txtNom.KeyPress += OnKeyPress;
            txtStock.KeyPress += OnKeyPressNum;
        }


        private void OnKeyPressNumDecimal(object? sender, KeyPressEventArgs e)
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

        private void OnKeyPress(object? sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '\b' ||
                          e.KeyChar == 'á' || e.KeyChar == 'é' || e.KeyChar == 'í' || e.KeyChar == 'ó' || e.KeyChar == 'ú' ||
                          e.KeyChar == 'Á' || e.KeyChar == 'É' || e.KeyChar == 'Í' || e.KeyChar == 'Ó' || e.KeyChar == 'Ú' ||
                          e.KeyChar == 'ñ' || e.KeyChar == 'Ñ');
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            if(txtNom.Text.Equals(""))
            {
                MessageBox.Show("El formato del nombre no es válido", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }else if (!IsValidDecimal(txtPrecio.Text)) {
                MessageBox.Show("El formato del precio no es válido", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Enviar un mensaje
            DialogResult result = MessageBox.Show("¿Está seguro?", "Actualizar información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ProductoModel productoModel = new ProductoModel();
                if (productoModel.Check(txtNom.Text.ToUpper()))
                {
                    MessageBox.Show("Un producto con este nombre ya está registrado.", "Registro de Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (txtStock.Text.Equals(""))
                {
                    productoModel.registrarProductoNoStock(txtNom.Text.ToUpper(), float.Parse(txtPrecio.Text, CultureInfo.InvariantCulture));
                    MessageBox.Show("Producto registrado con éxito!.", "Registro de Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    productoModel.registrarProductoStock(txtNom.Text.ToUpper(), float.Parse(txtPrecio.Text, CultureInfo.InvariantCulture), int.Parse(txtStock.Text));
                    MessageBox.Show("Producto registrado con éxito!.", "Registro de Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        public bool IsValidDecimal(string input)
        {
            float result;
            return float.TryParse(input, out result);
        }


    }
}
