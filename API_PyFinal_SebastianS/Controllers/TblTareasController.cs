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
    public class TblTareasController : ControllerBase
    {
        private readonly ProyectoProgra6Context _context;

        public TblTareasController(ProyectoProgra6Context context)
        {
            _context = context;
        }

        // GET: api/TblTareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblTarea>>> GetTblTareas()
        {
            return await _context.TblTareas.ToListAsync();
        }

        // GET: api/TblTareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblTarea>> GetTblTarea(int id)
        {
            var tblTarea = await _context.TblTareas.FindAsync(id);

            if (tblTarea == null)
            {
                return NotFound();
            }

            return tblTarea;
        }

        // PUT: api/TblTareas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTarea(int id, TblTarea tblTarea)
        {
            if (id != tblTarea.TareaId)
            {
                return BadRequest();
            }

            _context.Entry(tblTarea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTareaExists(id))
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

        // POST: api/TblTareas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblTarea>> PostTblTarea(TblTarea tblTarea)
        {
            _context.TblTareas.Add(tblTarea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblTarea", new { id = tblTarea.TareaId }, tblTarea);
        }

        // DELETE: api/TblTareas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblTarea(int id)
        {
            var tblTarea = await _context.TblTareas.FindAsync(id);
            if (tblTarea == null)
            {
                return NotFound();
            }

            _context.TblTareas.Remove(tblTarea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblTareaExists(int id)
        {
            return _context.TblTareas.Any(e => e.TareaId == id);
        }
    }
}
