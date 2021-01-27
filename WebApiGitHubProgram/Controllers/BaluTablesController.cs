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
    public class BaluTablesController : ControllerBase
    {
        private readonly WebApiGitHubProgramContext _context;

        public BaluTablesController(WebApiGitHubProgramContext context)
        {
            _context = context;
        }

        // GET: api/BaluTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaluTables>>> GetBaluTables()
        {
            return await _context.BaluTables.ToListAsync();
        }

        // GET: api/BaluTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaluTables>> GetBaluTables(int id)
        {
            var baluTables = await _context.BaluTables.FindAsync(id);

            if (baluTables == null)
            {
                return NotFound();
            }

            return baluTables;
        }

        // PUT: api/BaluTables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaluTables(int id, BaluTables baluTables)
        {
            if (id != baluTables.StdId)
            {
                return BadRequest();
            }

            _context.Entry(baluTables).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaluTablesExists(id))
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

        // POST: api/BaluTables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BaluTables>> PostBaluTables(BaluTables baluTables)
        {
            _context.BaluTables.Add(baluTables);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaluTables", new { id = baluTables.StdId }, baluTables);
        }

        // DELETE: api/BaluTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaluTables>> DeleteBaluTables(int id)
        {
            var baluTables = await _context.BaluTables.FindAsync(id);
            if (baluTables == null)
            {
                return NotFound();
            }

            _context.BaluTables.Remove(baluTables);
            await _context.SaveChangesAsync();

            return baluTables;
        }

        private bool BaluTablesExists(int id)
        {
            return _context.BaluTables.Any(e => e.StdId == id);
        }
    }
}
