using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasks.Api.Application.Services.Importances;
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
        public async Task<ActionResult<IEnumerable<ImportanceResponse>>> GetAllAsync()
        {
            var responce = await _mediatr.Send(new GetAllImportancesQuery());

            return Ok(responce);
        }
    }
}
