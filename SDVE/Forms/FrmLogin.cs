using SDVE.Forms;

namespace SDVE
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string matricula = txtMatricula.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(matricula))
            {
                MessageBox.Show(
                    "Debes de Ingresar tu matrícula.",
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
                    "Debes de Ingresar tu contraseña.",
                    "Dato requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                txtPassword.Focus();
                return;
            }

            if(matricula == "admin" && password == "admin123")
            {
                FrmPrincipalAdmin frmAdmin = new FrmPrincipalAdmin();

                frmAdmin.Show();
                this.Hide();
                return;

            }

            FrmInicio frmInicio = new FrmInicio(matricula);
            frmInicio.Show();
            this.Hide();
        }
        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
