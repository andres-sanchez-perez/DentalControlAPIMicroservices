using System;
using System.Collections.Generic;

#nullable disable

namespace Microservicio.ActualizarProductoRes.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Calendariodoctors = new HashSet<Calendariodoctor>();
            Cita = new HashSet<Citum>();
            Users = new HashSet<User>();
        }

        public int IdDoctor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaNac { get; set; }
        public string Cedula { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public string NumCelular { get; set; }
        public string NumFijo { get; set; }

        public virtual ICollection<Calendariodoctor> Calendariodoctors { get; set; }
        public virtual ICollection<Citum> Cita { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
