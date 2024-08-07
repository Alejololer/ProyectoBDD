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

namespace PlayerUI.Ventas
{
    public partial class GenerarVenta : Form
    {
        Pedido pedido = null;
        Venta venta = null;
        Cliente Cliente = null;
        BindingList<Examen> examenes = null;
        IVA iva = null;
        public GenerarVenta(User user)
        {
            InitializeComponent();
            txtCI.KeyPress += OnKeyPressCed;
            txtNom.ReadOnly = true;
            txtApe.ReadOnly = true;
            txtTotalIVA.ReadOnly = true;
            txtTotalNoIVA.ReadOnly = true;
            txtIVA.ReadOnly = true;
            textBox1.KeyPress += OnKeyPressNum;
            if(user.tipoUsuario == "Asistente de laboratorio")
                textBox1.ReadOnly = true;
            IVAModel model = new IVAModel();
            iva = model.getIVA();
            IVA.Text = "IVA VENTA (" + iva.valor.ToString() + "%):";
        }

        private bool EsPrecioValido(string texto)
        {

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

        private void OnKeyPressCed(object? sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar switch
            {
                >= '0' and <= '9' => false, // allow numerics
                '\b' => false,              // allow backspace
                _ => true
            };
        }

        private void OnKeyPressNum(object? sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar switch
            {
                >= '0' and <= '9' => false, // allow numerics
                '\b' => false,              // allow backspace
                '.' => false,
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultarInstrumento_Click(object sender, EventArgs e)
        {
            if (pedido == null)
            {
                MessageBox.Show("¡Primero debe consultar un pedido!", "Generar Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            VentaModel ventaModel = new VentaModel();
            if (ventaModel.Check(pedido.Id))
            {
                MessageBox.Show("Ya se ha generado una venta para el pedido de este Cliente", "Generar Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Enviar un mensaje
            DialogResult result = MessageBox.Show("¿Está seguro?", "Generar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                VentaModel model = new VentaModel();
                if (textBox1.Text != "" && !EsPrecioValido(textBox1.Text))
                {
                    MessageBox.Show("Nuevo total no válido", "Generar Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(textBox1.Text != "")
                {
                    MessageBox.Show("Venta generada correctamente", "Generar Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    model.registrarVentaMod(venta, decimal.Parse(textBox1.Text));
                }
                else {
                    model.registrarVenta(venta);
                    MessageBox.Show("Venta generada correctamente", "Generar Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Reset();
            }
            else
            {

            };
        }

        private void RegistrarVenta_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Validar cedula
            string cedula = txtCI.Text;
            if (!ValidarCedulaEcuatoriana(cedula))
            {
                // Realizar acciones si el formato es válido
                MessageBox.Show("La cédula no es válida.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ClienteModel tp = new ClienteModel();
            if (!tp.Check(txtCI.Text))
            {
                MessageBox.Show("Cliente no encontrado", "Registrar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PedidoModel temp = new PedidoModel();
            if (!temp.Check(cedula))
            {
                // Realizar acciones si el formato es válido
                MessageBox.Show("No existe un pedido pendiente para este Cliente!", "Registrar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Cliente = tp.obtenerClienteCI(txtCI.Text);
            txtNom.Text = Cliente.nombresCliente;
            PedidoModel pedidoModel = new PedidoModel();
            pedido = pedidoModel.ObtenerPedido(txtCI.Text);
            VentaModel ventaModel = new VentaModel();
            venta = ventaModel.consultarDatosVenta(cedula, pedido.Id, iva.valor);
            ExamenModel examenModel = new ExamenModel();
            examenes = examenModel.ObtenerExamenesPedido(pedido.Id);
            txtTotalNoIVA.Text = venta.precioFinalNoIVA.ToString();
            txtTotalIVA.Text = venta.precioFinalIVA.ToString();
            txtIVA.Text = venta.ventaIVA.ToString();
            llenarDGV();
        }

        private void llenarDGV()
        {
            if (examenes != null)
            {
                dataGridView1.DataSource = examenes;
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].HeaderText = "Tipo de Examen";
                dataGridView1.Columns[4].Width = 400;
                dataGridView1.Columns[5].HeaderText = "Costo";
                dataGridView1.Columns[5].Width = 150;
                dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
            }
        }

        private void Reset()
        {
            textBox1.Text = "";
            txtCI.Text = "";
            txtApe.Text = "";
            txtNom.Text = "";
            txtIVA.Text = "";
            txtTotalIVA.Text = "";
            txtTotalNoIVA.Text = "";
            examenes = null;
            Cliente = null;
            pedido = null;
            venta = null;
            dataGridView1.Rows.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
