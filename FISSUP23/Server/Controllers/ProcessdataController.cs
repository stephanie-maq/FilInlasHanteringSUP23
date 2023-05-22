using Microsoft.AspNetCore.Mvc;
using FISSUP23.Database.Models;
using FISSUP23.Server.Services;

namespace FISSUP23.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessdataController : ControllerBase
    {
        private readonly IProcessdataService _service;


        public ProcessdataController(IProcessdataService service)
        {
            _service = service;
        }
        

        //GET: api/Processdatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inlasning>>> GetInlasningar()
        {
            return await _service.GetInlasningar();
        }

    }
}