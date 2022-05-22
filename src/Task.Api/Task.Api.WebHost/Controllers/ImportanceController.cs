using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Infrastructure.Services.Importances;
using Tasks.Api.Infrastructure.Services.Importances.Queryes;

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
        public async Task<ActionResult<IEnumerable<ImportanceDto>>> GetAllAsync()
        {
            var responce = await _mediatr.Send(new GetAllImportancesQuery());

            return Ok(responce);
        }
    }
}
