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
    public class PaisCiudadController : ControllerBase
    {
        private readonly StudentWorkContext _context;

        public PaisCiudadController(StudentWorkContext context)
        {
            _context = context;
        }

        // GET: api/PaisCiudad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisCiudad>>> GetPaisCiudades()
        {
            return await _context.PaisCiudades.ToListAsync();
        }

        // GET: api/PaisCiudad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaisCiudad>> GetPaisCiudad(int id)
        {
            var paisCiudad = await _context.PaisCiudades.FindAsync(id);

            if (paisCiudad == null)
            {
                return NotFound();
            }

            return paisCiudad;
        }

        // PUT: api/PaisCiudad/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaisCiudad(int id, PaisCiudad paisCiudad)
        {
            if (id != paisCiudad.paisCiudadId)
            {
                return BadRequest();
            }

            _context.Entry(paisCiudad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisCiudadExists(id))
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

        // POST: api/PaisCiudad
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PaisCiudad>> PostPaisCiudad(PaisCiudad paisCiudad)
        {
            _context.PaisCiudades.Add(paisCiudad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaisCiudad", new { id = paisCiudad.paisCiudadId }, paisCiudad);
        }

        // DELETE: api/PaisCiudad/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaisCiudad>> DeletePaisCiudad(int id)
        {
            var paisCiudad = await _context.PaisCiudades.FindAsync(id);
            if (paisCiudad == null)
            {
                return NotFound();
            }

            _context.PaisCiudades.Remove(paisCiudad);
            await _context.SaveChangesAsync();

            return paisCiudad;
        }

        private bool PaisCiudadExists(int id)
        {
            return _context.PaisCiudades.Any(e => e.paisCiudadId == id);
        }
    }
}
