using DataAccess.Entities;
using Domain;
using PlayerUICore.Usuario;
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

namespace PlayerUI.Pedidos
{
    public partial class RegistrarPedido : Form
    {
        Cliente Cliente = null;
        Pedido pedido = null;
        BindingList<TipoExamen> tiposExamenPedido = null;
        List<TipoExamen> tipoExamens = new List<TipoExamen>();
        public RegistrarPedido()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            txtCI.KeyPress += OnKeyPressNum;
            txtTel.KeyPress += OnKeyPressNum;
            txtNom.KeyPress += OnKeyPress;
            txtApe.KeyPress += OnKeyPress;
            textBox1.Visible = false;
            TipoExamenModel tipoExamen = new TipoExamenModel();
            
            tipoExamens = tipoExamen.ObtenerTiposExamen();

            if (tipoExamens.Count == 0)
            {
                // Mostrar un mensaje de error y cancelar la operación
                MessageBox.Show("Para registrar pedidos debe registrar tipos de examen!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
                return;
            }
            else
            {
                comboBox1.DataSource = tipoExamens;
            }
            comboBox1.DisplayMember = "nombreTipoExamen";
            comboBox1.SelectedIndex = 0;
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


        private bool ValidarFormatoNombre(System.Windows.Forms.TextBox textBox)
        {
            // Verificar si el texto está en el formato "Nombre Apellido"
            string[] partes = textBox.Text.Split(' ');
            if (partes.Length != 2)
            {
                return false;
            }
            else
            {
                bool formatoCorrecto = partes.All(part =>
                    !string.IsNullOrWhiteSpace(part) &&
                    part.All(char.IsLetter) &&
                    char.IsUpper(part[0])); // Verificar si la primera letra es mayúscula
                if (!formatoCorrecto)
                {
                    return false;
                }
            }
            return true;
        }

        private bool ValidarFormatoApe(System.Windows.Forms.TextBox textBox)
        {
            // Verificar si el texto está en el formato "Nombre Apellido1 Apellido2 Apellido3"
            string[] partes = textBox.Text.Split(' ');
            if (partes.Length < 2 || partes.Length > 4)
            {
                return false;
            }
            else
            {
                bool formatoCorrecto = partes.All(part =>
                    !string.IsNullOrWhiteSpace(part) &&
                    part.All(char.IsLetter) &&
                    char.IsUpper(part[0])); // Verificar si la primera letra es mayúscula
                if (!formatoCorrecto)
                {
                    return false;
                }
            }
            return true;
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

        public bool ValidarCorreo(string correo)
        {
            // Expresión regular para validar la estructura básica de un correo electrónico
            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Crear objeto Regex con el patrón
            Regex regex = new Regex(patron);

            // Verificar si la cadena coincide con el patrón
            return regex.IsMatch(correo);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(Cliente==null)
            {
                MessageBox.Show("Primero debe registrar la información del cliente para registrar un pedido!", "Registrar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtDoc.Text != "" && !ValidarFormatoNombre(txtDoc))
            {
                MessageBox.Show("El formato del nombre del doctor es inválido", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tiposExamenPedido == null || tiposExamenPedido.Count ==0)
            {
                MessageBox.Show("¡El pedido debe tener al menos un tipo de examen!", "Registro de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("¿Está seguro?", "Registro de Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                PedidoModel pedidoModel = new PedidoModel();
                pedidoModel.RegistrarPedido(txtCI.Text);
                pedido = pedidoModel.ObtenerPedido(txtCI.Text);
                ExamenModel examenModel = new ExamenModel();
                examenModel.registrarExamenesPedido(pedido, tiposExamenPedido);
                MessageBox.Show("¡El pedido se ha registrado correctamente!", "Registro de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Reset();
        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void RegistrarPedido_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
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
            if (temp.Check(cedula))
            {
                // Realizar acciones si el formato es válido
                MessageBox.Show("Ya existe un pedido pendiente para este Cliente!", "Registrar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Cliente = tp.obtenerClienteCI(txtCI.Text);
            if (Cliente != null)
            {
                txtCI.ReadOnly = true;
                txtNom.ReadOnly = true;
                txtApe.ReadOnly = true;
                txtCorr.ReadOnly = true;
                txtTel.ReadOnly = true;
                txtDir.ReadOnly = true;
                // Desactiva la interacción del usuario con el DateTimePicker
                dateTimePicker1.Enabled = false;
                // Configura el TextBox encima del DateTimePicker, poner despues de obtener
                textBox1.ReadOnly = true;
                textBox1.BackColor = SystemColors.Control; // Cambia el color de fondo si es necesario
                txtNom.Text = Cliente.nombresCliente;
                txtTel.Text = Cliente.telefonoCliente;
                textBox1.Visible = true;
                pedido = new Pedido(txtCI.Text);
                pedido.CIPedido = txtCI.Text;
                comboBox1.Enabled = true;
            }
            else
            {
                // Realizar acciones si el formato es válido
                MessageBox.Show("Cliente no encontrado!.", "Registrar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Cliente != null)
            {
                MessageBox.Show("Un Cliente ya ha sido consultado, no puede registrar uno!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DateTime fechaSeleccionada = dateTimePicker1.Value.Date; // Obtener solo la parte de la fecha
                string fechaFormateada = fechaSeleccionada.ToString("yyyy-MM-dd"); // Formatear la fecha

                //Validar cedula
                string cedula = txtCI.Text;
                if (!ValidarCedulaEcuatoriana(cedula))
                {
                    // Realizar acciones si el formato es válido
                    MessageBox.Show("La cédula no es válida.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Validar nombres
                if (!ValidarFormatoNombre(txtNom))
                {
                    // Realizar acciones si el formato es válido
                    MessageBox.Show("El formato de los nombres no es válido.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Validar apellido
                if (!ValidarFormatoApe(txtApe))
                {
                    // Realizar acciones si el formato es válido
                    MessageBox.Show("El formato de los apellidos no es válido.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }
                if (txtTel.Text.Length <= 8)
                {
                    // Realizar acciones si el formato es válido
                    MessageBox.Show("El formato del teléfono no es válido.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Validar correo
                string correo = txtCorr.Text;
                if (!ValidarCorreo(correo))
                {
                    // Realizar acciones si el formato es válido
                    MessageBox.Show("El formato del correo no es válido.", "Formato no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }

                ClienteModel user = new ClienteModel();
                var existe = user.Check(txtCI.Text);
                if (existe == true)
                {
                    MessageBox.Show("Un Cliente con esta cédula ya está registrado.", "Registro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("¿Está seguro?", "Registro de Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ClienteModel model = new ClienteModel();
                    var validRegister = model.registrarCliente(cedula, txtNom.Text, txtTel.Text, txtDir.Text);
                    if (validRegister)
                    {
                        MessageBox.Show("Cliente registrado con éxito.", "Registro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cliente = model.obtenerClienteCI(txtCI.Text);
                    }
                    else
                    {
                        MessageBox.Show("Error en el registro de Cliente.", "Registro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                // Desactiva la interacción del usuario con el DateTimePicker
                dateTimePicker1.Enabled = false;
                // Configura el TextBox encima del DateTimePicker, poner despues de obtener
                textBox1.ReadOnly = true;
                textBox1.BackColor = SystemColors.Control; // Cambia el color de fondo si es necesario
                txtNom.ReadOnly = true;
                txtApe.ReadOnly = true;
                txtCorr.ReadOnly = true;
                txtTel.ReadOnly = true;
                txtDir.ReadOnly = true;
                txtCI.ReadOnly = true;
                comboBox1.Enabled = true;
                pedido = new Pedido(txtCI.Text);
            }

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {

            dateTimePicker1.Enabled = true;
            dateTimePicker1.Value = DateTime.Now;
            Cliente = null;
            tiposExamenPedido = null;
            dgvTiposExamen.Enabled = false;
            textBox1.Visible = false;
            txtCI.Text = "";
            txtNom.Text = "";
            txtApe.Text = "";
            txtCorr.Text = "";
            txtTel.Text = "";
            txtDir.Text = "";
            txtNom.ReadOnly = false;
            txtApe.ReadOnly = false;
            txtCorr.ReadOnly = false;
            txtTel.ReadOnly = false;
            txtDir.ReadOnly = false;
            txtCI.ReadOnly = false;
            comboBox1.Enabled = false;
            txtDoc.Text = "";
            llenarDGV();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pedido == null)
            {
                // Realizar acciones si el formato es válido
                MessageBox.Show("Primero debe registrar la información del cliente para añadir tipos de examen!", "Registrar pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (tiposExamenPedido == null)
                {
                    tiposExamenPedido = new BindingList<TipoExamen>();
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
                if (tiposExamenPedido.Contains(tipoExamen))
                {
                    MessageBox.Show("¡Un pedido puede contener un tipo de examen una sola vez!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                tiposExamenPedido.Add(tipoExamen);
                llenarDGV(); // Llenar el DataGridView con los datos actualizados
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pedido == null)
            {
                // Realizar acciones si el formato es válido
                MessageBox.Show("Primero debe registrar un pedido para eliminar tipos de examen!", "Registrar pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (dgvTiposExamen.SelectedRows.Count > 0)
                {
                    // Obtener la primera fila seleccionada (suponiendo que solo permites la selección de una sola fila)
                    DataGridViewRow filaSeleccionada = dgvTiposExamen.SelectedRows[0];

                    // Obtener el objeto de la clase correspondiente a la fila seleccionada
                    TipoExamen tipoExamen = null;
                    tipoExamen = filaSeleccionada.DataBoundItem as TipoExamen;
                    tiposExamenPedido.Remove(tipoExamen);
                }
                else
                {
                    MessageBox.Show("Seleccione una fila antes de intentar eliminar un tipo de examen.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void llenarDGV()
        {
            dgvTiposExamen.DataSource = tiposExamenPedido;
            if (tiposExamenPedido!= null) {
                dgvTiposExamen.Columns[0].HeaderText = "ID";
                dgvTiposExamen.Columns[0].Width = 50;
                dgvTiposExamen.Columns[1].HeaderText = "Tipo de Examen";
                dgvTiposExamen.Columns[1].Width = 450;
                dgvTiposExamen.Columns[2].HeaderText = "Costo";
                dgvTiposExamen.Columns[2].Width = 150;
                dgvTiposExamen.Columns[2].DefaultCellStyle.Format = "N2";
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
