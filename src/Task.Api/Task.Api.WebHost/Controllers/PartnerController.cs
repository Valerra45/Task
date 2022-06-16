using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.Partners;
using Tasks.Api.Application.Services.Partners.Commands;
using Tasks.Api.Application.Services.Partners.Queryes;

namespace Tasks.Api.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController 
        : ControllerBase
    {
        private readonly IMediator _mediatr;

        public PartnerController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartnerResponse>>> GetPartnersAsync()
        {
            var responce = await _mediatr.Send(new GetAllPartnersQuery());

            return Ok(responce);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PartnerResponse>> GetPartnerAsync(Guid id)
        {
            var response = await _mediatr.Send(new GetPartnerByIdQuery { Id = id });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartnerAsync(PartnerCreateOrEdit request)
        {
            var response = await _mediatr.Send(new CreatePartnerCommand(request));

            return CreatedAtAction(nameof(GetPartnerAsync), new { id = response }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePartnerAsync(Guid id, PartnerCreateOrEdit request)
        {
            var response = await _mediatr.Send(new UpdatePartnerCommand(id, request));

            return CreatedAtAction(nameof(GetPartnerAsync), new { id = response }, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartnerAsync(Guid id)
        {
            await _mediatr.Send(new DeletePartnerCommand(id));

            return NoContent();
        }
    }
}
