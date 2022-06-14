using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;
using Tasks.Api.Core.Exceptions;

namespace Tasks.Api.Application.Services.Responsibles.Commadns
{
    public class DeleteResponsibleCommand : IRequest
    {
        public Guid Id { get; }

        public DeleteResponsibleCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteResponsibleCommandHandler : IRequestHandler<DeleteResponsibleCommand>
    {
        private readonly IRepository<Responsible> _responsibleRepository;

        public DeleteResponsibleCommandHandler(IRepository<Responsible> responsibleRepository)
        {
            _responsibleRepository = responsibleRepository;
        }
        
        public async Task<Unit> Handle(DeleteResponsibleCommand request, CancellationToken cancellationToken)
        {
            var responsible = await _responsibleRepository.GetByIdAsync(request.Id);

            if (responsible is null)
            {
                throw new EntityNotFoundException($"{nameof(Responsible)} with id '{request.Id}' doesn't exist");
            }

            await _responsibleRepository.DeleteAsync(responsible);

            return Unit.Value;
        }
    }
}
