using System;
using System.Collections.Generic;

namespace Microservicio.ActualizarProducto.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public int? IdDoctor { get; set; }

        public virtual Doctor? IdDoctorNavigation { get; set; }
    }
}
