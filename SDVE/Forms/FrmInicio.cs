using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using SDVE.Forms;

namespace SDVE.Forms
{
    public partial class FrmInicio : Form
    {
        private string matriculaAlumno;
        public FrmInicio()
        {
            InitializeComponent();
        }
        public FrmInicio (string matricula)
        {
            InitializeComponent();
            matriculaAlumno = matricula;
        }
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (!chkSociedadAlumnos.Checked && !chkConsejoUniversitario.Checked && !chkConsejoRepresentantes.Checked)
            {
                MessageBox.Show(null,
                    "Debes selecccionar al menos una elección. Selección requerida."
                    , MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            List<int> eleccionesSeleccionadas = new List<int>();

            if (chkSociedadAlumnos.Checked)
                eleccionesSeleccionadas.Add(1);

            if (chkConsejoUniversitario.Checked)
                eleccionesSeleccionadas.Add(2);

            if (chkConsejoRepresentantes.Checked)
                eleccionesSeleccionadas.Add(3);

            FrmVotacion frmVotacion = new FrmVotacion(eleccionesSeleccionadas, matriculaAlumno);
            frmVotacion.Show();

            this.Hide();
            
        }
    }
}
