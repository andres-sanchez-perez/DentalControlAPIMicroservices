using System;
using System.Collections.Generic;

#nullable disable

namespace Microservicio.ActualizarProductoRes.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasenia { get; set; }
        public string Rol { get; set; }
        public int? IdDoctor { get; set; }

        public virtual Doctor IdDoctorNavigation { get; set; }
    }
}
