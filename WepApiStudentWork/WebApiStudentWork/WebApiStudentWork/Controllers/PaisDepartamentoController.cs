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
    public class PaisDepartamentoController : ControllerBase
    {
        private readonly StudentWorkContext _context;

        public PaisDepartamentoController(StudentWorkContext context)
        {
            _context = context;
        }

        // GET: api/PaisDepartamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisDepartamento>>> GetPaisDepartamentos()
        {
            return await _context.PaisDepartamentos.ToListAsync();
        }

        // GET: api/PaisDepartamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaisDepartamento>> GetPaisDepartamento(int id)
        {
            var paisDepartamento = await _context.PaisDepartamentos.FindAsync(id);

            if (paisDepartamento == null)
            {
                return NotFound();
            }

            return paisDepartamento;
        }

        // PUT: api/PaisDepartamento/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaisDepartamento(int id, PaisDepartamento paisDepartamento)
        {
            if (id != paisDepartamento.paisDepartamentoId)
            {
                return BadRequest();
            }

            _context.Entry(paisDepartamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisDepartamentoExists(id))
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

        // POST: api/PaisDepartamento
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PaisDepartamento>> PostPaisDepartamento(PaisDepartamento paisDepartamento)
        {
            _context.PaisDepartamentos.Add(paisDepartamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaisDepartamento", new { id = paisDepartamento.paisDepartamentoId }, paisDepartamento);
        }

        // DELETE: api/PaisDepartamento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaisDepartamento>> DeletePaisDepartamento(int id)
        {
            var paisDepartamento = await _context.PaisDepartamentos.FindAsync(id);
            if (paisDepartamento == null)
            {
                return NotFound();
            }

            _context.PaisDepartamentos.Remove(paisDepartamento);
            await _context.SaveChangesAsync();

            return paisDepartamento;
        }

        private bool PaisDepartamentoExists(int id)
        {
            return _context.PaisDepartamentos.Any(e => e.paisDepartamentoId == id);
        }
    }
}
