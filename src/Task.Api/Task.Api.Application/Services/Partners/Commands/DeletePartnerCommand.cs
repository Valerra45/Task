using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;
using Tasks.Api.Core.Exceptions;

namespace Tasks.Api.Application.Services.Partners.Commands
{
    public class DeletePartnerCommand : IRequest
    {
        public Guid Id { get; }

        public DeletePartnerCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeletePartnerCommandHandler : IRequestHandler<DeletePartnerCommand>
    {
        private readonly IRepository<Partner> _partnerRepository;

        public DeletePartnerCommandHandler(IRepository<Partner> partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public async Task<Unit> Handle(DeletePartnerCommand request, CancellationToken cancellationToken)
        {
            var importance = await _partnerRepository.GetByIdAsync(request.Id);

            if (importance is null)
            {
                throw new EntityNotFoundException($"{nameof(Partner)} with id '{request.Id}' doesn't exist");
            }

            await _partnerRepository.DeleteAsync(importance);

            return Unit.Value;
        }
    }
}
