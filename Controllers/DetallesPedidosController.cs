using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ventas.Data;
using Ventas.Models;

namespace Ventas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesPedidosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DetallesPedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DetallesPedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> GetDetallesPedidos()
        {
          if (_context.DetallesPedidos == null)
          {
              return NotFound();
          }
            return await _context.DetallesPedidos.ToListAsync();
        }

        // GET: api/DetallesPedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedido>> GetDetallePedido(int id)
        {
          if (_context.DetallesPedidos == null)
          {
              return NotFound();
          }
            var detallePedido = await _context.DetallesPedidos.FindAsync(id);

            if (detallePedido == null)
            {
                return NotFound();
            }

            return detallePedido;
        }

        // PUT: api/DetallesPedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallePedido(int id, DetallePedido detallePedido)
        {
            if (id != detallePedido.PedidoId)
            {
                return BadRequest();
            }

            _context.Entry(detallePedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallePedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DetallesPedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetallePedido>> PostDetallePedido(DetallePedido detallePedido)
        {
          if (_context.DetallesPedidos == null)
          {
              return Problem("Entity set 'ApplicationDbContext.DetallesPedidos'  is null.");
          }
            _context.DetallesPedidos.Add(detallePedido);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DetallePedidoExists(detallePedido.PedidoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDetallePedido", new { id = detallePedido.PedidoId }, detallePedido);
        }

        // DELETE: api/DetallesPedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallePedido(int id)
        {
            if (_context.DetallesPedidos == null)
            {
                return NotFound();
            }
            var detallePedido = await _context.DetallesPedidos.FindAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            _context.DetallesPedidos.Remove(detallePedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetallePedidoExists(int id)
        {
            return (_context.DetallesPedidos?.Any(e => e.PedidoId == id)).GetValueOrDefault();
        }
    }
}
