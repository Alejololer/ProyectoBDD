namespace PlayerUICore.Parametros
{
    partial class ParámetrosTipoExamen
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
            label4 = new System.Windows.Forms.Label();
            btnExit = new System.Windows.Forms.Button();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            txtUn = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            txtvalMax = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            txtValMin = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            txtNomPar = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            dgvTipoExamen = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTipoExamen).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label4.ForeColor = System.Drawing.Color.FromArgb(235, 42, 83);
            label4.Location = new System.Drawing.Point(166, 37);
            label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(369, 25);
            label4.TabIndex = 52;
            label4.Text = "PARÁMETROS DEL TIPO DE EXAMEN";
            // 
            // btnExit
            // 
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(235, 42, 83);
            btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnExit.ForeColor = System.Drawing.Color.LightGray;
            btnExit.Location = new System.Drawing.Point(13, 12);
            btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(29, 29);
            btnExit.TabIndex = 51;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label9.ForeColor = System.Drawing.Color.FromArgb(235, 42, 83);
            label9.Location = new System.Drawing.Point(42, 273);
            label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(357, 17);
            label9.TabIndex = 69;
            label9.Text = "El valor mínimo, máximo y las unidades son opcionales*";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label8.ForeColor = System.Drawing.Color.LightGray;
            label8.Location = new System.Drawing.Point(42, 233);
            label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(170, 17);
            label8.TabIndex = 68;
            label8.Text = "Unidades del Parámetro*:";
            // 
            // txtUn
            // 
            txtUn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtUn.Location = new System.Drawing.Point(278, 227);
            txtUn.Margin = new System.Windows.Forms.Padding(2);
            txtUn.MaxLength = 30;
            txtUn.Name = "txtUn";
            txtUn.Size = new System.Drawing.Size(382, 23);
            txtUn.TabIndex = 67;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label7.ForeColor = System.Drawing.Color.LightGray;
            label7.Location = new System.Drawing.Point(42, 190);
            label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(219, 17);
            label7.TabIndex = 66;
            label7.Text = "Valor máximo del Rango Normal*:";
            // 
            // txtvalMax
            // 
            txtvalMax.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtvalMax.Location = new System.Drawing.Point(278, 184);
            txtvalMax.Margin = new System.Windows.Forms.Padding(2);
            txtvalMax.MaxLength = 30;
            txtvalMax.Name = "txtvalMax";
            txtvalMax.Size = new System.Drawing.Size(382, 23);
            txtvalMax.TabIndex = 65;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label6.ForeColor = System.Drawing.Color.LightGray;
            label6.Location = new System.Drawing.Point(42, 147);
            label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(216, 17);
            label6.TabIndex = 64;
            label6.Text = "Valor mínimo del Rango Normal*:";
            // 
            // txtValMin
            // 
            txtValMin.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtValMin.Location = new System.Drawing.Point(278, 141);
            txtValMin.Margin = new System.Windows.Forms.Padding(2);
            txtValMin.MaxLength = 30;
            txtValMin.Name = "txtValMin";
            txtValMin.Size = new System.Drawing.Size(382, 23);
            txtValMin.TabIndex = 63;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label5.ForeColor = System.Drawing.Color.LightGray;
            label5.Location = new System.Drawing.Point(42, 102);
            label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(155, 17);
            label5.TabIndex = 62;
            label5.Text = "Nombre del Parámetro:";
            // 
            // txtNomPar
            // 
            txtNomPar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtNomPar.Location = new System.Drawing.Point(278, 98);
            txtNomPar.Margin = new System.Windows.Forms.Padding(2);
            txtNomPar.MaxLength = 30;
            txtNomPar.Name = "txtNomPar";
            txtNomPar.Size = new System.Drawing.Size(382, 23);
            txtNomPar.TabIndex = 61;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button1.BackColor = System.Drawing.Color.FromArgb(235, 42, 83);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            button1.ForeColor = System.Drawing.Color.LightGray;
            button1.Location = new System.Drawing.Point(485, 528);
            button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(175, 46);
            button1.TabIndex = 60;
            button1.Text = "Añadir Parámetro";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dgvTipoExamen
            // 
            dgvTipoExamen.AllowUserToAddRows = false;
            dgvTipoExamen.AllowUserToDeleteRows = false;
            dgvTipoExamen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvTipoExamen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTipoExamen.Location = new System.Drawing.Point(42, 306);
            dgvTipoExamen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgvTipoExamen.Name = "dgvTipoExamen";
            dgvTipoExamen.ReadOnly = true;
            dgvTipoExamen.Size = new System.Drawing.Size(618, 194);
            dgvTipoExamen.TabIndex = 70;
            // 
            // ParámetrosTipoExamen
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(32, 30, 45);
            ClientSize = new System.Drawing.Size(700, 600);
            Controls.Add(dgvTipoExamen);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(txtUn);
            Controls.Add(label7);
            Controls.Add(txtvalMax);
            Controls.Add(label6);
            Controls.Add(txtValMin);
            Controls.Add(label5);
            Controls.Add(txtNomPar);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(btnExit);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ParámetrosTipoExamen";
            Text = "ParámetrosTipoExamen";
            Load += ParámetrosTipoExamen_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTipoExamen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtvalMax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtValMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNomPar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvTipoExamen;
    }
}