using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SDVE.Forms
{
    public partial class FrmPrincipalAdmin : Form
    {
        public FrmPrincipalAdmin()
        {
            InitializeComponent();
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
            FrmConvocatorias frmCnvocatorias = new FrmConvocatorias();
            frmCnvocatorias.ShowDialog();
        }

        private void btnCandidatos_Click(object sender, EventArgs e)
        {
            FrmCandidatos frmCandidatos = new FrmCandidatos();
            frmCandidatos.ShowDialog();
        }

        private void btnResultados_Click(object sender, EventArgs e)
        {
            FrmResultados frmResultados = new FrmResultados();
            frmResultados.ShowDialog();

        }
    }
}
