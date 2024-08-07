namespace PlayerUI
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            txtUsuario = new System.Windows.Forms.TextBox();
            button5 = new System.Windows.Forms.Button();
            button9 = new System.Windows.Forms.Button();
            txtContrasena = new System.Windows.Forms.TextBox();
            pictureBox9 = new System.Windows.Forms.PictureBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            lblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtUsuario.Location = new System.Drawing.Point(226, 279);
            txtUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtUsuario.MaxLength = 15;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new System.Drawing.Size(408, 26);
            txtUsuario.TabIndex = 1;
            txtUsuario.TextChanged += txtUsuario_TextChanged;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(235, 42, 83);
            button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            button5.ForeColor = System.Drawing.Color.LightGray;
            button5.Location = new System.Drawing.Point(0, 0);
            button5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(29, 29);
            button5.TabIndex = 7;
            button5.Text = "X";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button9
            // 
            button9.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button9.BackColor = System.Drawing.Color.FromArgb(235, 42, 83);
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            button9.ForeColor = System.Drawing.Color.LightGray;
            button9.Location = new System.Drawing.Point(312, 408);
            button9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button9.Name = "button9";
            button9.Size = new System.Drawing.Size(175, 46);
            button9.TabIndex = 16;
            button9.Text = "Login";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // txtContrasena
            // 
            txtContrasena.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtContrasena.Location = new System.Drawing.Point(226, 344);
            txtContrasena.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtContrasena.MaxLength = 15;
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new System.Drawing.Size(408, 26);
            txtContrasena.TabIndex = 17;
            txtContrasena.TextChanged += txtContrasena_TextChanged;
            // 
            // pictureBox9
            // 
            pictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBox9.Image = (System.Drawing.Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.InitialImage = (System.Drawing.Image)resources.GetObject("pictureBox9.InitialImage");
            pictureBox9.Location = new System.Drawing.Point(222, 0);
            pictureBox9.Margin = new System.Windows.Forms.Padding(2);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new System.Drawing.Size(355, 242);
            pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            pictureBox9.TabIndex = 18;
            pictureBox9.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.ForeColor = System.Drawing.Color.LightGray;
            label2.Location = new System.Drawing.Point(121, 284);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(57, 17);
            label2.TabIndex = 21;
            label2.Text = "Usuario";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.Color.LightGray;
            label1.Location = new System.Drawing.Point(121, 348);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(81, 17);
            label1.TabIndex = 22;
            label1.Text = "Contraseña";
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = System.Drawing.Color.FromArgb(235, 42, 83);
            lblError.Location = new System.Drawing.Point(223, 382);
            lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblError.Name = "lblError";
            lblError.Size = new System.Drawing.Size(32, 15);
            lblError.TabIndex = 23;
            lblError.Text = "Error";
            lblError.Visible = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(32, 30, 45);
            ClientSize = new System.Drawing.Size(798, 497);
            Controls.Add(lblError);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txtContrasena);
            Controls.Add(button9);
            Controls.Add(button5);
            Controls.Add(txtUsuario);
            Controls.Add(pictureBox9);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Login";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "9";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblError;
    }
}