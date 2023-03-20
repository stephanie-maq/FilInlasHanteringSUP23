using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FISSUP23.Database.Models;
using FISSUP23.Server.Services.Interface;

namespace FISSUP23.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OverforingsController : ControllerBase
    {
        private readonly IOverforingService _service;


        public OverforingsController(IOverforingService service)
        {
            _service = service;
        }

        // GET: api/Overforings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Overforing>>> GetOverforings()
        {

            return await _service.GetOverforingar();
        }

        //GET: api/Overforings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Overforing>> GetOverforing(int id)
        {
            return await _service.GetByID(id);
        }



        //PUT: api/Overforings/5
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}")]
        public async Task<ActionResult<Overforing>> PutOverforing(int id)
        {
            try
            {
                await _service.Update(id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
    }
}

//// POST: api/Overforings
//// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//[HttpPost]
//public async Task<ActionResult<Overforing>> PostOverforing(Overforing overforing)
//{

//if (_context.Overforings == null)
//{
//    return Problem("Entity set 'SsisGenericReadContext.Overforings'  is null.");
//}
//  _context.Overforings.Add(overforing);
//  await _context.SaveChangesAsync();

//  return CreatedAtAction("GetOverforing", new { id = overforing.Id }, overforing);


// DELETE: api/Overforings/5
//[HttpDelete("{id}")]
//public async Task<IActionResult> DeleteOverforing(int id)
//{
//    if (_context.Overforings == null)
//    {
//        return NotFound();
//    }
//    var overforing = await _context.Overforings.FindAsync(id);
//    if (overforing == null)
//    {
//        return NotFound();
//    }

//    _context.Overforings.Remove(overforing);
//    await _context.SaveChangesAsync();

//    return NoContent();
//}



