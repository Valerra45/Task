using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.Partners.Queryes;
using Tasks.Api.Application.Services.Partners;
using Tasks.Api.Application.Services.Products;
using Tasks.Api.Application.Services.Products.Queryes;

namespace Tasks.Api.WebHost.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController 
        : ControllerBase
    {
        private readonly IMediator _mediatr;

        public ProductController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProductsAsync()
        {
            var responce = await _mediatr.Send(new GetAllProductsQuery());

            return Ok(responce);
        }
    }
}
