namespace PlayerUI.Ventas
{
    partial class GenerarVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            btnExit = new System.Windows.Forms.Button();
            btnConsultarInstrumento = new System.Windows.Forms.Button();
            lblNombreInstrumento = new System.Windows.Forms.Label();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            txtCI = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            txtTotalIVA = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtTotalNoIVA = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtIVA = new System.Windows.Forms.TextBox();
            IVA = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            txtApe = new System.Windows.Forms.TextBox();
            txtNom = new System.Windows.Forms.TextBox();
            button2 = new System.Windows.Forms.Button();
            textBox1 = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.Color.FromArgb(235, 42, 83);
            label1.Location = new System.Drawing.Point(245, 23);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(180, 25);
            label1.TabIndex = 7;
            label1.Text = "GENERAR VENTA";
            // 
            // btnExit
            // 
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(235, 42, 83);
            btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnExit.ForeColor = System.Drawing.Color.LightGray;
            btnExit.Location = new System.Drawing.Point(14, 14);
            btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(29, 29);
            btnExit.TabIndex = 14;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnConsultarInstrumento
            // 
            btnConsultarInstrumento.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnConsultarInstrumento.BackColor = System.Drawing.Color.FromArgb(235, 42, 83);
            btnConsultarInstrumento.FlatAppearance.BorderSize = 0;
            btnConsultarInstrumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnConsultarInstrumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnConsultarInstrumento.ForeColor = System.Drawing.Color.LightGray;
            btnConsultarInstrumento.Location = new System.Drawing.Point(511, 542);
            btnConsultarInstrumento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnConsultarInstrumento.Name = "btnConsultarInstrumento";
            btnConsultarInstrumento.Size = new System.Drawing.Size(138, 46);
            btnConsultarInstrumento.TabIndex = 15;
            btnConsultarInstrumento.Text = "Registrar Venta";
            btnConsultarInstrumento.UseVisualStyleBackColor = false;
            btnConsultarInstrumento.Click += btnConsultarInstrumento_Click;
            // 
            // lblNombreInstrumento
            // 
            lblNombreInstrumento.AutoSize = true;
            lblNombreInstrumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            lblNombreInstrumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblNombreInstrumento.ForeColor = System.Drawing.Color.LightGray;
            lblNombreInstrumento.Location = new System.Drawing.Point(42, 83);
            lblNombreInstrumento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblNombreInstrumento.Name = "lblNombreInstrumento";
            lblNombreInstrumento.Size = new System.Drawing.Size(192, 17);
            lblNombreInstrumento.TabIndex = 20;
            lblNombreInstrumento.Text = "Ingrese el número de cédula:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(42, 155);
            dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.Size = new System.Drawing.Size(606, 177);
            dataGridView1.TabIndex = 21;
            // 
            // txtCI
            // 
            txtCI.Location = new System.Drawing.Point(239, 77);
            txtCI.MaxLength = 10;
            txtCI.Name = "txtCI";
            txtCI.Size = new System.Drawing.Size(262, 23);
            txtCI.TabIndex = 22;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button1.BackColor = System.Drawing.Color.FromArgb(235, 42, 83);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            button1.ForeColor = System.Drawing.Color.LightGray;
            button1.Location = new System.Drawing.Point(511, 63);
            button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(137, 37);
            button1.TabIndex = 23;
            button1.Text = "Consultar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtTotalIVA
            // 
            txtTotalIVA.Location = new System.Drawing.Point(220, 446);
            txtTotalIVA.MaxLength = 10;
            txtTotalIVA.Name = "txtTotalIVA";
            txtTotalIVA.Size = new System.Drawing.Size(428, 23);
            txtTotalIVA.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.ForeColor = System.Drawing.Color.LightGray;
            label2.Location = new System.Drawing.Point(51, 452);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(154, 17);
            label2.TabIndex = 24;
            label2.Text = "Total Venta (CON IVA):";
            // 
            // txtTotalNoIVA
            // 
            txtTotalNoIVA.Location = new System.Drawing.Point(220, 350);
            txtTotalNoIVA.MaxLength = 10;
            txtTotalNoIVA.Name = "txtTotalNoIVA";
            txtTotalNoIVA.Size = new System.Drawing.Size(428, 23);
            txtTotalNoIVA.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label3.ForeColor = System.Drawing.Color.LightGray;
            label3.Location = new System.Drawing.Point(51, 356);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(146, 17);
            label3.TabIndex = 26;
            label3.Text = "Total Venta (SIN IVA):";
            // 
            // txtIVA
            // 
            txtIVA.Location = new System.Drawing.Point(220, 398);
            txtIVA.MaxLength = 10;
            txtIVA.Name = "txtIVA";
            txtIVA.Size = new System.Drawing.Size(428, 23);
            txtIVA.TabIndex = 29;
            // 
            // IVA
            // 
            IVA.AutoSize = true;
            IVA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            IVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            IVA.ForeColor = System.Drawing.Color.LightGray;
            IVA.Location = new System.Drawing.Point(51, 404);
            IVA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            IVA.Name = "IVA";
            IVA.Size = new System.Drawing.Size(88, 17);
            IVA.TabIndex = 28;
            IVA.Text = "IVA VENTA (";
            // 
            // label10
            // 
            label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            label10.AutoSize = true;
            label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label10.ForeColor = System.Drawing.SystemColors.Control;
            label10.Location = new System.Drawing.Point(42, 121);
            label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(69, 17);
            label10.TabIndex = 54;
            label10.Text = "Nombres:";
            // 
            // label9
            // 
            label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            label9.AutoSize = true;
            label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label9.ForeColor = System.Drawing.SystemColors.Control;
            label9.Location = new System.Drawing.Point(312, 121);
            label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(69, 17);
            label9.TabIndex = 55;
            label9.Text = "Apellidos:";
            // 
            // txtApe
            // 
            txtApe.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtApe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtApe.Location = new System.Drawing.Point(387, 116);
            txtApe.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtApe.MaxLength = 30;
            txtApe.Name = "txtApe";
            txtApe.Size = new System.Drawing.Size(205, 22);
            txtApe.TabIndex = 53;
            // 
            // txtNom
            // 
            txtNom.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtNom.Location = new System.Drawing.Point(117, 116);
            txtNom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtNom.MaxLength = 30;
            txtNom.Name = "txtNom";
            txtNom.Size = new System.Drawing.Size(189, 22);
            txtNom.TabIndex = 52;
            // 
            // button2
            // 
            button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button2.BackColor = System.Drawing.Color.FromArgb(235, 42, 83);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            button2.ForeColor = System.Drawing.Color.LightGray;
            button2.Location = new System.Drawing.Point(43, 542);
            button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(138, 46);
            button2.TabIndex = 56;
            button2.Text = "Limpiar Datos";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(220, 494);
            textBox1.MaxLength = 10;
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(428, 23);
            textBox1.TabIndex = 58;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label4.ForeColor = System.Drawing.Color.LightGray;
            label4.Location = new System.Drawing.Point(51, 500);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(124, 17);
            label4.TabIndex = 57;
            label4.Text = "Total A Registrar*:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label5.ForeColor = System.Drawing.Color.LightGray;
            label5.Location = new System.Drawing.Point(51, 523);
            label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(53, 13);
            label5.TabIndex = 59;
            label5.Text = "*Opcional";
            // 
            // GenerarVenta
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(32, 30, 45);
            ClientSize = new System.Drawing.Size(700, 600);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(txtApe);
            Controls.Add(txtNom);
            Controls.Add(txtIVA);
            Controls.Add(IVA);
            Controls.Add(txtTotalNoIVA);
            Controls.Add(label3);
            Controls.Add(txtTotalIVA);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(txtCI);
            Controls.Add(dataGridView1);
            Controls.Add(lblNombreInstrumento);
            Controls.Add(btnConsultarInstrumento);
            Controls.Add(btnExit);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "GenerarVenta";
            Text = "Form3";
            Load += RegistrarVenta_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnConsultarInstrumento;
        private System.Windows.Forms.Label lblNombreInstrumento;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCI;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTotalIVA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalNoIVA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Label IVA;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtApe;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}