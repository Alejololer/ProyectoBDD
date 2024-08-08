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

    public partial class RegistrarEmpleado : Form
    {
        decimal total;
        BindingList<TelefonoEmpleado> telefonos = new BindingList<TelefonoEmpleado>();
        public RegistrarEmpleado()
        {
            InitializeComponent();
            txtCedEmp.KeyPress += OnKeyPressNum;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(txtCedEmp.Text == "" || txtNom.Text == "" || txtApe.Text == "")
            {
                MessageBox.Show("Por favor llene todos los campos.", "Registrar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ValidarCedulaEcuatoriana(txtCedEmp.Text))
            {
                MessageBox.Show("Ingrese una cédula válida.", "Registrar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            EmpleadoModel empleadoModel = new EmpleadoModel();
            if (empleadoModel.Check(txtCedEmp.Text))
            {
                MessageBox.Show("Ya existe un empleado con esta cédula.", "Registrar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            empleadoModel.registrarEmpleado(txtCedEmp.Text, txtNom.Text, txtApe.Text, telefonos);
            MessageBox.Show("Empleado registrado con exito!.", "Registrar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            AñadirTelefonoEmpleado añadirTelefonoForm = new AñadirTelefonoEmpleado(telefonos);
            añadirTelefonoForm.FormClosed += AñadirTelefonoForm_FormClosed;
            añadirTelefonoForm.ShowDialog();
        }

        private void AñadirTelefonoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AñadirTelefonoEmpleado añadirTelefonoForm = (AñadirTelefonoEmpleado)sender;

            // Check if a new TelefonoEmpleado was created in the AñadirTelefonoEmpleado form
            if (añadirTelefonoForm.TelefonoEmpleado != null)
            {
                telefonos.Add(añadirTelefonoForm.TelefonoEmpleado);
                llenarDGV();
            }
        }
        private void llenarDGV()
        {
            // Ensure the DataGridView has the correct number of columns
            if (dataGridView1.Columns.Count < 3)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("telefono", "Numero de telefono");
                dataGridView1.Columns["telefono"].Width = 200;
                dataGridView1.Columns.Add("tipo", "Tipo de Telefono");
                dataGridView1.Columns["tipo"].Width = 200;
            }

            // Clear the existing rows in the DataGridView
            dataGridView1.Rows.Clear();

            // Iterate through the detalles list and add each item to the DataGridView
            foreach (TelefonoEmpleado telefono in telefonos)
            {
                // Create a new row and set the values of each cell
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = telefono.telefono;
                row.Cells[1].Value = telefono.tipo;

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
                if (selectedIndex > telefonos.Count() - 1)
                {
                    MessageBox.Show("Seleccione un detalle primero!.", "Eliminar Detalle Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Get the DetalleFactura object associated with the selected row
                TelefonoEmpleado telefono = telefonos[selectedIndex];

                // Remove the DetalleFactura from the detalles list
                telefonos.Remove(telefono);

                // Refresh the DataGridView
                llenarDGV();

            }
            else
            {
                MessageBox.Show("Seleccione un telefono primero!.", "Eliminar Telefono Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
