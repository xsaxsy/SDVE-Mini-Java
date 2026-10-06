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
        private string matriculaAlumno = string.Empty;
        public FrmInicio()
        {
            InitializeComponent();
            UiTheme.Apply(this);
        }
        public FrmInicio (string matricula)
        {
            InitializeComponent();
            UiTheme.Apply(this);
            matriculaAlumno = matricula;
            DatosService.CargarConvocatorias();
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

            var eleccionesSeleccionadas = new[]
                { chkSociedadAlumnos, chkConsejoUniversitario, chkConsejoRepresentantes }
                .Where(opcion => opcion.Checked && opcion.Tag is int)
                .Select(opcion => (int)opcion.Tag!)
                .ToList();

            if (eleccionesSeleccionadas.Count == 0)
            {
                MessageBox.Show(
                    "No hay convocatorias activas disponibles.",
                    "Sin convocatorias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

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

            try
            {
                FrmVotacion frmVotacion = new FrmVotacion(eleccionesSeleccionadas, matriculaAlumno, this);
                frmVotacion.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar la papeleta desde MySQL.\n\n" + ex.Message,
                    "Error al abrir votación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarConvocatoriasActivas()
        {
            var opciones = new[]
            {
                (Control: chkSociedadAlumnos, Clave: "sociedad"),
                (Control: chkConsejoUniversitario, Clave: "consejo universitario"),
                (Control: chkConsejoRepresentantes, Clave: "representantes")
            };

            foreach (var opcion in opciones)
            {
                opcion.Control.Visible = false;
                opcion.Control.Checked = false;
                opcion.Control.Tag = null;

                var convocatoria = DatosService.Convocatorias.FirstOrDefault(c =>
                    c.Activa && c.Nombre.Contains(opcion.Clave, StringComparison.CurrentCultureIgnoreCase));

                if (convocatoria != null)
                {
                    opcion.Control.Tag = convocatoria.Id;
                    opcion.Control.Visible = true;
                }
            }
        }
    }
}
