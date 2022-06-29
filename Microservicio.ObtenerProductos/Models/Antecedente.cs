using System;
using System.Collections.Generic;

namespace Microservicio.ObtenerProductos.Models
{
    public partial class Antecedente
    {
        public Antecedente()
        {
            Cirujia = new HashSet<Cirujium>();
        }

        public int AntecedentesId { get; set; }
        public int PacienteId { get; set; }
        public string? Alergias { get; set; }
        public short CirujiasPrevias { get; set; }
        public string? Enfermedades { get; set; }
        public string? Habitos { get; set; }
        public string? Motivo { get; set; }
        public short ProblemasHemorragicos { get; set; }

        public virtual Paciente Paciente { get; set; } = null!;
        public virtual ICollection<Cirujium> Cirujia { get; set; }
    }
}
