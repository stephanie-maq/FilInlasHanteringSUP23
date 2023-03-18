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
    public class FilsController : ControllerBase
    {
        private readonly SsisGenericReadContext _context;

        public FilsController(SsisGenericReadContext context)
        {
            _context = context;
        }

        // GET: api/Fils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fil>>> GetFils()
        {
          if (_context.Fils == null)
          {
              return NotFound();
          }
            return await _context.Fils.ToListAsync();
        }

        // GET: api/Fils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fil>> GetFil(int id)
        {
          if (_context.Fils == null)
          {
              return NotFound();
          }
            var fil = await _context.Fils.FindAsync(id);

            if (fil == null)
            {
                return NotFound();
            }

            return fil;
        }

        // PUT: api/Fils/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFil(int id, Fil fil)
        {
            if (id != fil.Id)
            {
                return BadRequest();
            }

            _context.Entry(fil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilExists(id))
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

        // POST: api/Fils
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fil>> PostFil(Fil fil)
        {
          if (_context.Fils == null)
          {
              return Problem("Entity set 'SsisGenericReadContext.Fils'  is null.");
          }
            _context.Fils.Add(fil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFil", new { id = fil.Id }, fil);
        }

        // DELETE: api/Fils/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFil(int id)
        {
            if (_context.Fils == null)
            {
                return NotFound();
            }
            var fil = await _context.Fils.FindAsync(id);
            if (fil == null)
            {
                return NotFound();
            }

            _context.Fils.Remove(fil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilExists(int id)
        {
            return (_context.Fils?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
