using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clockwork.Models;
using tephraAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace tephraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AugmentController : ControllerBase
    {
        private readonly BaseDbContext _context;

        public AugmentController(BaseDbContext context)
        {
            _context = context;
        }

        // GET: api/Augment
        [HttpGet]
        [EnableCors("Permissive")]
        public async Task<ActionResult<IEnumerable<Augment>>> GetAugments()
        {
            return await _context.Augments.ToListAsync();
        }

        // GET: api/Augment/5
        [HttpGet("{id}")]
        [EnableCors("Permissive")]
        public async Task<ActionResult<Augment>> GetAugment(int id)
        {
            var augment = await _context.Augments.FindAsync(id);

            if (augment == null)
            {
                return NotFound();
            }

            return augment;
        }

        // PUT: api/Augment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [EnableCors("Permissive")]
        public async Task<IActionResult> PutAugment(int id, Augment augment)
        {
            if (id != augment.Id)
            {
                return BadRequest();
            }

            _context.Entry(augment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AugmentExists(id))
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

        // POST: api/Augment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [EnableCors("Permissive")]
        public async Task<ActionResult<Augment>> PostAugment(Augment augment)
        {
            _context.Augments.Add(augment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAugment", new { id = augment.Id }, augment);
        }

        // DELETE: api/Augment/5
        [HttpDelete("{id}")]
        [EnableCors("Permissive")]
        public async Task<IActionResult> DeleteAugment(int id)
        {
            var augment = await _context.Augments.FindAsync(id);
            if (augment == null)
            {
                return NotFound();
            }

            _context.Augments.Remove(augment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AugmentExists(int id)
        {
            return _context.Augments.Any(e => e.Id == id);
        }
    }
}
