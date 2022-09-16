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
using Tasks.Api.Core.Exceptions;

namespace Tasks.Api.Application.Services.Products.Commands
{
    public class UpdateProductCommand : IRequest<Guid>
    {
        public Guid Id { get; }
        
        public ProductCreateOrEdit Product { get; }
        
        public UpdateProductCommand(Guid id, ProductCreateOrEdit product)
        {
            Id = id;
            Product = product;
        }

    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _productRepository;

        public UpdateProductCommandHandler(IMapper mapper,
            IRepository<Product> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                throw new EntityNotFoundException($"{nameof(Product)} with id '{request.Id}' doesn't exist");
            }

            product.Name = request.Product.Name;
            product.Group = request.Product.Group;
            product.Update = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Russian Standard Time");

            await _productRepository.UpdateAsync(product);

            return product.Id;
        }
    }
}
