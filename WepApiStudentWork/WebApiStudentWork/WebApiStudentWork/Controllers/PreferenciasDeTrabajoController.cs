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
    public class PreferenciasDeTrabajoController : ControllerBase
    {
        private readonly StudentWorkContext _context;

        public PreferenciasDeTrabajoController(StudentWorkContext context)
        {
            _context = context;
        }

        // GET: api/PreferenciasDeTrabajo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreferenciasDeTrabajo>>> GetPreferenciasDeTrabajos()
        {
            return await _context.PreferenciasDeTrabajos.ToListAsync();
        }

        //// GET: api/PreferenciasDeTrabajo/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<PreferenciasDeTrabajo>> GetPreferenciasDeTrabajo(int id)
        //{
        //    var preferenciasDeTrabajo = await _context.PreferenciasDeTrabajos.FindAsync(id);

        //    if (preferenciasDeTrabajo == null)
        //    {
        //        return NotFound();
        //    }

        //    return preferenciasDeTrabajo;
        //}

        // GET: api/PreferenciasDeTrabajo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreferenciasDeTrabajo>> GetPreferenciasDeTrabajoById(int id)
        {
            var preferenciasDeTrabajo = await _context.PreferenciasDeTrabajos.FirstOrDefaultAsync(x => x.usuario_Id == id);

            if (preferenciasDeTrabajo == null)
            {
                return NotFound();
            }

            return preferenciasDeTrabajo;
        }

        // PUT: api/PreferenciasDeTrabajo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreferenciasDeTrabajo(int id, PreferenciasDeTrabajo preferenciasDeTrabajo)
        {
            if (id != preferenciasDeTrabajo.preferenciasDeTrabajoId)
            {
                return BadRequest();
            }

            _context.Entry(preferenciasDeTrabajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreferenciasDeTrabajoExists(id))
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

        // POST: api/PreferenciasDeTrabajo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PreferenciasDeTrabajo>> PostPreferenciasDeTrabajo(PreferenciasDeTrabajo preferenciasDeTrabajo)
        {
            _context.PreferenciasDeTrabajos.Add(preferenciasDeTrabajo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreferenciasDeTrabajoById", new { id = preferenciasDeTrabajo.preferenciasDeTrabajoId }, preferenciasDeTrabajo);
        }

        // DELETE: api/PreferenciasDeTrabajo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreferenciasDeTrabajo>> DeletePreferenciasDeTrabajo(int id)
        {
            var preferenciasDeTrabajo = await _context.PreferenciasDeTrabajos.FindAsync(id);
            if (preferenciasDeTrabajo == null)
            {
                return NotFound();
            }

            _context.PreferenciasDeTrabajos.Remove(preferenciasDeTrabajo);
            await _context.SaveChangesAsync();

            return preferenciasDeTrabajo;
        }

        private bool PreferenciasDeTrabajoExists(int id)
        {
            return _context.PreferenciasDeTrabajos.Any(e => e.preferenciasDeTrabajoId == id);
        }
    }
}
