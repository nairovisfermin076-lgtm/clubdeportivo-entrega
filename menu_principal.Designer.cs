namespace CLUB_DEPORTIVO.Resources
{
    partial class menu_principal
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
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)pbx1).BeginInit();
            SuspendLayout();
            // 
            // pbx1
            // 
            pbx1.Image = Properties.Resources.ESCUDO_CLUB;
            pbx1.Location = new Point(266, 12);
            pbx1.Name = "pbx1";
            pbx1.Size = new Size(272, 183);
            pbx1.SizeMode = PictureBoxSizeMode.Zoom;
            pbx1.TabIndex = 1;
            pbx1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(295, 218);
            label1.Name = "label1";
            label1.Size = new Size(192, 15);
            label1.TabIndex = 2;
            label1.Text = "SELECCIONE LA ACCION DESEADA";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(128, 255, 128);
            button1.Location = new Point(285, 249);
            button1.Name = "button1";
            button1.Size = new Size(228, 34);
            button1.TabIndex = 3;
            button1.Text = "NUEVO SOCIO/NO SOCIO";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(128, 255, 128);
            button2.Location = new Point(285, 289);
            button2.Name = "button2";
            button2.Size = new Size(228, 33);
            button2.TabIndex = 4;
            button2.Text = "COBRAR CUOTA";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(128, 255, 128);
            button3.Location = new Point(285, 328);
            button3.Name = "button3";
            button3.Size = new Size(228, 32);
            button3.TabIndex = 5;
            button3.Text = "VENCIMIENTOS DEL DIA";
            button3.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Red;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(352, 366);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(99, 34);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += button4_Click;
            // 
            // menu_principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(pbx1);
            Name = "menu_principal";
            Text = "MENU PRINCIPAL";
            Load += menu_principal_Load;
            ((System.ComponentModel.ISupportInitialize)pbx1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbx1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button btnSalir;
    }
}