using System;
using System.Collections.Generic;

#nullable disable

namespace Microservicio.ActualizarProductoRes.Models
{
    public partial class Calendariodoctor
    {
        public int IdCalendario { get; set; }
        public int IdDoctor { get; set; }

        public virtual Calendario IdCalendarioNavigation { get; set; }
        public virtual Doctor IdDoctorNavigation { get; set; }
    }
}
