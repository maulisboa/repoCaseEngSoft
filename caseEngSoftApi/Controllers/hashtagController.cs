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
    [Route("api/hashtag")]
    [ApiController]
    public class hashtagController : ControllerBase
    {
        private readonly hashtagContext _context;

        public hashtagController(hashtagContext context)
        {
            _context = context;

            if (_context.hashtagItems.Count() == 0)
            {
                // Create a new caseEngSoftItem if collection is empty,
                // which means you can't delete all hashtagItems.
                List<hashtagDTO> hashtagList = new t_hashtag().Listar();
                _context.hashtagItems.AddRange(hashtagList);
                _context.SaveChanges();

                new t_log().Incluir("hashtagController", "_context.hashtagItems.Count() == 0", "INFO");

            }
        }

        // GET: api/hashtag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<hashtagDTO>>> GetHashtagItems()
        {

            new t_log().Incluir("[HttpGet]", "GetHashtagItems()", "INFO");

            return await _context.hashtagItems.ToListAsync();
        }

        // GET: api/hashtag/5
        [HttpGet("{id}")]
        public async Task<ActionResult<hashtagDTO>> GetHashtagItem(long id)
        {
           
            var hashtagItem = await _context.hashtagItems.FindAsync(id);

            if (hashtagItem == null)
            {
                return NotFound();
            }

            new t_log().Incluir("[HttpGet(\"{id}\")]", "GetHashtagItem(long " + id.ToString() + ")", "INFO");

            return hashtagItem;
        }

        // POST: api/hashtag
        [HttpPost]
        public async Task<ActionResult<hashtagDTO>> PostHashtagItem(hashtagDTO item)
        {
            item.id_hashtag = new t_hashtag().Incluir(item.hashtag_name);

            _context.hashtagItems.Add(item);
            _context.SaveChanges();

            new t_log().Incluir("[HttpPost]", "PostHashtagItem(hashtagDTO " + item.ToString() + ")", "INFO");

            return CreatedAtAction(nameof(GetHashtagItem), new { id = item.id_hashtag}, item);
        }

        // PUT: api/hashtag/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHashtagItem(long id, hashtagDTO item)
        {
            if (id != item.id_hashtag)
            {
                return BadRequest();
            }
            
            new t_hashtag().Alterar(id, item.hashtag_name);

            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            new t_log().Incluir("[HttpPut(\"{ id}\")]", "PutHashtagItem(long " + id.ToString() + ", hashtagDTO " + item.ToString() + ")", "INFO");

            return NoContent();
        }

        // DELETE: api/hashtag/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHashtagItem(long id)
        {
            var hashtagItem = await _context.hashtagItems.FindAsync(id);

            if (hashtagItem == null)
            {
                return NotFound();
            }

            new t_hashtag().Excluir(id);

            _context.hashtagItems.Remove(hashtagItem);
            _context.SaveChanges();
                        
            new t_log().Incluir("[HttpDelete(\"{ id}\")]", "DeleteHashtagItem(long " + id.ToString() + ")", "INFO");

            return NoContent();
        }
    }
}