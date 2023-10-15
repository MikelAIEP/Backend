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
    public class ModalidadTrabajoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ModalidadTrabajoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ModalidadTrabajoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModalidadTrabajo>>> GetModalidadTrabajos()
        {
          if (_context.ModalidadTrabajos == null)
          {
              return NotFound();
          }
            return await _context.ModalidadTrabajos.ToListAsync();
        }

        // GET: api/ModalidadTrabajoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModalidadTrabajo>> GetModalidadTrabajo(int id)
        {
          if (_context.ModalidadTrabajos == null)
          {
              return NotFound();
          }
            var modalidadTrabajo = await _context.ModalidadTrabajos.FindAsync(id);

            if (modalidadTrabajo == null)
            {
                return NotFound();
            }

            return modalidadTrabajo;
        }

        // PUT: api/ModalidadTrabajoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModalidadTrabajo(int id, ModalidadTrabajo modalidadTrabajo)
        {
            if (id != modalidadTrabajo.ModalidadTrabajoId)
            {
                return BadRequest();
            }

            _context.Entry(modalidadTrabajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModalidadTrabajoExists(id))
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

        // POST: api/ModalidadTrabajoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModalidadTrabajo>> PostModalidadTrabajo(ModalidadTrabajo modalidadTrabajo)
        {
          if (_context.ModalidadTrabajos == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ModalidadTrabajos'  is null.");
          }
            _context.ModalidadTrabajos.Add(modalidadTrabajo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModalidadTrabajo", new { id = modalidadTrabajo.ModalidadTrabajoId }, modalidadTrabajo);
        }

        // DELETE: api/ModalidadTrabajoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModalidadTrabajo(int id)
        {
            if (_context.ModalidadTrabajos == null)
            {
                return NotFound();
            }
            var modalidadTrabajo = await _context.ModalidadTrabajos.FindAsync(id);
            if (modalidadTrabajo == null)
            {
                return NotFound();
            }

            _context.ModalidadTrabajos.Remove(modalidadTrabajo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModalidadTrabajoExists(int id)
        {
            return (_context.ModalidadTrabajos?.Any(e => e.ModalidadTrabajoId == id)).GetValueOrDefault();
        }
    }
}
