using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microservicio.ObtenerProductos.Models;
using System.Net;

namespace Microservicio.ObtenerProductos.Controllers
{
    [Route("/api/[Controller]")]
    [ApiController]
    public class InventariosController : ControllerBase
    {
        private readonly DentalControlContext _context;

        public InventariosController(DentalControlContext context)
        {
            _context = context;
        }

        // GET: api/Inventarios
        [HttpGet]
        [Route("ObtenerProductos")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<Inventario>>> GetInventarios()
        {
          if (_context.Inventarios == null)
          {
              return NotFound();
          }
            return await _context.Inventarios.ToListAsync();
        }

        // GET: api/Inventarios/5
        [HttpGet]
        [Route("ObtenerProductoPorId/{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Inventario>> GetInventario(int id)
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

            return inventario;
        }

        

        private bool InventarioExists(int id)
        {
            return (_context.Inventarios?.Any(e => e.IdInventario == id)).GetValueOrDefault();
        }
    }
}
