using System;
using System.Collections.Generic;

#nullable disable

namespace Microservicio.ActualizarProductoRes.Models
{
    public partial class Inventario
    {
        public int IdInventario { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public string Tipo { get; set; }
        public float CantidadActual { get; set; }
        public float CantidadMinima { get; set; }
        public int Prioridad { get; set; }
        public float CantidadMaxima { get; set; }
        public string Medida { get; set; }
    }
}
