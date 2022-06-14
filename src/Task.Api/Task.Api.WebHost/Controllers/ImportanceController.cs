using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasks.Api.Application.Services.Importances;
using Tasks.Api.Application.Services.Importances.Commands;
using Tasks.Api.Application.Services.Importances.Queryes;

namespace Tasks.Api.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportanceController
        : ControllerBase
    {
        private readonly IMediator _mediatr;

        public ImportanceController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImportanceResponse>>> GetImportancesAsync()
        {
            var responce = await _mediatr.Send(new GetAllImportancesQuery());

            return Ok(responce);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ImportanceResponse>> GetImportanceAsync(Guid id)
        {
            var response = await _mediatr.Send(new GetImportanceByIdQuery { Id = id });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateImportanceAsync(ImportanceCreateOrEdit request)
        {
            var response = await _mediatr.Send(new CreateImportanceCommand(request));

            return CreatedAtAction(nameof(GetImportanceAsync), new { id = response }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImportanceAsync(Guid id, ImportanceCreateOrEdit request)
        {
            var response = await _mediatr.Send(new UpdateImportanceCommand(id, request));

            return CreatedAtAction(nameof(GetImportanceAsync), new { id = response }, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImportanceAsync(Guid id)
        {
            await _mediatr.Send(new DeleteImportanceCommand(id));

            return NoContent();
        }
    }
}
