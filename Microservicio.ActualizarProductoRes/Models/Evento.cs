using System;
using System.Collections.Generic;

#nullable disable

namespace Microservicio.ActualizarProductoRes.Models
{
    public partial class Evento
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descripcion { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int IdDoctor { get; set; }
        public int? IdCita { get; set; }

        public virtual Citum IdCitaNavigation { get; set; }
    }
}
