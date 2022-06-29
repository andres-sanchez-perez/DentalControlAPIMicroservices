using System;
using System.Collections.Generic;

namespace Microservicio.ObtenerProductos.Models
{
    public partial class Inventario
    {
        public int IdInventario { get; set; }
        public string Nombre { get; set; } = null!;
        public float Precio { get; set; }
        public string Tipo { get; set; } = null!;
        public float CantidadActual { get; set; }
        public float CantidadMinima { get; set; }
        public int Prioridad { get; set; }
        public float CantidadMaxima { get; set; }
        public string Medida { get; set; } = null!;
    }
}
