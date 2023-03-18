using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FISSUP23.Database.Models;

namespace FISSUP23.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilKollektionsController : ControllerBase
    {
        private readonly SsisGenericReadContext _context;

        public FilKollektionsController(SsisGenericReadContext context)
        {
            _context = context;
        }

        // GET: api/FilKollektions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilKollektion>>> GetFilKollektions()
        {
          if (_context.FilKollektions == null)
          {
              return NotFound();
          }
            return await _context.FilKollektions.ToListAsync();
        }
        [HttpGet("getByOverforing/{id}")]
        public async Task<ActionResult<IEnumerable<FilKollektion>>> GetByOverforing(int id)
        {
            if (_context.FilKollektions == null)
            {
                return NotFound();
            }
            var filKollektion = await _context.FilKollektions.Where(x => x.OverforingId == id).ToListAsync();

            if (filKollektion == null)
            {
                return NotFound();
            }

            return filKollektion;
        }

        // GET: api/FilKollektions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilKollektion>> GetFilKollektion(int id)
        {
          if (_context.FilKollektions == null)
          {
              return NotFound();
          }
            var filKollektion = await _context.FilKollektions.FindAsync(id);

            if (filKollektion == null)
            {
                return NotFound();
            }

            return filKollektion;
        }

        // PUT: api/FilKollektions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilKollektion(int id, FilKollektion filKollektion)
        {
            if (id != filKollektion.Id)
            {
                return BadRequest();
            }

            _context.Entry(filKollektion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilKollektionExists(id))
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

        // POST: api/FilKollektions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilKollektion>> PostFilKollektion(FilKollektion filKollektion)
        {
          if (_context.FilKollektions == null)
          {
              return Problem("Entity set 'SsisGenericReadContext.FilKollektions'  is null.");
          }
            _context.FilKollektions.Add(filKollektion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilKollektion", new { id = filKollektion.Id }, filKollektion);
        }

        // DELETE: api/FilKollektions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilKollektion(int id)
        {
            if (_context.FilKollektions == null)
            {
                return NotFound();
            }
            var filKollektion = await _context.FilKollektions.FindAsync(id);
            if (filKollektion == null)
            {
                return NotFound();
            }

            _context.FilKollektions.Remove(filKollektion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilKollektionExists(int id)
        {
            return (_context.FilKollektions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
