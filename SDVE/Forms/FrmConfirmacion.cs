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
using SDVE.Forms;

namespace SDVE.Forms
{
    public partial class FrmConfirmacion : Form
    {
        private List<Voto> votos;
        public FrmConfirmacion()
        {
            InitializeComponent();
        }
        public FrmConfirmacion(List<Voto> votos)
        {
            InitializeComponent();
            this.votos = votos;
            CargarResumen();
        }

        private void CargarResumen()
        {
            pnlResumen.Controls.Clear();

            int posicionY = 15;

            foreach (Voto voto in votos)
            {
                Convocatoria? convocatoria = DatosService.Convocatorias
                    .FirstOrDefault(c => c.Id == voto.ConvocatoriaId);

                if (convocatoria == null)
                    continue;

                Label lblConvocatoria = new Label();

                lblConvocatoria.Text = convocatoria.Nombre;
                lblConvocatoria.Font = new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold
                );

                lblConvocatoria.AutoSize = true;
                lblConvocatoria.Location = new Point(20, posicionY);

                pnlResumen.Controls.Add(lblConvocatoria);

                posicionY += 30;

                string textoVoto;

                if (voto.CandidatoId.HasValue)
                {
                    Candidato? candidato = DatosService.Candidatos
                        .FirstOrDefault(c => c.Id == voto.CandidatoId.Value);

                    textoVoto = candidato != null
                        ? candidato.Nombre
                        : "Candidato no encontrado";
                }
                else
                {
                    textoVoto = voto.CandidatoNoRegistrado +
                                " (No registrado)";
                }

                Label lblVoto = new Label();

                lblVoto.Text = "✓ " + textoVoto;
                lblVoto.Font = new Font("Segoe UI", 10);
                lblVoto.AutoSize = true;
                lblVoto.Location = new Point(40, posicionY);

                pnlResumen.Controls.Add(lblVoto);

                posicionY += 45;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            foreach (Voto voto in votos)
            {
                DatosService.Votos.Add(voto);
            }

            MessageBox.Show("Tu voto ha sido registrado correctamente.",
                "Votación completada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );

            Application.Exit();
        }
    }
}
