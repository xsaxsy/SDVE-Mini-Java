using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using SDVE.Models;
using SDVE.Services;
using System.Linq;


namespace SDVE.Forms
{
    public partial class FrmVotacion : Form
    {
        private List<int> eleccionesSeleccionadas = new();
        private List<Voto> votosSeleccionados = new List<Voto>();
        private string matriculaAlumno = string.Empty;
        private FrmInicio? formularioInicio;

        public FrmVotacion()
        {
            InitializeComponent();
            UiTheme.Apply(this);
        }
        public FrmVotacion(List<int> eleccionesSeleccionadas, string matriculaAlumno)
            : this(eleccionesSeleccionadas, matriculaAlumno, null)
        {
        }

        public FrmVotacion(List<int> eleccionesSeleccionadas, string matriculaAlumno, FrmInicio? formularioInicio)
        {
            InitializeComponent();
            UiTheme.Apply(this);

            this.eleccionesSeleccionadas = eleccionesSeleccionadas;
            this.matriculaAlumno = matriculaAlumno;
            this.formularioInicio = formularioInicio;

            DatosService.CargarDatos();
            CargarPapeleta();
        }
        private void CargarPapeleta()
        {
            pnlPapeleta.Controls.Clear();

            int posicionY = 15;

            foreach (int convocatoriaId in eleccionesSeleccionadas)
            {
                Convocatoria? convocatoria = DatosService.Convocatorias
                    .FirstOrDefault(c => c.Id == convocatoriaId);

                if (convocatoria == null)
                    continue;

                GroupBox grupo = new GroupBox();

                grupo.Text = convocatoria.Nombre;
                grupo.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                grupo.Location = new Point(15, posicionY);
                grupo.Width = 840;

                int posicionCandidatoY = 30;

                List<Candidato> candidatos = DatosService.Candidatos
                    .Where(c => c.ConvocatoriaId == convocatoriaId)
                    .ToList();

                foreach (Candidato candidato in candidatos)
                {
                    RadioButton radio = new RadioButton();

                    radio.Text = candidato.Nombre;
                    radio.Font = new Font("Segoe UI", 10);
                    radio.AutoSize = true;
                    radio.Location = new Point(20, posicionCandidatoY);

                    //Esta instruccion nos ayuda a guardar el ID del candidato
                    radio.Tag = candidato.Id;

                    grupo.Controls.Add(radio);

                    posicionCandidatoY += 30;
                }

                Label lblOtro = new Label();

                lblOtro.Text = "Candidato no registrado:";
                lblOtro.Font = new Font("Segoe UI", 10);
                lblOtro.AutoSize = true;
                lblOtro.Location = new Point(20, posicionCandidatoY + 5);

                grupo.Controls.Add(lblOtro);

                TextBox txtOtro = new TextBox();

                txtOtro.Width = 350;
                txtOtro.Location = new Point(200, posicionCandidatoY);

                // Guardamos el ID de la convocatoria
                txtOtro.Tag = convocatoriaId;

                grupo.Controls.Add(txtOtro);

                Button btnQuitarSeleccion = new Button
                {
                    Text = "Quitar selección",
                    Location = new Point(590, posicionCandidatoY),
                    Size = new Size(145, 28),
                    UseVisualStyleBackColor = true
                };
                btnQuitarSeleccion.Click += (sender, e) =>
                {
                    foreach (RadioButton radio in grupo.Controls.OfType<RadioButton>())
                        radio.Checked = false;
                    txtOtro.Clear();
                };
                grupo.Controls.Add(btnQuitarSeleccion);

                grupo.Height = Math.Max(180, posicionCandidatoY + 50);
                pnlPapeleta.Controls.Add(grupo);

                posicionY += grupo.Height + 15;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            if (formularioInicio != null && !formularioInicio.IsDisposed)
            {
                formularioInicio.Show();
                formularioInicio.Activate();
            }
            else
            {
                new FrmInicio(matriculaAlumno).Show();
            }

            Close();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            votosSeleccionados.Clear();

            // Primero verificamos si el alumno ya votó
            // en alguna de las convocatorias seleccionadas.
            foreach (int convocatoriaId in eleccionesSeleccionadas)
            {
                bool yaVoto;
                try
                {
                    yaVoto = DatosService.YaVoto(matriculaAlumno, convocatoriaId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudo verificar si ya votaste.\n\n" + ex.Message,
                        "Error al consultar votos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (yaVoto)
                {
                    Convocatoria? convocatoria = DatosService.Convocatorias
                        .FirstOrDefault(c => c.Id == convocatoriaId);

                    MessageBox.Show(
                        "La matrícula " + matriculaAlumno +
                        " ya emitió un voto en:\n\n" +
                        convocatoria?.Nombre,
                        "Voto ya registrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }
            }

            // Después procesamos cada elección de la papeleta.
            foreach (Control control in pnlPapeleta.Controls)
            {
                if (control is GroupBox grupo)
                {
                    RadioButton? candidatoSeleccionado = null;
                    TextBox? candidatoNoRegistrado = null;

                    int convocatoriaId = 0;

                    foreach (Control elemento in grupo.Controls)
                    {
                        if (elemento is RadioButton radio && radio.Checked)
                        {
                            candidatoSeleccionado = radio;
                        }

                        if (elemento is TextBox textBox)
                        {
                            candidatoNoRegistrado = textBox;
                            convocatoriaId = textBox.Tag is int id ? id : 0;
                        }
                    }

                    bool tieneCandidatoRegistrado =
                        candidatoSeleccionado != null;

                    bool tieneCandidatoNoRegistrado =
                        candidatoNoRegistrado != null &&
                        !string.IsNullOrWhiteSpace(candidatoNoRegistrado.Text);

                    // Ninguna opción seleccionada.
                    if (!tieneCandidatoRegistrado &&
                        !tieneCandidatoNoRegistrado)
                    {
                        MessageBox.Show(
                            "Debes de seleccionar un candidato o escribir un candidato no registrado en:\n\n" +
                            grupo.Text,
                            "Voto incompleto",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }

                    // Con cambas opciones seleccionadas
                    if (tieneCandidatoRegistrado &&
                        tieneCandidatoNoRegistrado)
                    {
                        MessageBox.Show(
                            "No puedes seleccionar un candidato registrado y escribir un candidato no registrado al mismo tiempo:\n\n" +
                            grupo.Text,
                            "Selección no válida",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }

                    //Buscar el alumno
                    Alumno? alumno = DatosService.Alumnos.FirstOrDefault(a => a.Matricula == matriculaAlumno);

                    if (alumno == null)
                    {
                        MessageBox.Show(
                            "No se encontraron los datos del alumno.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                        return;
                    }
                    // Creamos el voto
                    Voto voto = new Voto
                    {
                        MatriculaAlumno = matriculaAlumno,
                        Grupo = alumno.Semestre,
                        Carrera = alumno.Carrera,
                        CentroUniversitario = alumno.CentroUniversitario,
                        ConvocatoriaId = convocatoriaId,
                        FechaHora = DateTime.Now
                    };

                    if (tieneCandidatoRegistrado)
                    {
                        voto.CandidatoId =
                            candidatoSeleccionado!.Tag is int candidatoId ? candidatoId : null;
                    }
                    else
                    {
                        voto.CandidatoNoRegistrado =
                            candidatoNoRegistrado!.Text.Trim();
                    }

                    votosSeleccionados.Add(voto);
                }
            }

            // Pasamos los votos a la pantalla de confirmación.
            FrmConfirmacion frmConfirmacion =
                new FrmConfirmacion(votosSeleccionados);

            frmConfirmacion.Show();

            this.Hide();
        }
    }
}
