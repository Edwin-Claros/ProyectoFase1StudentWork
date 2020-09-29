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
    public class FormacionController : ControllerBase
    {
        private readonly StudentWorkContext _context;

        public FormacionController(StudentWorkContext context)
        {
            _context = context;
        }

        // GET: api/Formacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Formacion>>> GetFormaciones()
        {
            return await _context.Formaciones.ToListAsync();
        }

        //// GET: api/Formacion/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Formacion>> GetFormacion(int id)
        //{
        //    var formacion = await _context.Formaciones.FindAsync(id);

        //    if (formacion == null)
        //    {
        //        return NotFound();
        //    }

        //    return formacion;
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Formacion>>> GetFormacionById(int id)
        {
            var formacion = await _context.Formaciones.Where(x => x.usuario_Id == id).ToListAsync();

            if (formacion == null)
            {
                return NotFound();
            }

            return formacion;
        }

        // PUT: api/Formacion/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormacion(int id, Formacion formacion)
        {
            if (id != formacion.formacionId)
            {
                return BadRequest();
            }

            _context.Entry(formacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormacionExists(id))
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

        // POST: api/Formacion
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Formacion>> PostFormacion(Formacion formacion)
        {
            _context.Formaciones.Add(formacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormacionById", new { id = formacion.formacionId }, formacion);
        }

        // DELETE: api/Formacion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Formacion>> DeleteFormacion(int id)
        {
            var formacion = await _context.Formaciones.FindAsync(id);
            if (formacion == null)
            {
                return NotFound();
            }

            _context.Formaciones.Remove(formacion);
            await _context.SaveChangesAsync();

            return formacion;
        }

        private bool FormacionExists(int id)
        {
            return _context.Formaciones.Any(e => e.formacionId == id);
        }
    }
}
