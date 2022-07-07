using System;
using System.Collections.Generic;

#nullable disable

namespace Microservicio.ActualizarProductoRes.Models
{
    public partial class Calendario
    {
        public Calendario()
        {
            Calendariodoctors = new HashSet<Calendariodoctor>();
        }

        public int IdCalendario { get; set; }
        public int IdCita { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Citum IdCitaNavigation { get; set; }
        public virtual ICollection<Calendariodoctor> Calendariodoctors { get; set; }
    }
}
