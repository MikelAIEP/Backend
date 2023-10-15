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
    public class ComunaResidenciasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComunaResidenciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ComunaResidencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComunaResidencia>>> GetComunasResidencia()
        {
          if (_context.ComunasResidencia == null)
          {
              return NotFound();
          }
            return await _context.ComunasResidencia.ToListAsync();
        }

        // GET: api/ComunaResidencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComunaResidencia>> GetComunaResidencia(int id)
        {
          if (_context.ComunasResidencia == null)
          {
              return NotFound();
          }
            var comunaResidencia = await _context.ComunasResidencia.FindAsync(id);

            if (comunaResidencia == null)
            {
                return NotFound();
            }

            return comunaResidencia;
        }

        // PUT: api/ComunaResidencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComunaResidencia(int id, ComunaResidencia comunaResidencia)
        {
            if (id != comunaResidencia.ComunaResidenciaId)
            {
                return BadRequest();
            }

            _context.Entry(comunaResidencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComunaResidenciaExists(id))
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

        // POST: api/ComunaResidencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComunaResidencia>> PostComunaResidencia(ComunaResidencia comunaResidencia)
        {
          if (_context.ComunasResidencia == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ComunasResidencia'  is null.");
          }
            _context.ComunasResidencia.Add(comunaResidencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComunaResidencia", new { id = comunaResidencia.ComunaResidenciaId }, comunaResidencia);
        }

        // DELETE: api/ComunaResidencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComunaResidencia(int id)
        {
            if (_context.ComunasResidencia == null)
            {
                return NotFound();
            }
            var comunaResidencia = await _context.ComunasResidencia.FindAsync(id);
            if (comunaResidencia == null)
            {
                return NotFound();
            }

            _context.ComunasResidencia.Remove(comunaResidencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComunaResidenciaExists(int id)
        {
            return (_context.ComunasResidencia?.Any(e => e.ComunaResidenciaId == id)).GetValueOrDefault();
        }
    }
}
