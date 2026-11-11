using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CLUB_DEPORTIVO.Resources
{
    public partial class menu_principal : Form
    {
        public menu_principal()
        {
            InitializeComponent();
        }

        private void menu_principal_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de alta de socios
            var alta = new CLUB_DEPORTIVO.frmAltaSocios();
            alta.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //cierra el formulario  
            this.Close();
        }
    }
}
