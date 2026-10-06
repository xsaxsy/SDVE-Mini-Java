using MySqlConnector;
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
            string usuario = txtMatricula.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show(
                    "Debes ingresar tu matrícula o usuario.",
                    "Dato requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMatricula.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Debes ingresar tu contraseña.",
                    "Dato requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Focus();
                return;
            }

            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    // Verificar administrador
                    string sqlAdmin =
                        @"SELECT COUNT(*)
                  FROM Administradores
                  WHERE Usuario = @usuario
                  AND Contrasena = @contrasena";

                    MySqlCommand cmdAdmin =
                        new MySqlCommand(sqlAdmin, conn);

                    cmdAdmin.Parameters.AddWithValue("@usuario", usuario);
                    cmdAdmin.Parameters.AddWithValue("@contrasena", password);

                    int existeAdmin =
                        Convert.ToInt32(cmdAdmin.ExecuteScalar());

                    if (existeAdmin > 0)
                    {
                        FrmPrincipalAdmin frmAdmin =
                            new FrmPrincipalAdmin();

                        frmAdmin.Show();
                        this.Hide();
                        return;
                    }

                    // Verificar alumno
                    string sqlAlumno =
                        @"SELECT COUNT(*)
                  FROM Alumnos
                  WHERE Matricula = @matricula
                  AND Contrasena = @contrasena";

                    MySqlCommand cmdAlumno =
                        new MySqlCommand(sqlAlumno, conn);

                    cmdAlumno.Parameters.AddWithValue("@matricula", usuario);
                    cmdAlumno.Parameters.AddWithValue("@contrasena", password);

                    int existeAlumno =
                        Convert.ToInt32(cmdAlumno.ExecuteScalar());

                    if (existeAlumno > 0)
                    {
                        FrmInicio frmInicio =
                            new FrmInicio(usuario);

                        frmInicio.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Usuario o contraseña incorrectos.",
                            "Acceso denegado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
