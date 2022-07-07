using System;
using System.Collections.Generic;

#nullable disable

namespace Microservicio.ActualizarProductoRes.Models
{
    public partial class Tratamiento
    {
        public int IdTratamiento { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public float Presupuesto { get; set; }
        public int IdHistorial { get; set; }
        public float? Abono { get; set; }
        public string FormaPago { get; set; }
        public double Saldo { get; set; }
        public DateTime FechaPago { get; set; }

        public virtual Historial IdHistorialNavigation { get; set; }
    }
}
