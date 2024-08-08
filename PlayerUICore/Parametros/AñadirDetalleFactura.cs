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

namespace PlayerUI.Pacientes
{
    public partial class AñadirDetalleFactura : Form
    {
        BindingList<DetalleFactura> detalles = new BindingList<DetalleFactura>();
        public AñadirDetalleFactura(BindingList<DetalleFactura> detalles)
        {
            InitializeComponent();
            txtPrecio.KeyPress += OnKeyPressNumDec;
            txtStock.KeyPress += OnKeyPressNum;
            this.detalles = detalles;
        }

        public DetalleFactura DetalleFactura = null;
        private void button1_Click(object sender, EventArgs e)
        {
            // Enviar un mensaje
            DialogResult result = MessageBox.Show("¿Está seguro?", "Añadir Detalle Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (!EsPrecioValido(txtPrecio.Text))
                {
                    MessageBox.Show("Ingrese un precio unitario válido!", "Añadir Detalle Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ProductoModel productoModel = new ProductoModel();
                int id = productoModel.CheckNombre(txtNom.Text.ToUpper());
                if (id == 0)
                {
                    MessageBox.Show("No se encontro un producto con este nombre!", "Añadir Detalle Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!productoModel.CheckStock(id, int.Parse(txtStock.Text)))
                {
                    MessageBox.Show("No hay suficiente stock en el inventario para añadir esto a la factura!", "Añadir Detalle Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (DetalleFactura detalle in detalles)
                {
                    if (id == detalle.id_producto)
                    {
                        // El producto ya está en la lista de detalles
                        MessageBox.Show("El producto ya está en la lista de detalles.", "Añadir Detalle Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                DetalleFactura = new DetalleFactura(txtNom.Text.ToUpper(),id, int.Parse(txtStock.Text), float.Parse(txtPrecio.Text, CultureInfo.InvariantCulture));
                MessageBox.Show("Detalle Factura añadido con exito!", "Añadir Detalle Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private bool EsPrecioValido(string texto)
        {
            // Verificar si el texto está vacío
            if (string.IsNullOrWhiteSpace(texto))
                return false;

            // Verificar si el texto contiene solo dígitos y un solo punto
            bool puntoEncontrado = false;
            foreach (char caracter in texto)
            {
                if (caracter == '.')
                {
                    // Permitir solo un punto en la cadena
                    if (puntoEncontrado)
                        return false;
                    puntoEncontrado = true;
                }
                else if (!char.IsDigit(caracter))
                {
                    // Permitir solo dígitos y un punto en la cadena
                    return false;
                }
            }

            // Verificar si el texto representa un número válido
            return decimal.TryParse(texto, out _);
        }
    }
}
