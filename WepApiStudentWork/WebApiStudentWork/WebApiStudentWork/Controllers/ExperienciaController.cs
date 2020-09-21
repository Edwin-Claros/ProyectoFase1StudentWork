using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiStudentWork.DataContext;
using WebApiStudentWork.Models;

namespace WebApiStudentWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienciaController : ControllerBase
    {
        private readonly StudentWorkContext _context;

        public ExperienciaController(StudentWorkContext context)
        {
            _context = context;
        }

        // GET: api/Experiencia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experiencia>>> GetExperiencias()
        {
            return await _context.Experiencias.ToListAsync();
        }

        // GET: api/Experiencia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Experiencia>> GetExperiencia(int id)
        {
            var experiencia = await _context.Experiencias.FindAsync(id);

            if (experiencia == null)
            {
                return NotFound();
            }

            return experiencia;
        }

        // PUT: api/Experiencia/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperiencia(int id, Experiencia experiencia)
        {
            if (id != experiencia.experienciaId)
            {
                return BadRequest();
            }

            _context.Entry(experiencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienciaExists(id))
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

        // POST: api/Experiencia
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Experiencia>> PostExperiencia(Experiencia experiencia)
        {
            _context.Experiencias.Add(experiencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExperiencia", new { id = experiencia.experienciaId }, experiencia);
        }

        // DELETE: api/Experiencia/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Experiencia>> DeleteExperiencia(int id)
        {
            var experiencia = await _context.Experiencias.FindAsync(id);
            if (experiencia == null)
            {
                return NotFound();
            }

            _context.Experiencias.Remove(experiencia);
            await _context.SaveChangesAsync();

            return experiencia;
        }

        private bool ExperienciaExists(int id)
        {
            return _context.Experiencias.Any(e => e.experienciaId == id);
        }
    }
}
