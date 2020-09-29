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
    public class NivelEstudioController : ControllerBase
    {
        private readonly StudentWorkContext _context;

        public NivelEstudioController(StudentWorkContext context)
        {
            _context = context;
        }

        // GET: api/NivelEstudio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NivelEstudio>>> GetNivelEstudios()
        {
            return await _context.NivelEstudios.ToListAsync();
        }

        // GET: api/NivelEstudio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NivelEstudio>> GetNivelEstudio(int id)
        {
            var nivelEstudio = await _context.NivelEstudios.FindAsync(id);

            if (nivelEstudio == null)
            {
                return NotFound();
            }

            return nivelEstudio;
        }

        // PUT: api/NivelEstudio/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNivelEstudio(int id, NivelEstudio nivelEstudio)
        {
            if (id != nivelEstudio.nivelEstudioId)
            {
                return BadRequest();
            }

            _context.Entry(nivelEstudio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NivelEstudioExists(id))
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

        // POST: api/NivelEstudio
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NivelEstudio>> PostNivelEstudio(NivelEstudio nivelEstudio)
        {
            _context.NivelEstudios.Add(nivelEstudio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNivelEstudio", new { id = nivelEstudio.nivelEstudioId }, nivelEstudio);
        }

        // DELETE: api/NivelEstudio/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NivelEstudio>> DeleteNivelEstudio(int id)
        {
            var nivelEstudio = await _context.NivelEstudios.FindAsync(id);
            if (nivelEstudio == null)
            {
                return NotFound();
            }

            _context.NivelEstudios.Remove(nivelEstudio);
            await _context.SaveChangesAsync();

            return nivelEstudio;
        }

        private bool NivelEstudioExists(int id)
        {
            return _context.NivelEstudios.Any(e => e.nivelEstudioId == id);
        }
    }
}
