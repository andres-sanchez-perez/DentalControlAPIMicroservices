using System;
using System.Collections.Generic;

namespace Microservicio.AgregarProductos.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Cita = new HashSet<Citum>();
            Users = new HashSet<User>();
            IdCalendarios = new HashSet<Calendario>();
        }

        public int IdDoctor { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Especialidad { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public DateTime FechaNac { get; set; }
        public string Cedula { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public int Edad { get; set; }
        public string NumCelular { get; set; } = null!;
        public string NumFijo { get; set; } = null!;

        public virtual ICollection<Citum> Cita { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Calendario> IdCalendarios { get; set; }
    }
}
