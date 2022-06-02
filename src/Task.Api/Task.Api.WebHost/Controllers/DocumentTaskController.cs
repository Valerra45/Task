using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> CreateTasksAcync(IEnumerable<CreateOrEditDocumentTask> tasks)
        {
            foreach (var documentTask in tasks)
            {
                await _mediatr.Send(new CreateDocumentTaskCommand(documentTask));
            }

            return Ok();
        }
    }
}
