namespace CLUB_DEPORTIVO
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pbx1 = new PictureBox();
            label1 = new Label();
            lblUsuario = new Label();
            label3 = new Label();
            txtUsuario = new TextBox();
            txtContrasena = new TextBox();
            btnIngresar = new Button();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)pbx1).BeginInit();
            SuspendLayout();
            // 
            // pbx1
            // 
            pbx1.Image = Properties.Resources.ESCUDO_CLUB;
            pbx1.Location = new Point(253, 12);
            pbx1.Name = "pbx1";
            pbx1.Size = new Size(272, 183);
            pbx1.SizeMode = PictureBoxSizeMode.Zoom;
            pbx1.TabIndex = 0;
            pbx1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(283, 208);
            label1.Name = "label1";
            label1.Size = new Size(210, 15);
            label1.TabIndex = 1;
            label1.Text = "INGRESE SU USUARIO Y CONTRASEÑA";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(219, 246);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(56, 15);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "USUARIO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(195, 283);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 3;
            label3.Text = "CONTRASEÑA";
            // 
            // txtUsuario
            // 
            txtUsuario.ForeColor = Color.DimGray;
            txtUsuario.Location = new Point(281, 238);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(244, 23);
            txtUsuario.TabIndex = 4;
            txtUsuario.Text = "USUARIO";
            txtUsuario.Enter += txtUsuario_Enter;
            txtUsuario.Leave += txtUsuario_Leave;
            // 
            // txtContrasena
            // 
            txtContrasena.ForeColor = Color.DimGray;
            txtContrasena.Location = new Point(284, 280);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(241, 23);
            txtContrasena.TabIndex = 7;
            txtContrasena.Text = "CONTRASEÑA";
            txtContrasena.Enter += txtContrasena_Enter;
            txtContrasena.Leave += txtContrasena_Leave;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.Lime;
            btnIngresar.Location = new Point(157, 339);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(172, 35);
            btnIngresar.TabIndex = 8;
            btnIngresar.Text = "INGRESAR";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Red;
            btnSalir.Location = new Point(414, 339);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(172, 35);
            btnSalir.TabIndex = 9;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(btnIngresar);
            Controls.Add(btnSalir);
            Controls.Add(txtContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(label3);
            Controls.Add(lblUsuario);
            Controls.Add(label1);
            Controls.Add(pbx1);
            Name = "frmLogin";
            Text = "ACCEDER AL SISTEMA";
            ((System.ComponentModel.ISupportInitialize)pbx1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbx1;
        private Label label1;
        private Label lblUsuario;
        private Label label3;
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private Button btnIngresar;
        private Button btnSalir;
    }
}