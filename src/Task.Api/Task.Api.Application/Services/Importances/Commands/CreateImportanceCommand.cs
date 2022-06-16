using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;

namespace Tasks.Api.Application.Services.Importances.Commands
{
    public class CreateImportanceCommand : IRequest<Guid>
    {
        public ImportanceCreateOrEdit Importance { get; }

        public CreateImportanceCommand(ImportanceCreateOrEdit importance)
        {
            Importance = importance;
        }

        public class CreateImportanceCommandHandler : IRequestHandler<CreateImportanceCommand, Guid>
        {
            private readonly IMapper _mapper;
            private readonly IRepository<Importance> _importanceRepository;

            public CreateImportanceCommandHandler(IMapper mapper,
                IRepository<Importance> importanceRepository)
            {
                _mapper = mapper;
                _importanceRepository = importanceRepository;
            }

            public async Task<Guid> Handle(CreateImportanceCommand request, CancellationToken cancellationToken)
            {
                var importance = _mapper.Map<Importance>(request.Importance);

                await _importanceRepository.AddAsync(importance);

                return importance.Id;
            }
        }
    }
}
