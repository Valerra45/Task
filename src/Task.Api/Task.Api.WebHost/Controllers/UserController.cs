using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.TaskTypes.Queryes;
using Tasks.Api.Application.Services.TaskTypes;
using Tasks.Api.Application.Services.Users;
using Tasks.Api.Application.Services.Users.Commands;
using Tasks.Api.Application.Services.TaskTypes.Commands;

namespace Tasks.Api.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
        : ControllerBase
    {
        private readonly IMediator _mediatr;

        public UserController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAcync(UserCreate request)
        {
            await _mediatr.Send(new CreateUserCommand(request));

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync(UserUpdate request)
        {
            await _mediatr.Send(new UpdateUserCommand(request));

            return Ok();
        }
    }
}
