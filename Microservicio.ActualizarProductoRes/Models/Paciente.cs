using System;
using System.Collections.Generic;

#nullable disable

namespace Microservicio.ActualizarProductoRes.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Antecedentes = new HashSet<Antecedente>();
            Cirujia = new HashSet<Cirujium>();
            Cita = new HashSet<Citum>();
            Historials = new HashSet<Historial>();
        }

        public int IdPaciente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string NumCelular { get; set; }
        public string NumFijo { get; set; }
        public string DirDomicilio { get; set; }
        public string Genero { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaNac { get; set; }
        public int Edad { get; set; }

        public virtual ICollection<Antecedente> Antecedentes { get; set; }
        public virtual ICollection<Cirujium> Cirujia { get; set; }
        public virtual ICollection<Citum> Cita { get; set; }
        public virtual ICollection<Historial> Historials { get; set; }
    }
}
