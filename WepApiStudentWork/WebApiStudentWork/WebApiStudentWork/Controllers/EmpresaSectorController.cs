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
    public class EmpresaSectorController : ControllerBase
    {
        private readonly StudentWorkContext _context;

        public EmpresaSectorController(StudentWorkContext context)
        {
            _context = context;
        }

        // GET: api/EmpresaSector
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaSector>>> GetEmpresaSectores()
        {
            return await _context.EmpresaSectores.ToListAsync();
        }

        // GET: api/EmpresaSector/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaSector>> GetEmpresaSector(int id)
        {
            var empresaSector = await _context.EmpresaSectores.FindAsync(id);

            if (empresaSector == null)
            {
                return NotFound();
            }

            return empresaSector;
        }

        // PUT: api/EmpresaSector/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresaSector(int id, EmpresaSector empresaSector)
        {
            if (id != empresaSector.empresaSectorId)
            {
                return BadRequest();
            }

            _context.Entry(empresaSector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaSectorExists(id))
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

        // POST: api/EmpresaSector
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmpresaSector>> PostEmpresaSector(EmpresaSector empresaSector)
        {
            _context.EmpresaSectores.Add(empresaSector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpresaSector", new { id = empresaSector.empresaSectorId }, empresaSector);
        }

        // DELETE: api/EmpresaSector/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpresaSector>> DeleteEmpresaSector(int id)
        {
            var empresaSector = await _context.EmpresaSectores.FindAsync(id);
            if (empresaSector == null)
            {
                return NotFound();
            }

            _context.EmpresaSectores.Remove(empresaSector);
            await _context.SaveChangesAsync();

            return empresaSector;
        }

        private bool EmpresaSectorExists(int id)
        {
            return _context.EmpresaSectores.Any(e => e.empresaSectorId == id);
        }
    }
}
