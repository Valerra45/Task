using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.Users;

namespace Tasks.Api.WebHost.Controllers
{
    public class UserController 
        : ControllerBase
    {
        private readonly IMediator _mediatr;

        public UserController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        public async Task<IActionResult> CreateUserAcync(CreateOrEditUser request)
        {
           
            
            return Ok();
        }
    }
}
