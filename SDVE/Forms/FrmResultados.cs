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
            UiTheme.Apply(this);
        }

        private void FrmResultados_Load(object sender, EventArgs e)
        {
            CargarConvocatorias();
            CargarNiveles();
        }

        private void CargarConvocatorias()
        {
            cmbConvocatoria.DataSource = DatosService.Convocatorias.ToList();

            cmbConvocatoria.DisplayMember = "Nombre";
            cmbConvocatoria.ValueMember = "Id";
        }

        private void CargarNiveles()
        {
            cmbNivel.Items.Clear();
            cmbNivel.Items.Add("General");
            cmbNivel.Items.Add("Grupo");
            cmbNivel.Items.Add("Carrera");
            cmbNivel.Items.Add("Cenetro Universitario");

            cmbNivel.SelectedIndex = 0;
        }

        private void cmbConvocatoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConvocatoria.SelectedItem is not Convocatoria convocatoria)
                return;

            CargarResultados(convocatoria.Id);
        }

        private void CargarResultados(int convocatoriaId, string? nivel = null, string? filtro = null)
        {
            var votosFiltrados =
        DatosService.Votos
        .Where(v => v.ConvocatoriaId == convocatoriaId)
        .ToList();

            var alumnosFiltrados =
                DatosService.Alumnos.ToList();

            if (nivel == "Grupo" && !string.IsNullOrWhiteSpace(filtro))
            {
                alumnosFiltrados = alumnosFiltrados
                    .Where(a => a.Grupo == filtro)
                    .ToList();
            }
            else if (nivel == "Carrera" && !string.IsNullOrWhiteSpace(filtro))
            {
                alumnosFiltrados = alumnosFiltrados
                    .Where(a => a.Carrera == filtro)
                    .ToList();
            }
            else if (nivel == "Centro Universitario" && !string.IsNullOrWhiteSpace(filtro))
            {
                alumnosFiltrados = alumnosFiltrados
                    .Where(a => a.CentroUniversitario == filtro)
                    .ToList();
            }

            var matriculasFiltradas =
                alumnosFiltrados
                    .Select(a => a.Matricula)
                    .ToHashSet();

            votosFiltrados = votosFiltrados
                .Where(v => matriculasFiltradas.Contains(v.MatriculaAlumno))
                .ToList();

            int totalVotos = votosFiltrados.Count;

            int totalAlumnos = alumnosFiltrados.Count;

            int alumnosQueVotaron =
                votosFiltrados
                    .Select(v => v.MatriculaAlumno)
                    .Distinct()
                    .Count();
             //Esta parte es la que calcula la participación 
            double participacion = totalAlumnos > 0
                ? (double)alumnosQueVotaron / totalAlumnos * 100
                : 0;

            double abstencionismo = 100 - participacion;

            lblParticipacion.Text =
                "Participación: " +
                participacion.ToString("0.00") +
                " %";

            lblAbstencionismo.Text =
                "Abstencionismo: " +
                abstencionismo.ToString("0.00") +
                " %";

            var resultados = new List<dynamic>();

            // Candidatos registrados
            var candidatosRegistrados =
                DatosService.Candidatos
                    .Where(c => c.ConvocatoriaId == convocatoriaId)
                    .ToList();

            foreach (Candidato candidato in candidatosRegistrados)
            {
                int votos =
                    votosFiltrados.Count(v =>
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
                 votosFiltrados
                 .Where(v =>
                 v.CandidatoId == null &&
                 !string.IsNullOrWhiteSpace(v.CandidatoNoRegistrado))
                 .GroupBy(v => v.CandidatoNoRegistrado)
                 .Select(grupo => new
                 {
                     Candidato = grupo.Key + "(No registrado)",
                     Votos = grupo.Count(),
                     Porcentaje = totalVotos > 0
                     ? ((double)grupo.Count() / totalVotos * 100)
                     .ToString("0.00") + " %" : "0.00 %"
                 });

            foreach (var candidato in candidatosNoRegistrados)
            {
                resultados.Add(candidato);
            }

            dgvResultados.DataSource = null;
            dgvResultados.DataSource = resultados;

            CargarGrafica(convocatoriaId, nivel, filtro);
        }

        // Final de cargarResultados

        private void CargarGrafica(int convocatoriaId, string? nivel = null, string? filtro = null)
        {
            pnlGrafica.Controls.Clear();

            var votosFiltrados = DatosService.Votos
                .Where(v => v.ConvocatoriaId == convocatoriaId)
                .ToList();

            var alumnosFiltrados = DatosService.Alumnos.ToList();

            // Aplicar filtros
            if (nivel == "Grupo" && !string.IsNullOrWhiteSpace(filtro))
            {
                alumnosFiltrados = alumnosFiltrados
                    .Where(a => a.Grupo == filtro)
                    .ToList();
            }
            else if (nivel == "Carrera" && !string.IsNullOrWhiteSpace(filtro))
            {
                alumnosFiltrados = alumnosFiltrados
                    .Where(a => a.Carrera == filtro)
                    .ToList();
            }
            else if (nivel == "Centro Universitario" && !string.IsNullOrWhiteSpace(filtro))
            {
                alumnosFiltrados = alumnosFiltrados
                    .Where(a => a.CentroUniversitario == filtro)
                    .ToList();
            }

            var matriculasFiltradas = alumnosFiltrados
                .Select(a => a.Matricula)
                .ToHashSet();

            votosFiltrados = votosFiltrados
                .Where(v => matriculasFiltradas.Contains(v.MatriculaAlumno))
                .ToList();

            // Lista de resultados para la gráfica
            var resultadosGrafica = new List<(string Nombre, int Votos)>();

            var candidatos = DatosService.Candidatos
                .Where(c => c.ConvocatoriaId == convocatoriaId)
                .ToList();

            // Candidatos registrados
            foreach (Candidato candidato in candidatos)
            {
                int votos = votosFiltrados.Count(
                    v => v.CandidatoId == candidato.Id
                );

                resultadosGrafica.Add(
                    (candidato.Nombre, votos)
                );
            }

            // Candidatos no registrados
            var noRegistrados = votosFiltrados
                .Where(v =>
                    v.CandidatoId == null &&
                    !string.IsNullOrWhiteSpace(v.CandidatoNoRegistrado))
                .GroupBy(v => v.CandidatoNoRegistrado);

            foreach (var grupo in noRegistrados)
            {
                resultadosGrafica.Add(
                    (grupo.Key + " (No registrado)", grupo.Count())
                );
            }

            if (resultadosGrafica.Count == 0)
            {
                Label lblSinResultados = new Label();

                lblSinResultados.Text = "No hay resultados disponibles.";
                lblSinResultados.AutoSize = true;
                lblSinResultados.Font = new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Italic
                );
                lblSinResultados.Location = new Point(20, 20);

                pnlGrafica.Controls.Add(lblSinResultados);

                return;
            }

            int maxVotos = resultadosGrafica.Max(r => r.Votos);

            if (maxVotos == 0)
            {
                maxVotos = 1;
            }

            int posicionY = 15;
            int anchoMaximoBarra = 550;

            foreach (var resultado in resultadosGrafica)
            {
                // Nombre
                Label lblNombre = new Label();

                lblNombre.Text = resultado.Nombre;
                lblNombre.AutoSize = false;
                lblNombre.Size = new Size(180, 30);
                lblNombre.TextAlign = ContentAlignment.MiddleRight;
                lblNombre.Location = new Point(10, posicionY);

                pnlGrafica.Controls.Add(lblNombre);

                // Barra
                Panel barra = new Panel();

                int anchoBarra = resultado.Votos == 0
                    ? 0
                    : (int)(
                        (double)resultado.Votos /
                        maxVotos *
                        anchoMaximoBarra
                    );

                barra.Size = new Size(anchoBarra, 25);
                barra.Location = new Point(200, posicionY + 2);
                barra.BorderStyle = BorderStyle.FixedSingle;

                pnlGrafica.Controls.Add(barra);

                // Número de votos
                Label lblVotos = new Label();

                lblVotos.Text = resultado.Votos.ToString();
                lblVotos.AutoSize = true;
                lblVotos.Font = new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold
                );

                lblVotos.Location = new Point(
                    210 + anchoBarra,
                    posicionY + 3
                );

                pnlGrafica.Controls.Add(lblVotos);

                posicionY += 40;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFiltro.Items.Clear();

            string nivel = cmbNivel.SelectedItem?.ToString() ?? "General";

            if(nivel == "General")
            {
                lblFiltro.Visible = false;
                cmbFiltro.Visible = false;
                return;
            }

            lblFiltro.Visible = true;
            cmbFiltro.Visible = true;

            if(nivel == "Grupo")
            {
                foreach(string grupo in DatosService.Alumnos
                    .Select(async => async.Grupo)
                    .Distinct()
                    .OrderBy(g => g))
                {
                    cmbFiltro.Items.Add(grupo);
                }
            }
            else if (nivel == "Carrera")
            {
                foreach (string carrera in DatosService.Alumnos
            .Select(a => a.Carrera)
            .Distinct()
            .OrderBy(c => c))
                {
                    cmbFiltro.Items.Add(carrera);
                }
            }
            else if(nivel == "Centro Univeritario")
            {
                foreach (string centro in DatosService.Alumnos
            .Select(a => a.CentroUniversitario)
            .Distinct()
            .OrderBy(c => c))
                {
                    cmbFiltro.Items.Add(centro);
                }
            }

            if (cmbFiltro.Items.Count > 0)
            {
                cmbFiltro.SelectedIndex = 0;
            }
        }
    }
}
