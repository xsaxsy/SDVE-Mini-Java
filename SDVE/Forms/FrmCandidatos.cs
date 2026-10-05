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
    public partial class FrmCandidatos : Form
    {
        public FrmCandidatos()
        {
            InitializeComponent();
            UiTheme.Apply(this);
            CargarCandidatos();
        }

        private void CargarCandidatos()
        {
            dgvCandidatos.DataSource = null;

            dgvCandidatos.DataSource =
                DatosService.Candidatos
                    .Select(c => new
                    {
                        ID = c.Id,
                        Nombre = c.Nombre,
                        Convocatoria =
                            DatosService.Convocatorias
                                .FirstOrDefault(conv =>
                                    conv.Id == c.ConvocatoriaId)?.Nombre
                                ?? "Sin convocatoria",
                        Tipo = c.EsRegistrado
                            ? "Registrado"
                            : "No registrado"
                    })
                    .ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (FrmAgregarCandidatto frm = new FrmAgregarCandidatto())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarCandidatos();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCandidatos.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Debes seleccionar un candidato.",
                    "Candidato no seleccionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            int candidatoId =
                Convert.ToInt32(
                    dgvCandidatos.SelectedRows[0].Cells["ID"].Value
                );

            using (FrmEditarCandidato1 frm =
                new FrmEditarCandidato1(candidatoId))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarCandidatos();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCandidatos.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Debes seleccionar un candidato.",
                    "Candidato no seleccionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int candidatoId = Convert.ToInt32(dgvCandidatos.SelectedRows[0].Cells["ID"].Value);

            Candidato? candidato = DatosService.Candidatos.FirstOrDefault(c => c.Id == candidatoId);

            if (candidato == null)
            {
                MessageBox.Show(
                    "No se encontró el candidato seleccionado.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            bool tieneVotos =
                DatosService.Votos
                    .Any(v => v.CandidatoId == candidatoId);

            if (tieneVotos)
            {
                MessageBox.Show(
                    "No se puede eliminar este candidato porque ya existen votos registrados a su nombre.",
                    "Candidato con votos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar al candidato:\n\n" +
                candidato.Nombre + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            DatosService.Candidatos.Remove(candidato);

            MessageBox.Show(
                "El candidato se eliminó correctamente.",
                "Candidato eliminado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            CargarCandidatos();

        }
    }
}
