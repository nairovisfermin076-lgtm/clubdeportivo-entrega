using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CLUB_DEPORTIVO
{
    public partial class frmAltaSocios : Form
    {
        public frmAltaSocios()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Limpiar campos y cerrar el formulario de alta para volver al menú principal
            ClearForm();
            this.Close();
        }

        private void ClearForm()
        {
            try
            {
                // Textboxes 
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtDocumento.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                txtMail.Text = string.Empty;

                // ComboBox
                if (cmbTipo.Items.Count > 0)
                    cmbTipo.SelectedIndex = -1;

                // Radio buttons
                radioButton1.Checked = false;
                radioButton2.Checked = false;

                // Checkboxes
                chkAptoMedico.Checked = false;
                chkFichaPersonal.Checked = false;
            }
            catch
            {
                // No lanzar excepciones desde la limpieza; solo intentar continuar
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Limpiar campos al pulsar LIMPIAR
            ClearForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validaciones antes de guardar
            var errors = new List<string>();

            // Campos de texto obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) errors.Add("Nombre");
            if (string.IsNullOrWhiteSpace(txtApellido.Text)) errors.Add("Apellido");
            if (string.IsNullOrWhiteSpace(txtDocumento.Text)) errors.Add("Documento");
            if (string.IsNullOrWhiteSpace(txtTelefono.Text)) errors.Add("Teléfono");
            if (string.IsNullOrWhiteSpace(txtMail.Text)) errors.Add("Mail");

            // Al menos un radio seleccionado
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                errors.Add("Tipo (Socio/No Socio)");
            }

            // Checkboxes deben ser true
            if (!chkAptoMedico.Checked) errors.Add("Apto Médico");
            if (!chkFichaPersonal.Checked) errors.Add("Ficha Personal");

            if (errors.Count > 0)
            {
                var msg = "Faltan completar los siguientes campos:\n- " + string.Join("\n- ", errors);
                MessageBox.Show(msg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si pasa validación, por ahora notificamos y dejamos la lógica de guardado futura
            MessageBox.Show("Datos válidos. Guardado (simulado).", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
