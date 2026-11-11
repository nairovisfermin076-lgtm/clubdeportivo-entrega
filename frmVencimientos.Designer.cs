namespace CLUB_DEPORTIVO
{
    partial class frmVencimientos
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
            btnConsultar = new Button();
            dateTimePicker1 = new DateTimePicker();
            dtgVencimientos = new DataGridView();
            CARNET = new DataGridViewTextBoxColumn();
            NOMBRE = new DataGridViewTextBoxColumn();
            APELLIDO = new DataGridViewTextBoxColumn();
            btnImprimir = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)pbx1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgVencimientos).BeginInit();
            SuspendLayout();
            // 
            // pbx1
            // 
            pbx1.Image = Properties.Resources.ESCUDO_CLUB;
            pbx1.Location = new Point(272, 29);
            pbx1.Name = "pbx1";
            pbx1.Size = new Size(246, 157);
            pbx1.SizeMode = PictureBoxSizeMode.Zoom;
            pbx1.TabIndex = 3;
            pbx1.TabStop = false;
            // 
            // btnConsultar
            // 
            btnConsultar.BackColor = Color.FromArgb(128, 255, 128);
            btnConsultar.Location = new Point(244, 204);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(143, 33);
            btnConsultar.TabIndex = 4;
            btnConsultar.Text = "CONSULTAR FECHA";
            btnConsultar.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(444, 214);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(128, 23);
            dateTimePicker1.TabIndex = 5;
            // 
            // dtgVencimientos
            // 
            dtgVencimientos.AllowUserToAddRows = false;
            dtgVencimientos.AllowUserToDeleteRows = false;
            dtgVencimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgVencimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgVencimientos.Columns.AddRange(new DataGridViewColumn[] { CARNET, NOMBRE, APELLIDO });
            dtgVencimientos.Location = new Point(229, 264);
            dtgVencimientos.Name = "dtgVencimientos";
            dtgVencimientos.ReadOnly = true;
            dtgVencimientos.Size = new Size(343, 65);
            dtgVencimientos.TabIndex = 6;
            // 
            // CARNET
            // 
            CARNET.HeaderText = "NRO CARNET";
            CARNET.Name = "CARNET";
            CARNET.ReadOnly = true;
            // 
            // NOMBRE
            // 
            NOMBRE.HeaderText = "NOMBRE";
            NOMBRE.Name = "NOMBRE";
            NOMBRE.ReadOnly = true;
            // 
            // APELLIDO
            // 
            APELLIDO.HeaderText = "APELLIDO";
            APELLIDO.Name = "APELLIDO";
            APELLIDO.ReadOnly = true;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.FromArgb(128, 255, 128);
            btnImprimir.Location = new Point(244, 364);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(130, 33);
            btnImprimir.TabIndex = 7;
            btnImprimir.Text = "IMPRIMIR";
            btnImprimir.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.Location = new Point(444, 364);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(130, 33);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // frmVencimientos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnImprimir);
            Controls.Add(dtgVencimientos);
            Controls.Add(dateTimePicker1);
            Controls.Add(btnConsultar);
            Controls.Add(pbx1);
            Name = "frmVencimientos";
            Text = "VENCIMIENTOS DEL DIA";
            ((System.ComponentModel.ISupportInitialize)pbx1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgVencimientos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbx1;
        private Button btnConsultar;
        private DateTimePicker dateTimePicker1;
        private DataGridView dtgVencimientos;
        private DataGridViewTextBoxColumn CARNET;
        private DataGridViewTextBoxColumn NOMBRE;
        private DataGridViewTextBoxColumn APELLIDO;
        private Button btnImprimir;
        private Button btnCancelar;
    }
}