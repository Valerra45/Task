using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasks.Api.Application.Services.TaskTypes;
using Tasks.Api.Application.Services.TaskTypes.Commands;
using Tasks.Api.Application.Services.TaskTypes.Queryes;

namespace Tasks.Api.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskTypeController
        : ControllerBase
    {
        private readonly IMediator _mediatr;

        public TaskTypeController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskTypeResponse>>> GetTaskTypesAsync()
        {
            var response = await _mediatr.Send(new GetAllTaskTypesQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskTypeResponse>> GetTaskTypeAsync(Guid id)
        {
            var response = await _mediatr.Send(new GetTaskTypeByIdQuery { Id = id });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskTypeAsync(TaskTypeCreateOrEdit request)
        {
            var response = await _mediatr.Send(new CreateTaskTypeCommand(request));

            return CreatedAtAction(nameof(GetTaskTypeAsync), new { id = response }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskTypeAsync(Guid id, TaskTypeCreateOrEdit request)
        {
            var response = await _mediatr.Send(new UpdateTaskTypeCommand(id, request));

            return CreatedAtAction(nameof(GetTaskTypeAsync), new { id = response }, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskType(Guid id)
        {
            await _mediatr.Send(new DeleteTaskTypeCommand(id));

            return NoContent();
        }
    }
}
