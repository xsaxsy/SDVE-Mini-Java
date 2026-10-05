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
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace SDVE.Forms
{
    public partial class FrmExportacion : Form
    {
        public FrmExportacion()
        {
            InitializeComponent();
        }

        private void FrmExportacion_Load(object sender, EventArgs e)
        {
            CargarConvocatorias();
            CargarFormatos();
            CargarNiveles();
        }

        private void CargarConvocatorias()
        {
            cmbConvocatoria.DataSource =
                DatosService.Convocatorias.ToList();

            cmbConvocatoria.DisplayMember = "Nombre";
            cmbConvocatoria.ValueMember = "Id";
        }

        private void CargarFormatos()
        {
            cmbFormato.Items.Clear();

            cmbFormato.Items.Add("CSV");
            cmbFormato.Items.Add("JSON");
            cmbFormato.Items.Add("XML");

            cmbFormato.SelectedIndex = 0;
        }

        private void CargarNiveles()
        {
            cmbNivel.Items.Clear();

            cmbNivel.Items.Add("General");
            cmbNivel.Items.Add("Grupo");
            cmbNivel.Items.Add("Carrera");
            cmbNivel.Items.Add("Centro Universitario");

            cmbNivel.SelectedIndex = 0;
        }

        private void cmbNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFiltro.Items.Clear();

            string nivel =
                cmbNivel.SelectedItem?.ToString() ?? "General";

            if (nivel == "General")
            {
                lblFiltro.Visible = false;
                cmbFiltro.Visible = false;

                return;
            }

            lblFiltro.Visible = true;
            cmbFiltro.Visible = true;

            if (nivel == "Grupo")
            {
                foreach (string grupo in DatosService.Alumnos
                    .Select(a => a.Grupo)
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
            else if (nivel == "Centro Universitario")
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (cmbConvocatoria.SelectedItem is not Convocatoria convocatoria)
            {
                MessageBox.Show(
                    "Debes seleccionar una convocatoria.",
                    "Dato requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string formato =
                cmbFormato.SelectedItem?.ToString() ?? "CSV";

            string nivel =
                cmbNivel.SelectedItem?.ToString() ?? "General";

            string? filtro =
                cmbFiltro.SelectedItem?.ToString();

            // Obtener votos de la convocatoria
            var votosFiltrados = DatosService.Votos
                .Where(v => v.ConvocatoriaId == convocatoria.Id)
                .ToList();

            // Obtener alumnos
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
            else if (nivel == "Centro Universitario" &&
                     !string.IsNullOrWhiteSpace(filtro))
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

            int totalVotos = votosFiltrados.Count;

            // Crear lista general de resultados
            var resultadosExportacion =
                new List<object>();

            // Candidatos registrados
            var candidatos = DatosService.Candidatos
                .Where(c => c.ConvocatoriaId == convocatoria.Id)
                .ToList();

            foreach (Candidato candidato in candidatos)
            {
                int votos = votosFiltrados.Count(
                    v => v.CandidatoId == candidato.Id
                );

                double porcentaje = totalVotos > 0
                    ? (double)votos / totalVotos * 100
                    : 0;

                resultadosExportacion.Add(new
                {
                    Candidato = candidato.Nombre,
                    Votos = votos,
                    Porcentaje = Math.Round(porcentaje, 2)
                });
            }

            // Candidatos no registrados
            var noRegistrados = votosFiltrados
                .Where(v =>
                    v.CandidatoId == null &&
                    !string.IsNullOrWhiteSpace(v.CandidatoNoRegistrado))
                .GroupBy(v => v.CandidatoNoRegistrado);

            foreach (var grupo in noRegistrados)
            {
                int votos = grupo.Count();

                double porcentaje = totalVotos > 0
                    ? (double)votos / totalVotos * 100
                    : 0;

                resultadosExportacion.Add(new
                {
                    Candidato = grupo.Key + " (No registrado)",
                    Votos = votos,
                    Porcentaje = Math.Round(porcentaje, 2)
                });
            }

            //Exportacion CSV, el formato que se puede abrir en excel

            if (formato == "CSV")
            {
                StringBuilder csv = new StringBuilder();

                csv.AppendLine(
                    "Candidato,Votos,Porcentaje"
                );

                foreach (var resultado in resultadosExportacion)
                {
                    // Convertir objeto anónimo a JSON para obtener sus propiedades
                    string json =
                        JsonSerializer.Serialize(resultado);

                    using JsonDocument documento =
                        JsonDocument.Parse(json);

                    string candidato =
                        documento.RootElement
                            .GetProperty("Candidato")
                            .GetString() ?? "";

                    int votos =
                        documento.RootElement
                            .GetProperty("Votos")
                            .GetInt32();

                    double porcentaje =
                        documento.RootElement
                            .GetProperty("Porcentaje")
                            .GetDouble();

                    csv.AppendLine(
                        $"\"{candidato}\"," +
                        $"{votos}," +
                        $"{porcentaje:0.00}%"
                    );
                }

                SaveFileDialog guardar = new SaveFileDialog();

                guardar.Title = "Guardar resultados";
                guardar.Filter = "Archivo CSV (*.csv)|*.csv";
                guardar.FileName =
                    "Resultados_" +
                    convocatoria.Nombre.Replace(" ", "_") +
                    ".csv";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                File.WriteAllText(
                    guardar.FileName,
                    csv.ToString(),
                    Encoding.UTF8
                );

                MessageBox.Show(
                    "Los resultados se exportaron correctamente.",
                    "Exportación completada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

            //Exportación en forato JSON

            else if (formato == "JSON")
            {
                string json =
                    JsonSerializer.Serialize(
                        resultadosExportacion,
                        new JsonSerializerOptions
                        {
                            WriteIndented = true
                        }
                    );

                SaveFileDialog guardar = new SaveFileDialog();

                guardar.Title = "Guardar resultados";
                guardar.Filter = "Archivo JSON (*.json)|*.json";
                guardar.FileName =
                    "Resultados_" +
                    convocatoria.Nombre.Replace(" ", "_") +
                    ".json";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                File.WriteAllText(
                    guardar.FileName,
                    json,
                    Encoding.UTF8
                );

                MessageBox.Show(
                    "Los resultados se exportaron correctamente.",
                    "Exportación completada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else if (formato == "XML")
            {
                XElement xml = new XElement(
                    "Resultados",
                    new XElement(
                        "Convocatoria",
                        convocatoria.Nombre
                    ),
                    new XElement(
                        "Nivel",
                        nivel
                    ),
                    new XElement(
                        "Filtro",
                        filtro ?? "Todos"
                    ),
                    new XElement(
                        "Candidatos",
                        resultadosExportacion.Select(resultado =>
                        {
                            string json =
                                JsonSerializer.Serialize(resultado);

                            using JsonDocument documento =
                                JsonDocument.Parse(json);

                            string candidato =
                                documento.RootElement
                                    .GetProperty("Candidato")
                                    .GetString() ?? "";

                            int votos =
                                documento.RootElement
                                    .GetProperty("Votos")
                                    .GetInt32();

                            double porcentaje =
                                documento.RootElement
                                    .GetProperty("Porcentaje")
                                    .GetDouble();

                            return new XElement(
                                "Candidato",
                                new XElement("Nombre", candidato),
                                new XElement("Votos", votos),
                                new XElement("Porcentaje", porcentaje)
                            );
                        })
                    )
                );

                SaveFileDialog guardar = new SaveFileDialog();

                guardar.Title = "Guardar resultados";
                guardar.Filter = "Archivo XML (*.xml)|*.xml";
                guardar.FileName =
                    "Resultados_" +
                    convocatoria.Nombre.Replace(" ", "_") +
                    ".xml";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                xml.Save(guardar.FileName);

                MessageBox.Show(
                    "Los resultados se exportaron correctamente.",
                    "Exportación completada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void btnRegrear_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
