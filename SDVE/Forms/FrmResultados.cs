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
    public partial class FrmResultados : Form
    {
        public FrmResultados()
        {
            InitializeComponent();
        }

        private void FrmResultados_Load(object sender, EventArgs e)
        {
            CargarConvocatorias();
        }

        private void CargarConvocatorias()
        {
            cmbConvocatoria.DataSource = DatosService.Convocatorias.ToList();

            cmbConvocatoria.DisplayMember = "Nombre";
            cmbConvocatoria.ValueMember = "Id";
        }

        private void cmbConvocatoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConvocatoria.SelectedItem is not Convocatoria convocatoria)
                return;

            CargarResultados(convocatoria.Id);
        }

        private void CargarResultados(int convocatoriaId)
        {
            int totalVotos =
                DatosService.Votos
                    .Count(v => v.ConvocatoriaId == convocatoriaId);

            var resultados = new List<dynamic>();

            // Candidatos registrados
            var candidatosRegistrados =
                DatosService.Candidatos
                    .Where(c => c.ConvocatoriaId == convocatoriaId)
                    .ToList();

            foreach (Candidato candidato in candidatosRegistrados)
            {
                int votos =
                    DatosService.Votos
                        .Count(v =>
                            v.ConvocatoriaId == convocatoriaId &&
                            v.CandidatoId == candidato.Id);

                double porcentaje = totalVotos > 0
                    ? (double)votos / totalVotos * 100
                    : 0;

                resultados.Add(new
                {
                    Candidato = candidato.Nombre,
                    Votos = votos,
                    Porcentaje = porcentaje.ToString("0.00") + " %"
                });
            }

            // Candidatos no registrados
            var candidatosNoRegistrados =
                DatosService.Votos
                    .Where(v =>
                        v.ConvocatoriaId == convocatoriaId &&
                        v.CandidatoId == null &&
                        !string.IsNullOrWhiteSpace(v.CandidatoNoRegistrado))
                    .GroupBy(v => v.CandidatoNoRegistrado)
                    .Select(grupo => new
                    {
                        Candidato = grupo.Key + " (No registrado)",
                        Votos = grupo.Count(),
                        Porcentaje = totalVotos > 0
                            ? ((double)grupo.Count() / totalVotos * 100)
                                .ToString("0.00") + " %"
                            : "0.00 %"
                    });

            foreach (var candidato in candidatosNoRegistrados)
            {
                resultados.Add(candidato);
            }

            dgvResultados.DataSource = null;
            dgvResultados.DataSource = resultados;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
