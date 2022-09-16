using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.Partners.Commands;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;

namespace Tasks.Api.Application.Services.Products.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public ProductCreateOrEdit Product { get; }
        
        public CreateProductCommand(ProductCreateOrEdit product)
        {
            Product = product;
        }

    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _productRepository;

        public CreateProductCommandHandler(IMapper mapper,
            IRepository<Product> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.Product);

            await _productRepository.AddAsync(product);

            return product.Id;
        }
    }
}
