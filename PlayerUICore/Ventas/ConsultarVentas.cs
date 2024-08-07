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
    public partial class ConsultarVentas : Form
    {
        BindingList<Venta> ventas = null;
        public ConsultarVentas()
        {
            InitializeComponent();
            txtCI.KeyPress += OnKeyPressNum;
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
            // Enviar un mensaje
            DialogResult result = MessageBox.Show("¿Está seguro?", "Generar Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Factura generada  correctamente", "Generar Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

            }
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

        private void lblNombreInstrumento_Click(object sender, EventArgs e)
        {

        }

        private void GenerarFactura_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!ValidarCedulaEcuatoriana(txtCI.Text))
            {
                // Realizar acciones si el formato es válido
                MessageBox.Show("La cédula no es válida.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PacienteModel paciente = new PacienteModel();
            if (!paciente.Check(txtCI.Text))
            {
                MessageBox.Show("Paciente no encontrado!", "Registrar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            VentaModel ventaModel = new VentaModel();
            ventas = ventaModel.ObtenerVentasCI(txtCI.Text);
            if (ventas.Count == 0)
            {
                MessageBox.Show("¡No se han encontrado ventas registradas para este paciente!", "Registrar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                llenarDGV();
            }
        }

        private void llenarDGV()
        {
            VentaModel ventaModel = new VentaModel();
            ventas = ventaModel.ObtenerVentasCI(txtCI.Text);
            dgvVentas.DataSource = ventas;
            dgvVentas.Columns[1].Visible = false;
            dgvVentas.Columns[2].Visible = false;
            dgvVentas.Columns[3].Visible = false;
            dgvVentas.Columns[5].Visible = false;
            dgvVentas.DataSource = ventas;
            dgvVentas.Columns[0].HeaderText = "ID";
            dgvVentas.Columns[0].Width = 50;
            dgvVentas.Columns[4].HeaderText = "Precio Total";
            dgvVentas.Columns[4].Width = 185;
            dgvVentas.Columns[6].HeaderText = "Precio Final";
            dgvVentas.Columns[6].Width = 185;
            dgvVentas.Columns[7].HeaderText = "Fecha Venta";
            dgvVentas.Columns[7].Width = 185;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 0)
            {

                DataGridViewRow filaSeleccionada = dgvVentas.SelectedRows[0];
                int idventa =Convert.ToInt32(filaSeleccionada.Cells[0].Value);
                // Mostrar mensaje de confirmación
                DialogResult result = MessageBox.Show("¿Está seguro?", "Anular Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Verificar la respuesta del usuario
                if (result == DialogResult.Yes)
                {
                    VentaModel ventaModel = new VentaModel();
                    ventaModel.AnularVenta(idventa);
                    MessageBox.Show("La venta ha sido anulada correctamente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    llenarDGV();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila antes de intentar eliminar un tipo de examen.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
