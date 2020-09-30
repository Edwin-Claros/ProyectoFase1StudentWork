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
    public class SituacionActualController : ControllerBase
    {
        private readonly StudentWorkContext _context;

        public SituacionActualController(StudentWorkContext context)
        {
            _context = context;
        }

        // GET: api/SituacionActual
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SituacionActual>>> GetSituacionActuales()
        {
            return await _context.SituacionActuales.ToListAsync();
        }

        // GET: api/SituacionActual/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SituacionActual>> GetSituacionActual(int id)
        {
            var situacionActual = await _context.SituacionActuales.FindAsync(id);

            if (situacionActual == null)
            {
                return NotFound();
            }

            return situacionActual;
        }

        // PUT: api/SituacionActual/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSituacionActual(int id, SituacionActual situacionActual)
        {
            if (id != situacionActual.situacionActualId)
            {
                return BadRequest();
            }

            _context.Entry(situacionActual).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SituacionActualExists(id))
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

        // POST: api/SituacionActual
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SituacionActual>> PostSituacionActual(SituacionActual situacionActual)
        {
            _context.SituacionActuales.Add(situacionActual);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSituacionActual", new { id = situacionActual.situacionActualId }, situacionActual);
        }

        // DELETE: api/SituacionActual/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SituacionActual>> DeleteSituacionActual(int id)
        {
            var situacionActual = await _context.SituacionActuales.FindAsync(id);
            if (situacionActual == null)
            {
                return NotFound();
            }

            _context.SituacionActuales.Remove(situacionActual);
            await _context.SaveChangesAsync();

            return situacionActual;
        }

        private bool SituacionActualExists(int id)
        {
            return _context.SituacionActuales.Any(e => e.situacionActualId == id);
        }
    }
}
