using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microservicio.ActualizarProductoRes.Models;
using Microservicio.ActualizarProductoRes.UpdateModel;

namespace Microservicio.ActualizarProductoRes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventariosController : ControllerBase
    {
        private readonly DentalControlContext _context;

        public InventariosController(DentalControlContext context)
        {
            _context = context;
        }



        // PUT: api/Inventarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Route("ActualizarProducto")]
        public async Task<IActionResult> PutInventario(UpdateModelObject datos)
        {
            var inventarioObtenido = _context.Inventarios.Find(datos.Id);
            if (inventarioObtenido != null)
            {
                var invActualizado = actualizarInventarioSeleccionado(inventarioObtenido, datos.Tipo, datos.Selector, datos.AgregarReducir);
                _context.Entry(invActualizado).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        private Inventario actualizarInventarioSeleccionado(Inventario inv, string tipo, int selector, float agregarReducir)
        {
            inv.Tipo = tipo;
            if (selector == 1)
            {
                inv.CantidadActual += agregarReducir;
                if (inv.CantidadActual > inv.CantidadMaxima)
                {
                    inv.CantidadMaxima = inv.CantidadActual;
                    inv.CantidadMinima = inv.CantidadMaxima / 2;
                    inv.Prioridad = setPrioridad(inv.CantidadActual, inv.CantidadMaxima, inv.CantidadMinima);
                }
            }
            else
            {
                if (agregarReducir <= inv.CantidadActual)
                {
                    inv.CantidadActual -= agregarReducir;
                }
                inv.Prioridad = setPrioridad(inv.CantidadActual, inv.CantidadMaxima, inv.CantidadMinima);
            }
            return inv;
        }

        private int setPrioridad(float cantidadActual, float cantidadMaxima, float cantidadMinima)
        {
            var prioridad = 0;
            var PrioL = cantidadMaxima * 0.75;
            var PrioM = cantidadMaxima * 0.5;
            var CantAc = cantidadActual;

            if (cantidadActual <= cantidadMaxima && CantAc > PrioL)
            {
                prioridad = 3;
            }
            else if (CantAc < PrioL && cantidadActual > cantidadMinima && CantAc > PrioM)
            {
                prioridad = 2;
            }
            else
            {
                prioridad = 1;
            }
            return prioridad;
        }
        private bool InventarioExists(int id)
        {
            return (_context.Inventarios?.Any(e => e.IdInventario == id)).GetValueOrDefault();
        }
    }
}
