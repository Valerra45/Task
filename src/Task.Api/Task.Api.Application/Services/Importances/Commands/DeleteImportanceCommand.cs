using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;
using Tasks.Api.Core.Exceptions;

namespace Tasks.Api.Application.Services.Importances.Commands
{
    public class DeleteImportanceCommand : IRequest
    {
        public Guid Id { get; }

        public DeleteImportanceCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteImportanceCommandHandler : IRequestHandler<DeleteImportanceCommand>
    {
        private readonly IRepository<Importance> _importanceRepository;

        public DeleteImportanceCommandHandler(IRepository<Importance> importanceRepository)
        {
            _importanceRepository = importanceRepository;
        }

        public async Task<Unit> Handle(DeleteImportanceCommand request, CancellationToken cancellationToken)
        {
            var importance = await _importanceRepository.GetByIdAsync(request.Id);

            if (importance is null)
            {
                throw new EntityNotFoundException($"{nameof(Importance)} with id '{request.Id}' doesn't exist");
            }

            await _importanceRepository.DeleteAsync(importance);

            return Unit.Value;
        }
    }
}
