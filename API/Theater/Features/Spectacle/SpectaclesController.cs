using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Theater.WebApi.Features.Spectacle.Commands;
using Theater.WebApi.Features.Spectacle.Dtos;
using Theater.WebApi.Features.Spectacle.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Theater.WebApi.Features.Spectacle
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpectaclesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SpectaclesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<SpectaclesController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetSpectaclesDto dto)
        {
            //todo return with available actions
            var page = await _mediator.Send(new GetSpectaclesQuery(dto));
            return Ok(page);
        }

        // GET api/<SpectaclesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        { 
            var spectacle = await _mediator.Send(new GetSpectacleQuery(id));
            return Ok(spectacle);
        }

        //todo fix CORS

        //[Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateSpectacleDto dto)
        {
            await _mediator.Send(new UpdateSpectacleCommand(dto, id));
            return NoContent();
        }
         
        //todo fix CORS
        //[Authorize(Roles = "Admin")]
        [HttpPost] 
        public async Task<IActionResult> Create([FromBody] CreateSpectacleDto dto)
        {
            var spectacle = await _mediator.Send(new CreateSpectacleCommand(dto));
            return StatusCode(StatusCodes.Status201Created, spectacle);
        }
         
    }
}
