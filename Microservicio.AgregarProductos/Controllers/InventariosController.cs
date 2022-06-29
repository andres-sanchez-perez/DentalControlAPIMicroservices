using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microservicio.AgregarProductos.Models;

namespace Microservicio.AgregarProductos.Controllers
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


        // POST: api/Inventarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost]
        [Route("AgregarProducto")]
        public async Task<ActionResult<Inventario>> PostInventario([FromBody] Inventario inventario)
        {
          if (_context.Inventarios == null)
          {
              return Problem("Entity set 'DentalControlContext.Inventarios'  is null.");
          }

            _context.Inventarios.Add(inventario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventario", new { id = inventario.IdInventario }, inventario);
        }

        // DELETE: api/Inventarios/5
        [HttpDelete]
        [Route("EliminarPorducto/{id}")]
        public async Task<IActionResult> DeleteInventario(int id)
        {
            if (_context.Inventarios == null)
            {
                return NotFound();
            }
            var inventario = await _context.Inventarios.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }

            _context.Inventarios.Remove(inventario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventarioExists(int id)
        {
            return (_context.Inventarios?.Any(e => e.IdInventario == id)).GetValueOrDefault();
        }
    }
}
