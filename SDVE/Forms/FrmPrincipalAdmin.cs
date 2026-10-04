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
            frmLogin.Show();

            this.Hide();

        }
    }
}
