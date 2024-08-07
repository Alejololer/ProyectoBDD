namespace PlayerUI
{
    partial class ConsultarInstrumento
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnConsultarInstrumento = new System.Windows.Forms.Button();
            this.txtNombreInstrumento = new System.Windows.Forms.TextBox();
            this.lblNombreInstrumento = new System.Windows.Forms.Label();
            this.dgvConsultarInstrumentos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultarInstrumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.label1.Location = new System.Drawing.Point(207, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "CONSULTAR INTRUMENTOS";
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
            // btnConsultarInstrumento
            // 
            this.btnConsultarInstrumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultarInstrumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.btnConsultarInstrumento.FlatAppearance.BorderSize = 0;
            this.btnConsultarInstrumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultarInstrumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultarInstrumento.ForeColor = System.Drawing.Color.LightGray;
            this.btnConsultarInstrumento.Location = new System.Drawing.Point(504, 522);
            this.btnConsultarInstrumento.Name = "btnConsultarInstrumento";
            this.btnConsultarInstrumento.Size = new System.Drawing.Size(150, 40);
            this.btnConsultarInstrumento.TabIndex = 15;
            this.btnConsultarInstrumento.Text = "Consultar";
            this.btnConsultarInstrumento.UseVisualStyleBackColor = false;
            this.btnConsultarInstrumento.Click += new System.EventHandler(this.btnConsultarInstrumento_Click);
            // 
            // txtNombreInstrumento
            // 
            this.txtNombreInstrumento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreInstrumento.Location = new System.Drawing.Point(200, 67);
            this.txtNombreInstrumento.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreInstrumento.Name = "txtNombreInstrumento";
            this.txtNombreInstrumento.Size = new System.Drawing.Size(455, 20);
            this.txtNombreInstrumento.TabIndex = 19;
            // 
            // lblNombreInstrumento
            // 
            this.lblNombreInstrumento.AutoSize = true;
            this.lblNombreInstrumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNombreInstrumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreInstrumento.ForeColor = System.Drawing.Color.LightGray;
            this.lblNombreInstrumento.Location = new System.Drawing.Point(36, 68);
            this.lblNombreInstrumento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreInstrumento.Name = "lblNombreInstrumento";
            this.lblNombreInstrumento.Size = new System.Drawing.Size(136, 17);
            this.lblNombreInstrumento.TabIndex = 20;
            this.lblNombreInstrumento.Text = "Nombre Instrumento";
            // 
            // dgvConsultarInstrumentos
            // 
            this.dgvConsultarInstrumentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConsultarInstrumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultarInstrumentos.Location = new System.Drawing.Point(39, 119);
            this.dgvConsultarInstrumentos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvConsultarInstrumentos.Name = "dgvConsultarInstrumentos";
            this.dgvConsultarInstrumentos.RowHeadersWidth = 51;
            this.dgvConsultarInstrumentos.RowTemplate.Height = 24;
            this.dgvConsultarInstrumentos.Size = new System.Drawing.Size(614, 380);
            this.dgvConsultarInstrumentos.TabIndex = 21;
            this.dgvConsultarInstrumentos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultarInstrumentos_CellContentClick);
            // 
            // ConsultarInstrumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.Add(this.dgvConsultarInstrumentos);
            this.Controls.Add(this.lblNombreInstrumento);
            this.Controls.Add(this.txtNombreInstrumento);
            this.Controls.Add(this.btnConsultarInstrumento);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConsultarInstrumento";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultarInstrumentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnConsultarInstrumento;
        private System.Windows.Forms.TextBox txtNombreInstrumento;
        private System.Windows.Forms.Label lblNombreInstrumento;
        private System.Windows.Forms.DataGridView dgvConsultarInstrumentos;
    }
}