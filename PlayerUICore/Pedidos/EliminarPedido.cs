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

namespace PlayerUI.Pedidos
{
    public partial class EliminarPedido : Form
    {
        public EliminarPedido()
        {
            InitializeComponent();
            txtCI.KeyPress += OnKeyPressNum;
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

        public bool ValidarCedulaEcuatoriana(string cedula)
        {
            // Verificar longitud
            if (cedula.Length != 10)
            {
                return false;
            }

            // Verificar que todos los caracteres sean dígitos
            foreach (char c in cedula)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            // Extraer el dígito verificador
            int digitoVerificador = int.Parse(cedula.Substring(9, 1));

            // Calcular el dígito verificador esperado
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int suma = 0;
            for (int i = 0; i < coeficientes.Length; i++)
            {
                int valor = int.Parse(cedula.Substring(i, 1)) * coeficientes[i];
                suma += (valor >= 10) ? valor - 9 : valor;
            }
            int residuo = suma % 10;
            int digitoEsperado = (residuo == 0) ? 0 : 10 - residuo;

            // Comparar con el dígito verificador proporcionado
            return digitoVerificador == digitoEsperado;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidarCedulaEcuatoriana(txtCI.Text))
            {
                // Realizar acciones si el formato es válido
                MessageBox.Show("La cédula no es válida.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ClienteModel paciente = new ClienteModel();
            if (!paciente.Check(txtCI.Text))
            {
                MessageBox.Show("Paciente no encontrado!", "Registrar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PedidoModel pedidoModel = new PedidoModel();
            if (!pedidoModel.Check(txtCI.Text))
            {
                // Realizar acciones si el formato es válido
                MessageBox.Show("¡No se ha encontrado un pedido registrado para este paciente!", "Consultar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Pedido pedido = null;
            pedido = pedidoModel.ObtenerPedido(txtCI.Text);
            VentaModel venta = new VentaModel();
            if (venta.Check(pedido.Id))
            {
                // Realizar acciones si el formato es válido
                MessageBox.Show("¡No puede eliminar un pedido con una venta realizada, primero anule la venta!", "Consultar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Enviar un mensaje
            DialogResult result = MessageBox.Show("¿Está seguro?", "Eliminar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                pedidoModel.EliminarPedido(txtCI.Text);
                MessageBox.Show("Pedido eliminado correctamente", "Eliminar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EliminarPedido_Load(object sender, EventArgs e)
        {

        }
    }
}
