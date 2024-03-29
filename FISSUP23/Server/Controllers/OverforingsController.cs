﻿using Microsoft.AspNetCore.Mvc;
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
            return await _service.GetById(id);
        }


        //PUT: api/Overforings/5
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}")]
        public async Task<ActionResult<Overforing>> PutOverforing(int id, Overforing overforing)
        {
            try
            {
                await _service.Update(id, overforing);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // POST: api/Overforings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Overforing>> PostOverforing(Overforing over)
        {
            try
            {
                await _service.Add(over);
                //await _service.AddNyOverforing(nyOverforing);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //DELETE: api / Overforings / 5
        [HttpDelete]
        public async Task<IActionResult> DeleteOverforing([FromBody] List<string> toDelete)
        {
            await _service.Delete(toDelete);
            return Ok();
        }
    }
}