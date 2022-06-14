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
    public class UpdateResponsibleCommand : IRequest<Guid>
    {
        public Guid Id { get; }
        public ResponsibleCreateOrEdit Responsible { get; }

        public UpdateResponsibleCommand(Guid id, ResponsibleCreateOrEdit responsible)
        {
            Id = id;
            Responsible = responsible;
        }
    }

    public class UpdateResponsibleCommandHandler : IRequestHandler<UpdateResponsibleCommand, Guid>
    {
        private readonly IRepository<Responsible> _responsibleRepository;

        public UpdateResponsibleCommandHandler(IRepository<Responsible> responsibleRepository)
        {
            _responsibleRepository = responsibleRepository;
        }

        public async Task<Guid> Handle(UpdateResponsibleCommand request, CancellationToken cancellationToken)
        {
            var responsible = await _responsibleRepository.GetByIdAsync(request.Id);

            if (responsible is null)
            {
                throw new EntityNotFoundException($"{nameof(Responsible)} with id '{request.Id}' doesn't exist");
            }

            responsible.FirstName = request.Responsible.FirstName;
            responsible.LastName = request.Responsible.LastName;
            responsible.User = request.Responsible.User;

            await _responsibleRepository.UpdateAsync(responsible);

            return responsible.Id;
        }
    }
}
