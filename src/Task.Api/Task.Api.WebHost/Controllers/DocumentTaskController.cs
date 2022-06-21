using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasks.Api.Application.Services.DocumentTasks;
using Tasks.Api.Application.Services.DocumentTasks.Commands;
using Tasks.Api.Application.Services.DocumentTasks.Queryes;
using Tasks.Api.Application.Services.Tasks;
using Tasks.Api.Application.Services.Tasks.Commands;

namespace Tasks.Api.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTaskController
        : ControllerBase
    {
        private readonly IMediator _mediatr;

        public DocumentTaskController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentTaskShortResponse>>> GetDocumentTasksAsync()
        {
            var responce = await _mediatr.Send(new GetAllDocumentTasksQuery());

            return Ok(responce);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentTaskResponse>> GetDocumentTaskAsync(Guid id)
        {
            var response = await _mediatr.Send(new GetDocumentTaskByIdQuery { Id = id });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDocumentTaskAcync(DocumentTaskCreateOrEdit documentTask)
        {

            var response = await _mediatr.Send(new CreateDocumentTaskCommand(documentTask));

            return CreatedAtAction(nameof(GetDocumentTaskAsync), new { id = response }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocumentTaskAsync(Guid id, DocumentTaskCreateOrEdit documentTask)
        {
            var response = await _mediatr.Send(new UpdateDocumentTaskCommand(id, documentTask));

            return CreatedAtAction(nameof(GetDocumentTaskAsync), new { id = response }, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentTaskAsync(Guid id)
        {
            await _mediatr.Send(new DeleteDocumentTaskCommand(id));

            return NoContent();
        }
    }
}
