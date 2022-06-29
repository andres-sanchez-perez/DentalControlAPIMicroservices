using System;
using System.Collections.Generic;

namespace Microservicio.ObtenerProductos.Models
{
    public partial class Calendario
    {
        public Calendario()
        {
            IdDoctors = new HashSet<Doctor>();
        }

        public int IdCalendario { get; set; }
        public int IdCita { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Citum IdCitaNavigation { get; set; } = null!;

        public virtual ICollection<Doctor> IdDoctors { get; set; }
    }
}
