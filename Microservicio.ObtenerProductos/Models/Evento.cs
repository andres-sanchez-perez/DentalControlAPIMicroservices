using System;
using System.Collections.Generic;

namespace Microservicio.ObtenerProductos.Models
{
    public partial class Evento
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int IdDoctor { get; set; }
        public int? IdCita { get; set; }

        public virtual Citum? IdCitaNavigation { get; set; }
    }
}
