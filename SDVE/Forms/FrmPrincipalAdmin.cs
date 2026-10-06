using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SDVE.Services;

namespace SDVE.Forms
{
    public partial class FrmPrincipalAdmin : Form
    {
        public FrmPrincipalAdmin()
        {
            InitializeComponent();
            UiTheme.Apply(this);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();

            frmLogin.FormClosed += (s, args) => this.Close();
            frmLogin.Show();

            this.Hide();

        }

        private void btnConvocatorias_Click(object sender, EventArgs e)
        {
            AbrirFormulario(() => new FrmConvocatorias());
        }

        private void btnCandidatos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(() => new FrmCandidatos());
        }

        private void btnResultados_Click(object sender, EventArgs e)
        {
            AbrirFormulario(() => new FrmResultados());
        }

        private void btnExportacion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(() => new FrmExportacion());
        }

        private void AbrirFormulario(Func<Form> crearFormulario)
        {
            try
            {
                using Form formulario = crearFormulario();
                formulario.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo abrir el módulo. Revisa que la base sdve tenga las tablas y columnas requeridas.\n\n" + ex.Message,
                    "Error al abrir módulo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
