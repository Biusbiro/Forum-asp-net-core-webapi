﻿using System;
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
    public class CathegoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CathegoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Cathegories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cathegory>>> GetCathegories()
        {
            return await _context.Cathegories.ToListAsync();
        }

        // GET: api/Cathegories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cathegory>> GetCathegory(int id)
        {
            var cathegory = await _context.Cathegories.FindAsync(id);

            if (cathegory == null)
            {
                return NotFound();
            }

            return cathegory;
        }

        // PUT: api/Cathegories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCathegory(int id, Cathegory cathegory)
        {
            if (id != cathegory.Id)
            {
                return BadRequest();
            }

            _context.Entry(cathegory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CathegoryExists(id))
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

        // POST: api/Cathegories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cathegory>> PostCathegory(Cathegory cathegory)
        {
            _context.Cathegories.Add(cathegory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCathegory", new { id = cathegory.Id }, cathegory);
        }

        // DELETE: api/Cathegories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCathegory(int id)
        {
            var cathegory = await _context.Cathegories.FindAsync(id);
            if (cathegory == null)
            {
                return NotFound();
            }

            _context.Cathegories.Remove(cathegory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CathegoryExists(int id)
        {
            return _context.Cathegories.Any(e => e.Id == id);
        }
    }
}
