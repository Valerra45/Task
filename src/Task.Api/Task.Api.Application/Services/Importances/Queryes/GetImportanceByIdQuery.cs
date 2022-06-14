using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;

namespace Tasks.Api.Application.Services.Importances.Queryes
{
    public class GetImportanceByIdQuery : IRequest<ImportanceResponse>
    {
        public Guid Id { get; set; }
    }

    public class GetImportanceByIdQueryHandler : IRequestHandler<GetImportanceByIdQuery, ImportanceResponse>
    {
        private IMapper _mapper;
        private IRepository<Importance> _importanceRepository;

        public GetImportanceByIdQueryHandler(IMapper mapper,
            IRepository<Importance> importanceRepository)
        {
            _mapper = mapper;
            _importanceRepository = importanceRepository;
        }

        public async Task<ImportanceResponse> Handle(GetImportanceByIdQuery request, CancellationToken cancellationToken)
        {
            var taskType = await _importanceRepository.GetByIdAsync(request.Id);

            return _mapper.Map<ImportanceResponse>(taskType);
        }
    }
}
