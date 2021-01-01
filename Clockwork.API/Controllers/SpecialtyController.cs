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
    public class SpecialtyController : ControllerBase
    {
        private readonly BaseDbContext _context;

        public SpecialtyController(BaseDbContext context)
        {
            _context = context;
        }

        [HttpGet("count")]
        [EnableCors("Permissive")]
        public async Task<ActionResult<int>> GetCount()
        {
            return await _context.Specialties.CountAsync();
        }
        [HttpGet]
        [EnableCors("Permissive")]
        public async Task<ActionResult<IEnumerable<Specialty>>> GetSpecialties()
        {
            return await _context.Specialties.ToListAsync();
        }
        [HttpGet("{page}/{page_size}")]
        [EnableCors("Permissive")]
        public async Task<ActionResult<IEnumerable<Specialty>>> GetSpecialties(int page, int page_size)
        {
            var p = page-1;
            return await _context.Specialties.Skip(p*page_size).Take(page_size).ToListAsync();
        }

        // GET: api/Specialty/5
        [HttpGet("{id}")]
        [EnableCors("Permissive")]
        public async Task<ActionResult<Specialty>> GetSpecialty(int id)
        {
            var specialty = await _context.Specialties.FindAsync(id);

            if (specialty == null)
            {
                return NotFound();
            }

            return specialty;
        }

        // PUT: api/Specialty/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{page}")]
        [EnableCors("Permissive")]
        public async Task<IActionResult> PutSpecialty(int id, Specialty specialty)
        {
            if (id != specialty.Id)
            {
                return BadRequest();
            }

            _context.Entry(specialty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialtyExists(id))
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

        // POST: api/Specialty
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [EnableCors("Permissive")]
        public async Task<ActionResult<Specialty>> PostSpecialty(Specialty specialty)
        {
            _context.Specialties.Add(specialty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecialty", new { id = specialty.Id }, specialty);
        }

        // DELETE: api/Specialty/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialty(int id)
        {
            var specialty = await _context.Specialties.FindAsync(id);
            if (specialty == null)
            {
                return NotFound();
            }

            _context.Specialties.Remove(specialty);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAllSpecialties()
        {
            _context.Specialties.RemoveRange(_context.Specialties);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpecialtyExists(int id)
        {
            return _context.Specialties.Any(e => e.Id == id);
        }
    }
}
