using System;
using System.Collections.Generic;

namespace Microservicio.ActualizarProducto.Models
{
    public partial class Cirujium
    {
        public int CirujiaId { get; set; }
        public int? AntecedenteId { get; set; }
        public string NombreCirujia { get; set; } = null!;
        public DateTime FechaCirujia { get; set; }
        public int PacienteId { get; set; }
        public string DoctorAcargo { get; set; } = null!;

        public virtual Antecedente? Antecedente { get; set; }
        public virtual Paciente Paciente { get; set; } = null!;
    }
}
