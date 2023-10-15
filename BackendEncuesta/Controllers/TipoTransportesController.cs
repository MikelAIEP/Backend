using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendEncuesta;
using BackendEncuesta.Entities;

namespace BackendEncuesta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTransportesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoTransportesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoTransportes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoTransporte>>> GetTipoTransportes()
        {
          if (_context.TipoTransportes == null)
          {
              return NotFound();
          }
            return await _context.TipoTransportes.ToListAsync();
        }

        // GET: api/TipoTransportes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTransporte>> GetTipoTransporte(int id)
        {
          if (_context.TipoTransportes == null)
          {
              return NotFound();
          }
            var tipoTransporte = await _context.TipoTransportes.FindAsync(id);

            if (tipoTransporte == null)
            {
                return NotFound();
            }

            return tipoTransporte;
        }

        // PUT: api/TipoTransportes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoTransporte(int id, TipoTransporte tipoTransporte)
        {
            if (id != tipoTransporte.TipoTransporteId)
            {
                return BadRequest();
            }

            _context.Entry(tipoTransporte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoTransporteExists(id))
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

        // POST: api/TipoTransportes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoTransporte>> PostTipoTransporte(TipoTransporte tipoTransporte)
        {
          if (_context.TipoTransportes == null)
          {
              return Problem("Entity set 'ApplicationDbContext.TipoTransportes'  is null.");
          }
            _context.TipoTransportes.Add(tipoTransporte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoTransporte", new { id = tipoTransporte.TipoTransporteId }, tipoTransporte);
        }

        // DELETE: api/TipoTransportes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoTransporte(int id)
        {
            if (_context.TipoTransportes == null)
            {
                return NotFound();
            }
            var tipoTransporte = await _context.TipoTransportes.FindAsync(id);
            if (tipoTransporte == null)
            {
                return NotFound();
            }

            _context.TipoTransportes.Remove(tipoTransporte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoTransporteExists(int id)
        {
            return (_context.TipoTransportes?.Any(e => e.TipoTransporteId == id)).GetValueOrDefault();
        }
    }
}
