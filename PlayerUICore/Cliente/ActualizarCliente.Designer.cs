namespace PlayerUI.Pacientes
{
    partial class ActualizarCliente
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
            button1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            btnExit = new System.Windows.Forms.Button();
            label7 = new System.Windows.Forms.Label();
            txtTel = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            txtNom = new System.Windows.Forms.TextBox();
            txtDir = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            button2 = new System.Windows.Forms.Button();
            txtCed = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button1.BackColor = System.Drawing.Color.FromArgb(235, 42, 83);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            button1.ForeColor = System.Drawing.Color.LightGray;
            button1.Location = new System.Drawing.Point(501, 463);
            button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(104, 38);
            button1.TabIndex = 54;
            button1.Text = "Actualizar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.Color.FromArgb(235, 42, 83);
            label1.Location = new System.Drawing.Point(170, 41);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(361, 25);
            label1.TabIndex = 50;
            label1.Text = "ACTUALIZAR DATOS DEL PACIENTE";
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
            btnExit.TabIndex = 48;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label7.ForeColor = System.Drawing.SystemColors.Control;
            label7.Location = new System.Drawing.Point(115, 289);
            label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(68, 17);
            label7.TabIndex = 64;
            label7.Text = "Teléfono:";
            // 
            // txtTel
            // 
            txtTel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtTel.Location = new System.Drawing.Point(240, 278);
            txtTel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtTel.MaxLength = 10;
            txtTel.Name = "txtTel";
            txtTel.Size = new System.Drawing.Size(365, 26);
            txtTel.TabIndex = 62;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label10.ForeColor = System.Drawing.SystemColors.Control;
            label10.Location = new System.Drawing.Point(114, 232);
            label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(69, 17);
            label10.TabIndex = 60;
            label10.Text = "Nombres:";
            // 
            // txtNom
            // 
            txtNom.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtNom.Location = new System.Drawing.Point(240, 222);
            txtNom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtNom.MaxLength = 30;
            txtNom.Name = "txtNom";
            txtNom.Size = new System.Drawing.Size(365, 26);
            txtNom.TabIndex = 58;
            // 
            // txtDir
            // 
            txtDir.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtDir.Location = new System.Drawing.Point(240, 334);
            txtDir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtDir.MaxLength = 30;
            txtDir.Name = "txtDir";
            txtDir.Size = new System.Drawing.Size(365, 26);
            txtDir.TabIndex = 63;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label6.ForeColor = System.Drawing.SystemColors.Control;
            label6.Location = new System.Drawing.Point(112, 344);
            label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(71, 17);
            label6.TabIndex = 65;
            label6.Text = "Dirección:";
            // 
            // button2
            // 
            button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button2.BackColor = System.Drawing.Color.FromArgb(235, 42, 83);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            button2.ForeColor = System.Drawing.Color.LightGray;
            button2.Location = new System.Drawing.Point(501, 149);
            button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(104, 38);
            button2.TabIndex = 70;
            button2.Text = "Consultar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // txtCed
            // 
            txtCed.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtCed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtCed.Location = new System.Drawing.Point(240, 97);
            txtCed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtCed.MaxLength = 10;
            txtCed.Name = "txtCed";
            txtCed.Size = new System.Drawing.Size(365, 26);
            txtCed.TabIndex = 49;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label4.ForeColor = System.Drawing.SystemColors.Control;
            label4.Location = new System.Drawing.Point(56, 108);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(138, 17);
            label4.TabIndex = 51;
            label4.Text = "Cédula de Identidad:";
            // 
            // ActualizarCliente
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(32, 30, 45);
            ClientSize = new System.Drawing.Size(700, 600);
            Controls.Add(button2);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(txtDir);
            Controls.Add(txtTel);
            Controls.Add(label10);
            Controls.Add(txtNom);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(txtCed);
            Controls.Add(btnExit);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ActualizarCliente";
            Text = "ActualizarPaciente";
            Load += ActualizarPaciente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtCed;
        private System.Windows.Forms.Label label4;
    }
}