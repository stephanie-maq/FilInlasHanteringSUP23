using Microsoft.AspNetCore.Mvc;
using FISSUP23.Database.Models;
using FISSUP23.Server.Services;

namespace FISSUP23.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilsController : ControllerBase
    {
        private readonly IFilService _service;


        public FilsController(IFilService service)
        {
            _service = service;
        }

        [Route("filtyper")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filtyp>>> GetFiltyper()
        {
            return await _service.GetFilTyper();
        }
        
        [Route("datatyper")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Datatyp>>> GetDatatyper()
        {
            return await _service.GetDataTyper();
        }

        //GET: api/Fils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fil>>> GetFils()
        {
            return await _service.GetFiler();
        }
        
        // GET: api/Fils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fil>> GetFileById(int id)        {
            return await _service.GetById(id);
        }
        
        // PUT: api/Fils/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFil(int id, Fil fil)
        {

            return NoContent();
        }
        
        // POST: api/Fils
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fil>> PostFil(Fil fil)
        {
            try
            {
                await _service.Add(fil);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("filDatatyp/add")]
        [HttpPost]
        public async Task<ActionResult> PostFileDataType(FilDatatyp filDatatyp)
        {
            try
            {
                await _service.AddFilDatatype(filDatatyp);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // DELETE: api/Fils
        [HttpDelete]
        public async Task<IActionResult> DeleteFil([FromBody] List<string> toDelete)
        {
            await _service.Delete(toDelete);
            return Ok();
        }
        
        // private bool FilExists(int id)
        // {
        //     return (_context.Fils?.Any(e => e.Id == id)).GetValueOrDefault();
        // }
    }
}
