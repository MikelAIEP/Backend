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
    public class ComunaTrabajoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComunaTrabajoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ComunaTrabajoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComunaTrabajo>>> GetComunasTrabajo()
        {
          if (_context.ComunasTrabajo == null)
          {
              return NotFound();
          }
            return await _context.ComunasTrabajo.ToListAsync();
        }

        // GET: api/ComunaTrabajoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComunaTrabajo>> GetComunaTrabajo(int id)
        {
          if (_context.ComunasTrabajo == null)
          {
              return NotFound();
          }
            var comunaTrabajo = await _context.ComunasTrabajo.FindAsync(id);

            if (comunaTrabajo == null)
            {
                return NotFound();
            }

            return comunaTrabajo;
        }

        // PUT: api/ComunaTrabajoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComunaTrabajo(int id, ComunaTrabajo comunaTrabajo)
        {
            if (id != comunaTrabajo.ComunaTrabajoId)
            {
                return BadRequest();
            }

            _context.Entry(comunaTrabajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComunaTrabajoExists(id))
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

        // POST: api/ComunaTrabajoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComunaTrabajo>> PostComunaTrabajo(ComunaTrabajo comunaTrabajo)
        {
          if (_context.ComunasTrabajo == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ComunasTrabajo'  is null.");
          }
            _context.ComunasTrabajo.Add(comunaTrabajo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComunaTrabajo", new { id = comunaTrabajo.ComunaTrabajoId }, comunaTrabajo);
        }

        // DELETE: api/ComunaTrabajoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComunaTrabajo(int id)
        {
            if (_context.ComunasTrabajo == null)
            {
                return NotFound();
            }
            var comunaTrabajo = await _context.ComunasTrabajo.FindAsync(id);
            if (comunaTrabajo == null)
            {
                return NotFound();
            }

            _context.ComunasTrabajo.Remove(comunaTrabajo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComunaTrabajoExists(int id)
        {
            return (_context.ComunasTrabajo?.Any(e => e.ComunaTrabajoId == id)).GetValueOrDefault();
        }
    }
}
