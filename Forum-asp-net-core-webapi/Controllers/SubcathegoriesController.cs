using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Forum_asp_net_core_webapi.Data;
using Forum_asp_net_core_webapi.Models;

namespace Forum_asp_net_core_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcathegoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public SubcathegoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Subcathegories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subcathegory>>> GetSubcathegories()
        {
            return await _context.Subcathegories.ToListAsync();
        }

        // GET: api/Subcathegories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subcathegory>> GetSubcathegory(int id)
        {
            var subcathegory = await _context.Subcathegories.FindAsync(id);

            if (subcathegory == null)
            {
                return NotFound();
            }

            return subcathegory;
        }

        // PUT: api/Subcathegories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubcathegory(int id, Subcathegory subcathegory)
        {
            if (id != subcathegory.Id)
            {
                return BadRequest();
            }

            _context.Entry(subcathegory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubcathegoryExists(id))
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

        // POST: api/Subcathegories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subcathegory>> PostSubcathegory(Subcathegory subcathegory)
        {
            _context.Subcathegories.Add(subcathegory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubcathegory", new { id = subcathegory.Id }, subcathegory);
        }

        // DELETE: api/Subcathegories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubcathegory(int id)
        {
            var subcathegory = await _context.Subcathegories.FindAsync(id);
            if (subcathegory == null)
            {
                return NotFound();
            }

            _context.Subcathegories.Remove(subcathegory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubcathegoryExists(int id)
        {
            return _context.Subcathegories.Any(e => e.Id == id);
        }
    }
}
