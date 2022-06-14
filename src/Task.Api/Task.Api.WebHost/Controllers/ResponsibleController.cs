using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.Responsibles;
using Tasks.Api.Application.Services.Responsibles.Commadns;
using Tasks.Api.Application.Services.Responsibles.Queryes;

namespace Tasks.Api.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsibleController
        : ControllerBase
    {
        private readonly IMediator _mediatr;

        public ResponsibleController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponsibleResponse>>> GetResponsiblesAsync()
        {
            var responce = await _mediatr.Send(new GetAllResponsiblesQuery());

            return Ok(responce);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponsibleResponse>> GetResposibleAync(Guid id)
        {
            var response = await _mediatr.Send(new GetResponsibleByIdQuery { Id = id });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskTypeAsync(ResponsibleCreateOrEdit request)
        {
            var response = await _mediatr.Send(new CreateResponsibleCommand(request));

            return CreatedAtAction(nameof(GetResposibleAync), new { id = response }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResponsibleAsync(Guid id, ResponsibleCreateOrEdit request)
        {
            var response = await _mediatr.Send(new UpdateResponsibleCommand(id, request));

            return CreatedAtAction(nameof(GetResposibleAync), new { id = response }, response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskTypeAsync(Guid id)
        {
            await _mediatr.Send(new DeleteResponsibleCommand(id));

            return NoContent();
        }
    }
}
