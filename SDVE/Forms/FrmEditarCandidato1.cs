using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using SDVE.Models;
using SDVE.Services;

namespace SDVE.Forms
{
    public partial class FrmEditarCandidato1 : Form
    {
        private int candidatoId;
        public FrmEditarCandidato1()
        {
            InitializeComponent();
            UiTheme.Apply(this);
        }

        public FrmEditarCandidato1(int id)
        {
            InitializeComponent();
            UiTheme.Apply(this);
            candidatoId = id;

            CargarConvocatorias();
            CargarCandidato();
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

        private void CargarCandidato()
        {
            Candidato? candidato =
                DatosService.Candidatos
                    .FirstOrDefault(c => c.Id == candidatoId);

            if (candidato == null)
            {
                MessageBox.Show(
                    "No se encontró el candidato seleccionado.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Close();
                return;
            }

            txtNombre.Text = candidato.Nombre;
            cmbConvocatoria.SelectedValue = candidato.ConvocatoriaId;
        }

        private void button1_Click(object sender, EventArgs e)
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

            Candidato? candidato =
                DatosService.Candidatos
                    .FirstOrDefault(c => c.Id == candidatoId);

            if (candidato == null)
            {
                MessageBox.Show(
                    "No se encontró el candidato.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            candidato.Nombre = nombre;
            candidato.ConvocatoriaId =
                Convert.ToInt32(cmbConvocatoria.SelectedValue);

            MessageBox.Show(
                "Los datos del candidato se actualizaron correctamente.",
                "Candidato actualizado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
