using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;

namespace Tasks.Api.Application.Services.Responsibles.Commadns
{
    public class CreateResponsibleCommand : IRequest<Guid>
    {
        public ResponsibleCreateOrEdit Responsible { get; }
        
        public CreateResponsibleCommand(ResponsibleCreateOrEdit responsible)
        {
            Responsible = responsible;
        }
    }

    public class CreateResponsibleCommandHandler : IRequestHandler<CreateResponsibleCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Responsible> _responsibleRepository;

        public CreateResponsibleCommandHandler(IMapper mapper,
            IRepository<Responsible> responsibleRepository)
        {
            _mapper = mapper;
            _responsibleRepository = responsibleRepository;
        }

        public async Task<Guid> Handle(CreateResponsibleCommand request, CancellationToken cancellationToken)
        {
            var responsible = _mapper.Map<Responsible>(request.Responsible);

            await _responsibleRepository.AddAsync(responsible);

            return responsible.Id;
        }
    }
}
