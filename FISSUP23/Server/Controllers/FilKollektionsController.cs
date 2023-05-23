using Microsoft.AspNetCore.Mvc;
using FISSUP23.Database.Models;
using FISSUP23.Server.Services;

namespace FISSUP23.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilKollektionsController : ControllerBase
    {
        private IFilkollektionService _filkollektionService;

        public FilKollektionsController(IFilkollektionService service)
        {
            _filkollektionService = service;
        }

        // GET: api/FilKollektions
        [HttpGet]
         public async Task<ActionResult<IEnumerable<FilKollektion>>> GetFilKollektions()
         {
             return await _filkollektionService.GetFilkollektioner();
         }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<FilKollektion>> GetFilkollektionById(int id)
        {
            try
            {
                var ok = await _filkollektionService.GetById(id);
                return Ok(ok);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/FilKollektions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
         public async Task<ActionResult<FilKollektion>> PostFilKollektion(FilKollektion filKollektion)
         {
             try
             {
                 await _filkollektionService.Add(filKollektion);
                 return Ok();
             }
             catch (Exception e)
             {
                 return BadRequest(e.Message);
             }
         }

         [HttpPut("{id}")]
         public async Task<ActionResult<Overforing>> PutOverforing(int id, [FromBody] FilKollektion filKollektion)
         {
             try
             {
                 await _filkollektionService.Update(id, filKollektion);
                 return Ok();
             }
             catch (Exception e)
             {
                 return BadRequest(e.Message);
             }
         }
         
        //DELETE: api/FilKollektions/5
        [HttpDelete]
        public async Task<IActionResult> DeleteFilKollektion([FromBody] List<string> toDelete)
        {
            await _filkollektionService.Delete(toDelete);
            return Ok();
        }
    }
}