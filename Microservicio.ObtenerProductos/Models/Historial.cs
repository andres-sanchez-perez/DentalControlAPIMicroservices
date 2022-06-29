using System;
using System.Collections.Generic;

namespace Microservicio.ObtenerProductos.Models
{
    public partial class Historial
    {
        public Historial()
        {
            Tratamientos = new HashSet<Tratamiento>();
        }

        public int IdHistorial { get; set; }
        public int IdPaciente { get; set; }

        public virtual Paciente IdPacienteNavigation { get; set; } = null!;
        public virtual ICollection<Tratamiento> Tratamientos { get; set; }
    }
}
