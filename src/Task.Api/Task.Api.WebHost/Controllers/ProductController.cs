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
using Tasks.Api.Application.Services.Partners.Commands;
using Tasks.Api.Application.Services.Products.Commands;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<PartnerResponse>> GetProductAsync(Guid id)
        {
            var response = await _mediatr.Send(new GetProductByIdQuery { Id = id });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartnerAsync(ProductCreateOrEdit request)
        {
            var response = await _mediatr.Send(new CreateProductCommand(request));

            return CreatedAtAction(nameof(GetProductAsync), new { id = response }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductAsync(Guid id, ProductCreateOrEdit request)
        {
            var response = await _mediatr.Send(new UpdateProductCommand(id, request));

            return CreatedAtAction(nameof(GetProductAsync), new { id = response }, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(Guid id)
        {
            await _mediatr.Send(new DeleteProductCommand(id));

            return NoContent();
        }
    }
}
