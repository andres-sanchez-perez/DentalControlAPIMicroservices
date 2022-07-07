using System;
using System.Collections.Generic;

#nullable disable

namespace Microservicio.ActualizarProductoRes.Models
{
    public partial class Citum
    {
        public Citum()
        {
            Calendarios = new HashSet<Calendario>();
            Eventos = new HashSet<Evento>();
        }

        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public int IdDoctor { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string Estado { get; set; }

        public virtual Doctor IdDoctorNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual ICollection<Calendario> Calendarios { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
