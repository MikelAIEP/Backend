using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendEncuesta;
using BackendEncuesta.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using BackendEncuesta.DTO;

namespace BackendEncuesta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EncuestasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EncuestasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Encuestas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Encuesta>>> GetEncuestas()
        {
          if (_context.Encuestas == null)
          {
              return NotFound();
          }
            return await _context.Encuestas.ToListAsync();
        }

      

        // POST: api/Encuestas
        
        [HttpPost]
        public async Task<ActionResult<Encuesta>> PostEncuesta(EncuestaCreateDTO model)
        {
          if (_context.Encuestas == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Encuestas'  is null.");
          }
            var encuesta = new Encuesta
            {
                fecharealizacion = model.fecharealizacion,
                Pregunta1 = model.Pregunta1,
                Pregunta2 = model.Pregunta2,
                Pregunta3 = model.Pregunta3,
                Pregunta4 = model.Pregunta4,
                Pregunta5 = model.Pregunta5,
                Pregunta6 = model.Pregunta6,
                TipoTransporteId = model.TipoTransporteId,
                UsuarioId = model.UsuarioId
            };
            _context.Encuestas.Add(encuesta);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Encuestas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncuesta(int id)
        {
            if (_context.Encuestas == null)
            {
                return NotFound();
            }
            var encuesta = await _context.Encuestas.FindAsync(id);
            if (encuesta == null)
            {
                return NotFound();
            }

            _context.Encuestas.Remove(encuesta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EncuestaExists(int id)
        {
            return (_context.Encuestas?.Any(e => e.EncuestaId == id)).GetValueOrDefault();
        }
    }
}
