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
    public class IdiomaController : ControllerBase
    {
        private readonly StudentWorkContext _context;

        public IdiomaController(StudentWorkContext context)
        {
            _context = context;
        }

        // GET: api/Idioma
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Idioma>>> GetIdiomas()
        {
            return await _context.Idiomas.ToListAsync();
        }

        // GET: api/Idioma/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Idioma>> GetIdioma(int id)
        {
            var idioma = await _context.Idiomas.FindAsync(id);

            if (idioma == null)
            {
                return NotFound();
            }

            return idioma;
        }

        // PUT: api/Idioma/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdioma(int id, Idioma idioma)
        {
            if (id != idioma.idiomaId)
            {
                return BadRequest();
            }

            _context.Entry(idioma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdiomaExists(id))
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

        // POST: api/Idioma
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Idioma>> PostIdioma(Idioma idioma)
        {
            _context.Idiomas.Add(idioma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIdioma", new { id = idioma.idiomaId }, idioma);
        }

        // DELETE: api/Idioma/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Idioma>> DeleteIdioma(int id)
        {
            var idioma = await _context.Idiomas.FindAsync(id);
            if (idioma == null)
            {
                return NotFound();
            }

            _context.Idiomas.Remove(idioma);
            await _context.SaveChangesAsync();

            return idioma;
        }

        private bool IdiomaExists(int id)
        {
            return _context.Idiomas.Any(e => e.idiomaId == id);
        }
    }
}
