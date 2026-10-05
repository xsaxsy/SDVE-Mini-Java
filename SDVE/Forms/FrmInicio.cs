using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using SDVE.Forms;
using System.Linq;
using SDVE.Services;
using SDVE.Models;

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
            CargarConvocatoriasActivas();
        }
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (!chkSociedadAlumnos.Checked && !chkConsejoUniversitario.Checked && !chkConsejoRepresentantes.Checked)
            {
                MessageBox.Show(null,
                    "Debes selecccionar al menos una elección. Selección requerida.",
                    "Selección requerida"
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

            foreach (int convocatoriaId in eleccionesSeleccionadas)
            {
                bool estaActiva = DatosService.Convocatorias.Any(c => c.Id == convocatoriaId && c.Activa);

                if (!estaActiva)
                {
                    MessageBox.Show(
                        "La convocatoria seleccionada ya no encuentra activa.",
                        "Convocatoria no disponible",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }
            
        }

        private void CargarConvocatoriasActivas()
        {
            Convocatoria? sociedadAlumnos =
        DatosService.Convocatorias
            .FirstOrDefault(c => c.Id == 1);

            Convocatoria? consejoUniversitario =
                DatosService.Convocatorias
                    .FirstOrDefault(c => c.Id == 2);

            Convocatoria? consejoRepresentantes =
                DatosService.Convocatorias
                    .FirstOrDefault(c => c.Id == 3);

            chkSociedadAlumnos.Visible =
                sociedadAlumnos != null && sociedadAlumnos.Activa;

            chkConsejoUniversitario.Visible =
                consejoUniversitario != null && consejoUniversitario.Activa;

            chkConsejoRepresentantes.Visible =
                consejoRepresentantes != null && consejoRepresentantes.Activa;
        }
    }
}
