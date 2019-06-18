using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using caseEngSoftApi.Models;
using caseEngSoftApi.Database;
using System;

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
                _context.caseEngSoftItems.Add(new caseEngSoftItem { Name = "hashtagName" });
                _context.SaveChanges();

                try
                {
                    int id_log = new t_log().Incluir("caseEngSoftController", "_context.caseEngSoftItems.Count() == 0", "INFO");
                }
                catch (Exception ex) { throw ex; }
            }
        }

        // GET: api/caseEngSoft
        [HttpGet]
        public async Task<ActionResult<IEnumerable<caseEngSoftItem>>> GetcaseEngSoftItems()
        {
            try
            {
                int id_log = new t_log().Incluir("[HttpGet]", "GetcaseEngSoftItems()", "INFO");
            }
            catch (Exception ex) { throw ex; }

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

            try
            {
                int id_log = new t_log().Incluir("[HttpGet(\"{id}\")]", "GetcaseEngSoftItem(long " + id.ToString() + ")", "INFO");
            }
            catch (Exception ex) { throw ex; }

            return caseEngSoftItem;
        }

        // POST: api/caseEngSoft
        [HttpPost]
        public async Task<ActionResult<caseEngSoftItem>> PostcaseEngSoftItem(caseEngSoftItem item)
        {
            _context.caseEngSoftItems.Add(item);
            await _context.SaveChangesAsync();

            try
            {
                int id_log = new t_log().Incluir("[HttpPost]", "PostcaseEngSoftItem(caseEngSoftItem " + item.ToString() + ")", "INFO");
            }
            catch (Exception ex) { throw ex; }

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

            try
            {
                int id_log = new t_log().Incluir("[HttpPut(\"{ id}\")]", "PutcaseEngSoftItem(long " + id.ToString() + ", caseEngSoftItem " + item.ToString() + ")", "INFO");
            }
            catch (Exception ex) { throw ex; }

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


            try
            {
                int id_log = new t_log().Incluir("[HttpDelete(\"{ id}\")]", "DeletecaseEngSoftItem(long " + id.ToString() + ")", "INFO");
            }
            catch (Exception ex) { throw ex; }

            return NoContent();
        }
    }
}