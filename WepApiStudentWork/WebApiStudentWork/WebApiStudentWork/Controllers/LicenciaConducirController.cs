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
    public class LicenciaConducirController : ControllerBase
    {
        private readonly StudentWorkContext _context;

        public LicenciaConducirController(StudentWorkContext context)
        {
            _context = context;
        }

        // GET: api/LicenciaConducir
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LicenciaConducir>>> GetLicenciasConducir()
        {
            return await _context.LicenciasConducir.ToListAsync();
        }

        // GET: api/LicenciaConducir/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LicenciaConducir>> GetLicenciaConducir(int id)
        {
            var licenciaConducir = await _context.LicenciasConducir.FindAsync(id);

            if (licenciaConducir == null)
            {
                return NotFound();
            }

            return licenciaConducir;
        }

        // PUT: api/LicenciaConducir/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLicenciaConducir(int id, LicenciaConducir licenciaConducir)
        {
            if (id != licenciaConducir.licenciaConducirId)
            {
                return BadRequest();
            }

            _context.Entry(licenciaConducir).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LicenciaConducirExists(id))
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

        // POST: api/LicenciaConducir
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LicenciaConducir>> PostLicenciaConducir(LicenciaConducir licenciaConducir)
        {
            _context.LicenciasConducir.Add(licenciaConducir);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLicenciaConducir", new { id = licenciaConducir.licenciaConducirId }, licenciaConducir);
        }

        // DELETE: api/LicenciaConducir/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LicenciaConducir>> DeleteLicenciaConducir(int id)
        {
            var licenciaConducir = await _context.LicenciasConducir.FindAsync(id);
            if (licenciaConducir == null)
            {
                return NotFound();
            }

            _context.LicenciasConducir.Remove(licenciaConducir);
            await _context.SaveChangesAsync();

            return licenciaConducir;
        }

        private bool LicenciaConducirExists(int id)
        {
            return _context.LicenciasConducir.Any(e => e.licenciaConducirId == id);
        }
    }
}
