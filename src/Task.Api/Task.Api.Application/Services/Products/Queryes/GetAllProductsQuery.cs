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

namespace Tasks.Api.Application.Services.Products.Queryes
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductResponse>> { }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _productRepository;

        public GetAllProductsQueryHandler(IMapper mapper,
            IRepository<Product> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var partner = await _productRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProductResponse>>(partner);
        }
    }
}
