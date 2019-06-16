using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using caseEngSoftApi.Models;

namespace caseEngSoftApi.Controllers
{
    [Route("api/caseEngSoft")]
    [ApiController]
    public class caseEngSoftController : ControllerBase
    {
        private readonly caseEngSoftContext _context;

        public caseEngSoftController(caseEngSoftContext context)
        {
            _context = context;

            if (_context.caseEngSoftItems.Count() == 0)
            {
                // Create a new caseEngSoftItem if collection is empty,
                // which means you can't delete all caseEngSoftItems.
                _context.caseEngSoftItems.Add(new caseEngSoftItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        // GET: api/caseEngSoft
        [HttpGet]
        public async Task<ActionResult<IEnumerable<caseEngSoftItem>>> GetcaseEngSoftItems()
        {
            return await _context.caseEngSoftItems.ToListAsync();
        }

        // GET: api/caseEngSoft/5
        [HttpGet("{id}")]
        public async Task<ActionResult<caseEngSoftItem>> GetcaseEngSoftItem(long id)
        {
            var caseEngSoftItem = await _context.caseEngSoftItems.FindAsync(id);

            if (caseEngSoftItem == null)
            {
                return NotFound();
            }

            return caseEngSoftItem;
        }

        // POST: api/caseEngSoft
        [HttpPost]
        public async Task<ActionResult<caseEngSoftItem>> PostcaseEngSoftItem(caseEngSoftItem item)
        {
            _context.caseEngSoftItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetcaseEngSoftItem), new { id = item.Id }, item);
        }

        // PUT: api/caseEngSoft/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutcaseEngSoftItem(long id, caseEngSoftItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/caseEngSoft/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletecaseEngSoftItem(long id)
        {
            var caseEngSoftItem = await _context.caseEngSoftItems.FindAsync(id);

            if (caseEngSoftItem == null)
            {
                return NotFound();
            }

            _context.caseEngSoftItems.Remove(caseEngSoftItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}