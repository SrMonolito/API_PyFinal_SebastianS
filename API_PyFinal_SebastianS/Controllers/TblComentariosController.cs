using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_PyFinal_SebastianS.Models;

namespace API_PyFinal_SebastianS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblComentariosController : ControllerBase
    {
        private readonly ProyectoProgra6Context _context;

        public TblComentariosController(ProyectoProgra6Context context)
        {
            _context = context;
        }

        // GET: api/TblComentarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblComentario>>> GetTblComentarios()
        {
            return await _context.TblComentarios.ToListAsync();
        }

        // GET: api/TblComentarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblComentario>> GetTblComentario(int id)
        {
            var tblComentario = await _context.TblComentarios.FindAsync(id);

            if (tblComentario == null)
            {
                return NotFound();
            }

            return tblComentario;
        }

        // PUT: api/TblComentarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblComentario(int id, TblComentario tblComentario)
        {
            if (id != tblComentario.ComentarioId)
            {
                return BadRequest();
            }

            _context.Entry(tblComentario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblComentarioExists(id))
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

        // POST: api/TblComentarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblComentario>> PostTblComentario(TblComentario tblComentario)
        {
            _context.TblComentarios.Add(tblComentario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblComentario", new { id = tblComentario.ComentarioId }, tblComentario);
        }

        // DELETE: api/TblComentarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblComentario(int id)
        {
            var tblComentario = await _context.TblComentarios.FindAsync(id);
            if (tblComentario == null)
            {
                return NotFound();
            }

            _context.TblComentarios.Remove(tblComentario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblComentarioExists(int id)
        {
            return _context.TblComentarios.Any(e => e.ComentarioId == id);
        }
    }
}
