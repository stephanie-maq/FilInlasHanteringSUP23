using Microsoft.AspNetCore.Mvc;
using FISSUP23.Database.Models;
using FISSUP23.Server.Services;

namespace FISSUP23.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KolumnsController : ControllerBase
    {
        private readonly IKolumnService _service;


        public KolumnsController(IKolumnService service)
        {
            _service = service;
        }

        // [Route("filtyper")]
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Filtyp>>> GetFiltyper()
        // {
        //     return await _service.GetFilTyper();
        // }
        
        // [Route("fildatatyper")]
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<FilDatatyp>>> GetFilDatatyper()
        // {
        //     return await _service.GetFilDataTyper();
        // }

        //GET: api/Fils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kolumn>>> GetKolumner()
        {
            return await _service.GetKolumner();
        }
        
        // GET: api/Fils/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<IEnumerable<Fil>>> GetByFilkollektion(int id)        {
        //     return await _service.GetByID(id);
        // }
        
    }
}