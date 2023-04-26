using FISSUP23.Client.Pages;
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
        // [HttpGet]
        //  public async Task<ActionResult<IEnumerable<FilKollektion>>> GetFilKollektions()
        //  {
        //    if (_context.FilKollektions == null)
        //    {
        //        return NotFound();
        //    }
        //      return await _context.FilKollektions.ToListAsync();
        //  }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<FilKollektion>>> GetByOverforing(int id)
        {
            try
            {
                var ok = await _filkollektionService.GetByOverforingID(id);
                return Ok(ok);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //GET: api/FilKollektions/5
        [Route("byId")]
        [HttpGet("{id}")]
         public async Task<ActionResult<FilKollektion>> GetFilKollektion(int id)
         {
             return await _filkollektionService.GetByID(id);
         }

        // PUT: api/FilKollektions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
         public async Task<ActionResult<FISSUP23.Database.Models.Overforing>> PutFilkollektion(int id, FilKollektion filKollektion)
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

        //DELETE: api/FilKollektions/5
        [HttpDelete]
        public async Task<IActionResult> DeleteFilKollektion([FromBody] List<string> toDelete)
        {
            await _filkollektionService.Delete(toDelete);
            return Ok();
        }
    }
}