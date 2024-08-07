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
    public partial class ConsultarPedido : Form
    {
        BindingList<Examen> examenes = null;
        Pedido pedido = null;
        List<TipoExamen> tipoExamens = new List<TipoExamen>();

        public ConsultarPedido()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            TipoExamenModel tipoExamen = new TipoExamenModel();
            tipoExamens = tipoExamen.ObtenerTiposExamen();
            comboBox1.DataSource = tipoExamens;
            comboBox1.DisplayMember = "nombreTipoExamen";
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

        private void ConsultarPedido_Load(object sender, EventArgs e)
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
            PedidoModel pedidoModel = new PedidoModel();
            if (!pedidoModel.Check(txtCI.Text))
            {
                // Realizar acciones si el formato es válido
                MessageBox.Show("¡No se ha encontrado un pedido registrado para este paciente!", "Consultar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                pedido = pedidoModel.ObtenerPedido(txtCI.Text);
                ExamenModel examenMode = new ExamenModel();
                examenes = examenMode.ObtenerExamenesPedido(pedido.Id);
                llenarDGV();
            }
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
                dataGridView1.Columns[3].HeaderText = "Estado";
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].HeaderText = "Tipo de Examen";
                dataGridView1.Columns[4].Width = 400;
                dataGridView1.Columns[5].HeaderText = "Costo";
                dataGridView1.Columns[5].Width = 150;
                dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pedido == null)
            {
                MessageBox.Show("¡Primero debe consultar un pedido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string userInput = comboBox1.Text;

            // Verificar si el texto ingresado coincide con alguna de las propiedades de los objetos en la lista
            bool isValid = tipoExamens.Any(item => item.nombreTipoExamen == userInput);

            if (!isValid)
            {
                MessageBox.Show("Por favor, ingrese un valor válido de tipo de examen.");
                return;
            }
            TipoExamen tipoExamen = (TipoExamen)comboBox1.SelectedItem;
            foreach (Examen ex in examenes)
            {
                if (ex.nombreTipoExamen == tipoExamen.nombreTipoExamen)
                {
                    MessageBox.Show("¡Un pedido puede contener un tipo de examen una sola vez!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            ExamenModel model = new ExamenModel();
            model.registrarExamenPedido(pedido, tipoExamen);
            ExamenModel examenMode = new ExamenModel();
            examenes = examenMode.ObtenerExamenesPedido(pedido.Id);
            llenarDGV();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pedido == null)
            {
                // Realizar acciones si el formato es válido
                MessageBox.Show("Primero debe consultar un pedido para eliminar tipos de examen!", "Eliminar Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    if(examenes.Count == 1)
                    {
                        MessageBox.Show("¡El pedido debe tener al menos un tipo de examen!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Obtener la primera fila seleccionada (suponiendo que solo permites la selección de una sola fila)
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                    // Obtener el objeto de la clase correspondiente a la fila seleccionada
                    Examen examen = null;
                    examen = filaSeleccionada.DataBoundItem as Examen;
                    ExamenModel examenModel = new ExamenModel();
                    examenModel.EliminarExamenID(examen.Id);
                    examenes.Remove(examen);
                }
                else
                {
                    MessageBox.Show("Seleccione una fila antes de intentar eliminar un tipo de examen.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
