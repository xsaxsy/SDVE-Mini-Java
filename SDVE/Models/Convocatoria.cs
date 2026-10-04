using System;
using System.Collections.Generic;
using System.Text;

namespace SDVE.Models
{
    internal class Convocatoria
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public bool Activa { get; set; }
    }
}
