using SDVE.Forms;
using SDVE.Models;
using SDVE.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SDVE
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            SDVE.Forms.UiTheme.Apply(this);
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string matricula = txtMatricula.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(matricula))
            {
                MessageBox.Show(
                    "Debes ingresar tu matrícula.",
                    "Dato requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtMatricula.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Debes ingresar tu contraseña.",
                    "Dato requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtPassword.Focus();
                return;
            }

            //Esta parte solo es temporal para el acceso al administrador
            if (matricula == "admin" && password == "admin123")
            {
                FrmPrincipalAdmin frmAdmin = new FrmPrincipalAdmin();

                frmAdmin.Show();

                this.Hide();

                return;
            }

            // Buscar al alumno por matrícula
            Alumno? alumno = DatosService.Alumnos
                .FirstOrDefault(a => a.Matricula == matricula);

            if (alumno == null)
            {
                MessageBox.Show(
                    "La matrícula ingresada no se encuentra registrada.",
                    "Matrícula no encontrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtMatricula.Focus();
                return;
            }

            //Acceso de alumno
            FrmInicio frmInicio = new FrmInicio(alumno.Matricula);

            frmInicio.Show();

            this.Hide();

        }
        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
