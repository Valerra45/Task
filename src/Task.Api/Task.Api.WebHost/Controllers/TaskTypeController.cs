using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Infrastructure.Services.TaskTypes;
using Tasks.Api.Infrastructure.Services.TaskTypes.Queryes;

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
        public async Task<ActionResult<IEnumerable<TaskTypeDto>>> GetAllAsync()
        {
            var response = await _mediatr.Send(new GetAllTaskTypesQuery());

            return Ok(response);
        }
    }
}
