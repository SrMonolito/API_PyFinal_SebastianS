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
    public class TblMiembrosTareasController : ControllerBase
    {
        private readonly ProyectoProgra6Context _context;

        public TblMiembrosTareasController(ProyectoProgra6Context context)
        {
            _context = context;
        }

        // GET: api/TblMiembrosTareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblMiembrosTarea>>> GetTblMiembrosTareas()
        {
            return await _context.TblMiembrosTareas.ToListAsync();
        }

        // GET: api/TblMiembrosTareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblMiembrosTarea>> GetTblMiembrosTarea(int id)
        {
            var tblMiembrosTarea = await _context.TblMiembrosTareas.FindAsync(id);

            if (tblMiembrosTarea == null)
            {
                return NotFound();
            }

            return tblMiembrosTarea;
        }

        // PUT: api/TblMiembrosTareas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblMiembrosTarea(int id, TblMiembrosTarea tblMiembrosTarea)
        {
            if (id != tblMiembrosTarea.MiembTareaId)
            {
                return BadRequest();
            }

            _context.Entry(tblMiembrosTarea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMiembrosTareaExists(id))
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

        // POST: api/TblMiembrosTareas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblMiembrosTarea>> PostTblMiembrosTarea(TblMiembrosTarea tblMiembrosTarea)
        {
            _context.TblMiembrosTareas.Add(tblMiembrosTarea);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblMiembrosTareaExists(tblMiembrosTarea.MiembTareaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblMiembrosTarea", new { id = tblMiembrosTarea.MiembTareaId }, tblMiembrosTarea);
        }

        // DELETE: api/TblMiembrosTareas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblMiembrosTarea(int id)
        {
            var tblMiembrosTarea = await _context.TblMiembrosTareas.FindAsync(id);
            if (tblMiembrosTarea == null)
            {
                return NotFound();
            }

            _context.TblMiembrosTareas.Remove(tblMiembrosTarea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblMiembrosTareaExists(int id)
        {
            return _context.TblMiembrosTareas.Any(e => e.MiembTareaId == id);
        }
    }
}
