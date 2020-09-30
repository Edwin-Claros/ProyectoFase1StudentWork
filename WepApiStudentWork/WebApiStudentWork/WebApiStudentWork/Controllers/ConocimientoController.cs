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
    public class ConocimientoController : ControllerBase
    {
        private readonly StudentWorkContext _context;

        public ConocimientoController(StudentWorkContext context)
        {
            _context = context;
        }

        // GET: api/Conocimiento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conocimiento>>> GetConocimientos()
        {
            return await _context.Conocimientos.ToListAsync();
        }

        //// GET: api/Conocimiento/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Conocimiento>> GetConocimiento(int id)
        //{
        //    var conocimiento = await _context.Conocimientos.FindAsync(id);

        //    if (conocimiento == null)
        //    {
        //        return NotFound();
        //    }

        //    return conocimiento;
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Conocimiento>>> GetConocimientoById(int id)
        {
            var conocimiento = await _context.Conocimientos.Where(x => x.usuario_Id == id).ToListAsync();

            if (conocimiento == null)
            {
                return NotFound();
            }

            return conocimiento;
        }

        // PUT: api/Conocimiento/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConocimiento(int id, Conocimiento conocimiento)
        {
            if (id != conocimiento.conocimientoId)
            {
                return BadRequest();
            }

            _context.Entry(conocimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConocimientoExists(id))
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

        // POST: api/Conocimiento
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Conocimiento>> PostConocimiento(Conocimiento conocimiento)
        {
            _context.Conocimientos.Add(conocimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConocimientoById", new { id = conocimiento.conocimientoId }, conocimiento);
        }

        // DELETE: api/Conocimiento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Conocimiento>> DeleteConocimiento(int id)
        {
            var conocimiento = await _context.Conocimientos.FindAsync(id);
            if (conocimiento == null)
            {
                return NotFound();
            }

            _context.Conocimientos.Remove(conocimiento);
            await _context.SaveChangesAsync();

            return conocimiento;
        }

        private bool ConocimientoExists(int id)
        {
            return _context.Conocimientos.Any(e => e.conocimientoId == id);
        }
    }
}
