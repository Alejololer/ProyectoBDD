using DataAccess.Entities;
using Domain;
using PlayerUI.Pacientes;
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

    public partial class RegistrarFactura : Form
    {
        decimal total;
        BindingList<DetalleFactura> detalles = new BindingList<DetalleFactura>();
        public RegistrarFactura()
        {
            InitializeComponent();
            txtCedCli.KeyPress += OnKeyPressNum;
            txtCedEmp.KeyPress += OnKeyPressNum;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ClienteModel clienteModel = new ClienteModel();
            if (!ValidarCedulaEcuatoriana(txtCedCli.Text))
            {
                MessageBox.Show("La cédula del cliente no es válida.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }else if (!clienteModel.Check(txtCedCli.Text))
            {
                MessageBox.Show("No se encontró un cliente con esta cédula.", "Registro de Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidarCedulaEcuatoriana(txtCedEmp.Text))
            {
                MessageBox.Show("La cédula del empleado no es válida.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            EmpleadoModel empleadoModel = new EmpleadoModel();
            if (!empleadoModel.Check(txtCedEmp.Text))
            {
                MessageBox.Show("No se encontró un empleado con esta cédula.", "Registro de Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (detalles.Count() == 0)
            {
                MessageBox.Show("No se han añadido detalles a la factura.", "Registro de Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FacturaModel facturaModel = new FacturaModel();
            if(facturaModel.registrarFactura(total, txtCedEmp.Text, txtCedCli.Text, detalles))
            {
                MessageBox.Show("Factura registrada con exito!", "Registro de Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNomTipo_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegistrarTipoExamen_Load(object sender, EventArgs e)
        {

        }
        private void OnKeyPress(object? sender, KeyPressEventArgs e)
        {
            // Obtener el carácter ingresado
            char keyPressed = e.KeyChar;

            // Verificar si el carácter es un número, letra minúscula, letra mayúscula, espacio, backspace, guión o barra inclinada
            bool isValidInput = (keyPressed >= '0' && keyPressed <= '9') ||      // Números
                                (keyPressed >= 'a' && keyPressed <= 'z') ||      // Letras minúsculas
                                (keyPressed >= 'A' && keyPressed <= 'Z') ||      // Letras mayúsculas
                                (keyPressed == ' ') ||                           // Espacio
                                (keyPressed == '\b') ||                          // Retroceso (backspace)
                                (keyPressed == '-') ||                           // Guion
                                (keyPressed == '/');                             // Barra inclinada

            // Establecer si se manejará el evento o no
            e.Handled = !isValidInput;
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AñadirDetalleFactura añadirDetalleForm = new AñadirDetalleFactura(detalles);
            añadirDetalleForm.FormClosed += AñadirDetalleForm_FormClosed;
            añadirDetalleForm.ShowDialog();

        }
        private void AñadirDetalleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AñadirDetalleFactura añadirDetalleForm = (AñadirDetalleFactura)sender;

            // Check if a new DetalleFactura was created in the AñadirDetalleFactura form
            if (añadirDetalleForm.DetalleFactura != null && añadirDetalleForm.DetalleFactura.id_producto != null)
            {
                detalles.Add(añadirDetalleForm.DetalleFactura);
                llenarDGV();
                // Calculate the total value
                total = 0;
                foreach (DetalleFactura detalle in detalles)
                {
                    decimal subtotal = detalle.unidades * (decimal)detalle.precio_unitario;
                    total += subtotal;
                }

                // Display the total value in txtTotal
                txtTotal.Text = total.ToString("C2");
            }
        }
        private void llenarDGV()
        {
            // Ensure the DataGridView has the correct number of columns
            if (dataGridView1.Columns.Count < 3)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("id_producto", "ID Producto");

                dataGridView1.Columns.Add("nombre_producto", "Nombre Producto");
                dataGridView1.Columns["nombre_producto"].Width = 200;

                dataGridView1.Columns.Add("unidades", "Unidades");
                dataGridView1.Columns.Add("precio_unitario", "Precio Unitario");
            }

            // Clear the existing rows in the DataGridView
            dataGridView1.Rows.Clear();

            // Iterate through the detalles list and add each item to the DataGridView
            foreach (DetalleFactura detalle in detalles)
            {
                // Create a new row and set the values of each cell
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = detalle.id_producto;
                row.Cells[1].Value = detalle.nombre_producto;
                row.Cells[2].Value = detalle.unidades;
                row.Cells[3].Value = detalle.precio_unitario;

                // Add the row to the DataGridView
                dataGridView1.Rows.Add(row);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0] != null)
            {

                // Get the selected row index
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                if(selectedIndex > detalles.Count()-1)
                {
                    MessageBox.Show("Seleccione un detalle primero!.", "Eliminar Detalle Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Get the DetalleFactura object associated with the selected row
                DetalleFactura detalle = detalles[selectedIndex];

                // Remove the DetalleFactura from the detalles list
                detalles.Remove(detalle);

                // Refresh the DataGridView
                llenarDGV();

                // Recalculate the total value
                total = 0;
                foreach (DetalleFactura d in detalles)
                {
                    decimal subtotal = d.unidades * (decimal)d.precio_unitario;
                    total += subtotal;
                }

                // Display the updated total value in txtTotal
                txtTotal.Text = total.ToString("C2");
            }
            else
            {
                MessageBox.Show("Seleccione un detalle primero!.", "Eliminar Detalle Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
