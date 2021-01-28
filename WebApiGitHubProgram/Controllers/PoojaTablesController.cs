using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiGitHubProgram.Data;

namespace WebApiGitHubProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoojaTablesController : ControllerBase
    {
        private readonly WebApiGitHubProgramContext _context;

        public PoojaTablesController(WebApiGitHubProgramContext context)
        {
            _context = context;
        }

        // GET: api/PoojaTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PoojaTable>>> GetPoojaTable()
        {
            return await _context.PoojaTable.ToListAsync();
        }

        // GET: api/PoojaTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PoojaTable>> GetPoojaTable(int id)
        {
            var poojaTable = await _context.PoojaTable.FindAsync(id);

            if (poojaTable == null)
            {
                return NotFound();
            }

            return poojaTable;
        }

        // PUT: api/PoojaTables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoojaTable(int id, PoojaTable poojaTable)
        {
            if (id != poojaTable.CustId)
            {
                return BadRequest();
            }

            _context.Entry(poojaTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoojaTableExists(id))
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

        // POST: api/PoojaTables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PoojaTable>> PostPoojaTable(PoojaTable poojaTable)
        {
            _context.PoojaTable.Add(poojaTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoojaTable", new { id = poojaTable.CustId }, poojaTable);
        }

        // DELETE: api/PoojaTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PoojaTable>> DeletePoojaTable(int id)
        {
            var poojaTable = await _context.PoojaTable.FindAsync(id);
            if (poojaTable == null)
            {
                return NotFound();
            }

            _context.PoojaTable.Remove(poojaTable);
            await _context.SaveChangesAsync();

            return poojaTable;
        }

        private bool PoojaTableExists(int id)
        {
            return _context.PoojaTable.Any(e => e.CustId == id);
        }
    }
}
