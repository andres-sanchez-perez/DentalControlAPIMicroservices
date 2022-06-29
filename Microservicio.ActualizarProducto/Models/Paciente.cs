using System;
using System.Collections.Generic;

namespace Microservicio.ActualizarProducto.Models
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
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string NumCelular { get; set; } = null!;
        public string NumFijo { get; set; } = null!;
        public string DirDomicilio { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public DateTime FechaNac { get; set; }
        public int Edad { get; set; }

        public virtual ICollection<Antecedente> Antecedentes { get; set; }
        public virtual ICollection<Cirujium> Cirujia { get; set; }
        public virtual ICollection<Citum> Cita { get; set; }
        public virtual ICollection<Historial> Historials { get; set; }
    }
}
