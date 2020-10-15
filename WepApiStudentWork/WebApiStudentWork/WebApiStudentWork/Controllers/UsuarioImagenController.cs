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
    public class UsuarioImagenController : ControllerBase
    {
        private readonly StudentWorkContext _context;

        public UsuarioImagenController(StudentWorkContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioImagen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioImagen>>> GetUsuarioImagenes()
        {
            return await _context.UsuarioImagenes.ToListAsync();
        }

        //// GET: api/UsuarioImagen/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<UsuarioImagen>> GetUsuarioImagen(int id)
        //{
        //    var usuarioImagen = await _context.UsuarioImagenes.FindAsync(id);

        //    if (usuarioImagen == null)
        //    {
        //        return NotFound();
        //    }

        //    return usuarioImagen;
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioImagen>> GetUsuarioImagenById(int id)
        {
            var usuarioImagen = await _context.UsuarioImagenes.FirstOrDefaultAsync(x => x.usuario_Id == id);

            if (usuarioImagen == null)
            {
                return NotFound();
            }

            return usuarioImagen;
        }

        // PUT: api/UsuarioImagen/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioImagen(int id, UsuarioImagen usuarioImagen)
        {
            if (id != usuarioImagen.usuarioImagenId)
            {
                return BadRequest();
            }

            _context.Entry(usuarioImagen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioImagenExists(id))
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

        // POST: api/UsuarioImagen
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UsuarioImagen>> PostUsuarioImagen(UsuarioImagen usuarioImagen)
        {
            _context.UsuarioImagenes.Add(usuarioImagen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioImagenById", new { id = usuarioImagen.usuarioImagenId }, usuarioImagen);
        }

        // DELETE: api/UsuarioImagen/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioImagen>> DeleteUsuarioImagen(int id)
        {
            var usuarioImagen = await _context.UsuarioImagenes.FindAsync(id);
            if (usuarioImagen == null)
            {
                return NotFound();
            }

            _context.UsuarioImagenes.Remove(usuarioImagen);
            await _context.SaveChangesAsync();

            return usuarioImagen;
        }

        private bool UsuarioImagenExists(int id)
        {
            return _context.UsuarioImagenes.Any(e => e.usuarioImagenId == id);
        }
    }
}
