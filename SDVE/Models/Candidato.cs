using System;
using System.Collections.Generic;
using System.Text;

namespace SDVE.Models
{
    internal class Candidato
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public int ConvocatoriaId { get; set; }

        public bool EsRegistrado { get; set; }
    }
}
