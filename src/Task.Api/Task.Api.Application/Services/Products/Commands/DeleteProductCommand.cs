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
    public class DeleteProductCommand : IRequest
    {
        public Guid Id { get; }

        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IRepository<Product> _productRepository;

        public DeleteProductCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                throw new EntityNotFoundException($"{nameof(Product)} with id '{request.Id}' doesn't exist");
            }

            await _productRepository.DeleteAsync(product);

            return Unit.Value;
        }
    }
}
