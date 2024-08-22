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
    public class TblRolsController : ControllerBase
    {
        private readonly ProyectoProgra6Context _context;

        public TblRolsController(ProyectoProgra6Context context)
        {
            _context = context;
        }

        // GET: api/TblRols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblRol>>> GetTblRols()
        {
            return await _context.TblRols.ToListAsync();
        }

        // GET: api/TblRols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblRol>> GetTblRol(int id)
        {
            var tblRol = await _context.TblRols.FindAsync(id);

            if (tblRol == null)
            {
                return NotFound();
            }

            return tblRol;
        }

        // PUT: api/TblRols/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblRol(int id, TblRol tblRol)
        {
            if (id != tblRol.RolId)
            {
                return BadRequest();
            }

            _context.Entry(tblRol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblRolExists(id))
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

        // POST: api/TblRols
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblRol>> PostTblRol(TblRol tblRol)
        {
            _context.TblRols.Add(tblRol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblRol", new { id = tblRol.RolId }, tblRol);
        }

        // DELETE: api/TblRols/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblRol(int id)
        {
            var tblRol = await _context.TblRols.FindAsync(id);
            if (tblRol == null)
            {
                return NotFound();
            }

            _context.TblRols.Remove(tblRol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblRolExists(int id)
        {
            return _context.TblRols.Any(e => e.RolId == id);
        }
    }
}
