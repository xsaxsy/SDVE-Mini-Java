using System;
using System.Collections.Generic;
using System.Text;

namespace SDVE.Models
{
    public class Voto
    {
        public int Id { get; set; }

        public string MatriculaAlumno { get; set; } = string.Empty;

        public int ConvocatoriaId { get; set; }

        public int? CandidatoId { get; set; }

        public string CandidatoNoRegistrado { get; set; } = string.Empty;

        public DateTime FechaHora { get; set; }
    }
}
