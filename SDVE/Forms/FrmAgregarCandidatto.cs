using SDVE.Models;
using SDVE.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDVE.Forms
{
    public partial class FrmAgregarCandidatto : Form
    {
        public FrmAgregarCandidatto()
        {
            InitializeComponent();
            CargarConvocatorias();
        }

        private void CargarConvocatorias()
        {
            cmbConvocatoria.DataSource =
                DatosService.Convocatorias
                    .Where(c => c.Activa)
                    .ToList();

            cmbConvocatoria.DisplayMember = "Nombre";
            cmbConvocatoria.ValueMember = "Id";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show(
                    "Debes ingresar el nombre del candidato.",
                    "Dato requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNombre.Focus();
                return;
            }

            if (cmbConvocatoria.SelectedValue == null)
            {
                MessageBox.Show(
                    "Debes seleccionar una convocatoria.",
                    "Dato requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            int nuevoId =
                DatosService.Candidatos.Count == 0
                    ? 1
                    : DatosService.Candidatos.Max(c => c.Id) + 1;

            int convocatoriaId =
                Convert.ToInt32(cmbConvocatoria.SelectedValue);

            Candidato nuevoCandidato = new Candidato
            {
                Id = nuevoId,
                Nombre = nombre,
                ConvocatoriaId = convocatoriaId,
                EsRegistrado = true
            };

            DatosService.Candidatos.Add(nuevoCandidato);

            MessageBox.Show(
                "El candidato se agregó correctamente.",
                "Candidato agregado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
