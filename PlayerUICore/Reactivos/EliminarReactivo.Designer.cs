namespace PlayerUI.Reactivos
{
    partial class EliminarReactivo
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
            label3 = new System.Windows.Forms.Label();
            txtCantidadEntrada = new System.Windows.Forms.TextBox();
            btnActualizarInstrumento = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();
            lblInstrumento = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label3.ForeColor = System.Drawing.Color.LightGray;
            label3.Location = new System.Drawing.Point(48, 290);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(121, 17);
            label3.TabIndex = 27;
            label3.Text = "Nombre Reactivo:";
            // 
            // txtCantidadEntrada
            // 
            txtCantidadEntrada.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtCantidadEntrada.Location = new System.Drawing.Point(239, 288);
            txtCantidadEntrada.Margin = new System.Windows.Forms.Padding(2);
            txtCantidadEntrada.Name = "txtCantidadEntrada";
            txtCantidadEntrada.Size = new System.Drawing.Size(413, 23);
            txtCantidadEntrada.TabIndex = 26;
            // 
            // btnActualizarInstrumento
            // 
            btnActualizarInstrumento.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnActualizarInstrumento.BackColor = System.Drawing.Color.FromArgb(235, 42, 83);
            btnActualizarInstrumento.FlatAppearance.BorderSize = 0;
            btnActualizarInstrumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnActualizarInstrumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnActualizarInstrumento.ForeColor = System.Drawing.Color.LightGray;
            btnActualizarInstrumento.Location = new System.Drawing.Point(477, 346);
            btnActualizarInstrumento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnActualizarInstrumento.Name = "btnActualizarInstrumento";
            btnActualizarInstrumento.Size = new System.Drawing.Size(175, 46);
            btnActualizarInstrumento.TabIndex = 25;
            btnActualizarInstrumento.Text = "Eliminar";
            btnActualizarInstrumento.UseVisualStyleBackColor = false;
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
            btnExit.TabIndex = 24;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // lblInstrumento
            // 
            lblInstrumento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            lblInstrumento.AutoSize = true;
            lblInstrumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblInstrumento.ForeColor = System.Drawing.Color.FromArgb(235, 42, 83);
            lblInstrumento.Location = new System.Drawing.Point(237, 23);
            lblInstrumento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblInstrumento.Name = "lblInstrumento";
            lblInstrumento.Size = new System.Drawing.Size(226, 25);
            lblInstrumento.TabIndex = 23;
            lblInstrumento.Text = "ELIMINAR REACTIVOS";
            // 
            // EliminarReactivo
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(32, 30, 45);
            ClientSize = new System.Drawing.Size(700, 600);
            Controls.Add(label3);
            Controls.Add(txtCantidadEntrada);
            Controls.Add(btnActualizarInstrumento);
            Controls.Add(btnExit);
            Controls.Add(lblInstrumento);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "EliminarReactivo";
            Text = "EliminarReactivo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantidadEntrada;
        private System.Windows.Forms.Button btnActualizarInstrumento;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblInstrumento;
    }
}