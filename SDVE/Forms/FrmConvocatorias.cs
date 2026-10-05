using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SDVE.Services;
using SDVE.Models;
using System.Linq;


namespace SDVE.Forms
{
    public partial class FrmConvocatorias : Form
    {
        public FrmConvocatorias()
        {
            InitializeComponent();
            CargarConvocatorias();
        }

        private void CargarConvocatorias()
        {
            dgvConvocatorias.DataSource = null;

            dgvConvocatorias.DataSource =
        DatosService.Convocatorias
            .Select(c => new
            {
                ID = c.Id,
                Convocatoria = c.Nombre,
                Activa = c.Activa ? "Sí" : "No"
            })
            .ToList();
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (dgvConvocatorias.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Debes seleccionar una convocatoria para cambiar su estado.",
                    "Selección requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int convocatoriaId =
        Convert.ToInt32(
            dgvConvocatorias.SelectedRows[0].Cells["ID"].Value
        );

            Convocatoria? convocatoria =
                DatosService.Convocatorias
                    .FirstOrDefault(c => c.Id == convocatoriaId);

            if (convocatoria == null)
            {
                MessageBox.Show(
                    "No se encontró la convocatoria seleccionada.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            convocatoria.Activa = !convocatoria.Activa;

            CargarConvocatorias();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
