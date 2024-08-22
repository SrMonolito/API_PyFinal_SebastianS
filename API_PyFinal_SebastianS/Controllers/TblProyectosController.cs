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
    public class TblProyectosController : ControllerBase
    {
        private readonly ProyectoProgra6Context _context;

        public TblProyectosController(ProyectoProgra6Context context)
        {
            _context = context;
        }

        // GET: api/TblProyectos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblProyecto>>> GetTblProyectos()
        {
            return await _context.TblProyectos.ToListAsync();
        }

        // GET: api/TblProyectos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblProyecto>> GetTblProyecto(int id)
        {
            var tblProyecto = await _context.TblProyectos.FindAsync(id);

            if (tblProyecto == null)
            {
                return NotFound();
            }

            return tblProyecto;
        }

        // PUT: api/TblProyectos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblProyecto(int id, TblProyecto tblProyecto)
        {
            if (id != tblProyecto.ProyectoId)
            {
                return BadRequest();
            }

            _context.Entry(tblProyecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProyectoExists(id))
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

        // POST: api/TblProyectos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblProyecto>> PostTblProyecto(TblProyecto tblProyecto)
        {
            _context.TblProyectos.Add(tblProyecto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblProyecto", new { id = tblProyecto.ProyectoId }, tblProyecto);
        }

        // DELETE: api/TblProyectos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblProyecto(int id)
        {
            var tblProyecto = await _context.TblProyectos.FindAsync(id);
            if (tblProyecto == null)
            {
                return NotFound();
            }

            _context.TblProyectos.Remove(tblProyecto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblProyectoExists(int id)
        {
            return _context.TblProyectos.Any(e => e.ProyectoId == id);
        }
    }
}
