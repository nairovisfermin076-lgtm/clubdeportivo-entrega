namespace CLUB_DEPORTIVO
{
    partial class frmcobroCuota
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
            pbx1 = new PictureBox();
            lblDni = new Label();
            txtDni = new TextBox();
            btnBuscar = new Button();
            lblNombre = new Label();
            lblApellido = new Label();
            lblTipo = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtTipo = new TextBox();
            txtMonto = new TextBox();
            label1 = new Label();
            lblFechaDePago = new Label();
            lblFechaVencimiento = new Label();
            dtpFechaPago = new DateTimePicker();
            dtpFechaVencimiento = new DateTimePicker();
            btnCobrar = new Button();
            btnCancelar = new Button();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)pbx1).BeginInit();
            SuspendLayout();
            // 
            // pbx1
            // 
            pbx1.Image = Properties.Resources.ESCUDO_CLUB;
            pbx1.Location = new Point(278, 27);
            pbx1.Name = "pbx1";
            pbx1.Size = new Size(246, 157);
            pbx1.SizeMode = PictureBoxSizeMode.Zoom;
            pbx1.TabIndex = 2;
            pbx1.TabStop = false;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(165, 198);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(90, 15);
            lblDni.TabIndex = 3;
            lblDni.Text = "INGRESE EL DNI";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(261, 194);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(156, 23);
            txtDni.TabIndex = 4;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(128, 255, 128);
            btnBuscar.Location = new Point(444, 194);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(124, 23);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "BUSCAR";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(140, 245);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(56, 15);
            lblNombre.TabIndex = 6;
            lblNombre.Text = "NOMBRE";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(336, 245);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(60, 15);
            lblApellido.TabIndex = 7;
            lblApellido.Text = "APELLIDO";
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(536, 246);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(32, 15);
            lblTipo.TabIndex = 8;
            lblTipo.Text = "TIPO";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(202, 238);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 9;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(402, 237);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 10;
            // 
            // txtTipo
            // 
            txtTipo.Location = new Point(574, 237);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(100, 23);
            txtTipo.TabIndex = 11;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(201, 287);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(100, 23);
            txtMonto.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 290);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 13;
            label1.Text = "MONTO A ABONAR";
            // 
            // lblFechaDePago
            // 
            lblFechaDePago.AutoSize = true;
            lblFechaDePago.Location = new Point(333, 293);
            lblFechaDePago.Name = "lblFechaDePago";
            lblFechaDePago.Size = new Size(95, 15);
            lblFechaDePago.TabIndex = 14;
            lblFechaDePago.Text = "FECHA DE PAGO";
            // 
            // lblFechaVencimiento
            // 
            lblFechaVencimiento.AutoSize = true;
            lblFechaVencimiento.Location = new Point(536, 293);
            lblFechaVencimiento.Name = "lblFechaVencimiento";
            lblFechaVencimiento.Size = new Size(83, 15);
            lblFechaVencimiento.TabIndex = 15;
            lblFechaVencimiento.Text = "VENCIMIENTO";
            // 
            // dtpFechaPago
            // 
            dtpFechaPago.Format = DateTimePickerFormat.Short;
            dtpFechaPago.Location = new Point(434, 285);
            dtpFechaPago.Name = "dtpFechaPago";
            dtpFechaPago.Size = new Size(87, 23);
            dtpFechaPago.TabIndex = 16;
            // 
            // dtpFechaVencimiento
            // 
            dtpFechaVencimiento.Format = DateTimePickerFormat.Custom;
            dtpFechaVencimiento.Location = new Point(625, 285);
            dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            dtpFechaVencimiento.Size = new Size(118, 23);
            dtpFechaVencimiento.TabIndex = 17;
            // 
            // btnCobrar
            // 
            btnCobrar.BackColor = Color.FromArgb(128, 255, 128);
            btnCobrar.Location = new Point(125, 356);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(130, 40);
            btnCobrar.TabIndex = 18;
            btnCobrar.Text = "COBRAR";
            btnCobrar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.Location = new Point(561, 356);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(113, 40);
            btnCancelar.TabIndex = 19;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Yellow;
            btnLimpiar.Location = new Point(346, 356);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(130, 40);
            btnLimpiar.TabIndex = 20;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // frmcobroCuota
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLimpiar);
            Controls.Add(btnCancelar);
            Controls.Add(btnCobrar);
            Controls.Add(dtpFechaVencimiento);
            Controls.Add(dtpFechaPago);
            Controls.Add(lblFechaVencimiento);
            Controls.Add(lblFechaDePago);
            Controls.Add(label1);
            Controls.Add(txtMonto);
            Controls.Add(txtTipo);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblTipo);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(btnBuscar);
            Controls.Add(txtDni);
            Controls.Add(lblDni);
            Controls.Add(pbx1);
            Name = "frmcobroCuota";
            Text = "COBRO DE CUOTAS";
            ((System.ComponentModel.ISupportInitialize)pbx1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbx1;
        private Label lblDni;
        private TextBox txtDni;
        private Button btnBuscar;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblTipo;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtTipo;
        private TextBox txtMonto;
        private Label label1;
        private Label lblFechaDePago;
        private Label lblFechaVencimiento;
        private DateTimePicker dtpFechaPago;
        private DateTimePicker dtpFechaVencimiento;
        private Button btnCobrar;
        private Button btnCancelar;
        private Button btnLimpiar;
    }
}