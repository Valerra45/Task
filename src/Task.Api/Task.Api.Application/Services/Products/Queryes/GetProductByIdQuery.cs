using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.Partners;
using Tasks.Api.Application.Services.Partners.Queryes;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;
using Tasks.Api.Core.Exceptions;

namespace Tasks.Api.Application.Services.Products.Queryes
{
    public class GetProductByIdQuery : IRequest<ProductResponse>
    {
        public Guid Id { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _productRepository;

        public GetProductByIdQueryHandler(IMapper mapper,
            IRepository<Product> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                throw new EntityNotFoundException($"{nameof(Product)} with id '{request.Id}' doesn't exist");
            }

            return _mapper.Map<ProductResponse>(product);
        }
    }
}
