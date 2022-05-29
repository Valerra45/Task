using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasks.Api.Application.Services.TaskTypes;
using Tasks.Api.Application.Services.TaskTypes.Queryes;

namespace Tasks.Api.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TaskTypeController
        : ControllerBase
    {
        private readonly IMediator _mediatr;

        public TaskTypeController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskTypeResponse>>> GetAllAsync()
        {
            var response = await _mediatr.Send(new GetAllTaskTypesQuery());

            return Ok(response);
        }
    }
}
