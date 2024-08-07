namespace PlayerUI.Instrumento
{
    partial class EliminarInstrumento
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
            this.lblInstrumento = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnActualizarInstrumento = new System.Windows.Forms.Button();
            this.txtCantidadEntrada = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblInstrumento
            // 
            this.lblInstrumento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblInstrumento.AutoSize = true;
            this.lblInstrumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstrumento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.lblInstrumento.Location = new System.Drawing.Point(216, 20);
            this.lblInstrumento.Name = "lblInstrumento";
            this.lblInstrumento.Size = new System.Drawing.Size(269, 25);
            this.lblInstrumento.TabIndex = 7;
            this.lblInstrumento.Text = "ELIMINAR INSTRUMENTOS";
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.LightGray;
            this.btnExit.Location = new System.Drawing.Point(12, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(25, 25);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnActualizarInstrumento
            // 
            this.btnActualizarInstrumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizarInstrumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.btnActualizarInstrumento.FlatAppearance.BorderSize = 0;
            this.btnActualizarInstrumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarInstrumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarInstrumento.ForeColor = System.Drawing.Color.LightGray;
            this.btnActualizarInstrumento.Location = new System.Drawing.Point(510, 311);
            this.btnActualizarInstrumento.Name = "btnActualizarInstrumento";
            this.btnActualizarInstrumento.Size = new System.Drawing.Size(150, 40);
            this.btnActualizarInstrumento.TabIndex = 15;
            this.btnActualizarInstrumento.Text = "Eliminar";
            this.btnActualizarInstrumento.UseVisualStyleBackColor = false;
            this.btnActualizarInstrumento.Click += new System.EventHandler(this.btnActualizarInstrumento_Click);
            // 
            // txtCantidadEntrada
            // 
            this.txtCantidadEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCantidadEntrada.Location = new System.Drawing.Point(205, 250);
            this.txtCantidadEntrada.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidadEntrada.Name = "txtCantidadEntrada";
            this.txtCantidadEntrada.Size = new System.Drawing.Size(455, 20);
            this.txtCantidadEntrada.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(41, 251);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Nombre Instrumento:";
            // 
            // EliminarInstrumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCantidadEntrada);
            this.Controls.Add(this.btnActualizarInstrumento);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblInstrumento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EliminarInstrumento";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblInstrumento;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnActualizarInstrumento;
        private System.Windows.Forms.TextBox txtCantidadEntrada;
        private System.Windows.Forms.Label label3;
    }
}