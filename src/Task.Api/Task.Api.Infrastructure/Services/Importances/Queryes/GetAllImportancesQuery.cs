using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;
using Tasks.Api.Infrastructure.Services.Importances;

namespace Tasks.Api.Infrastructure.Services.Importances.Queryes
{
    public class GetAllImportancesQuery : IRequest<IEnumerable<ImportanceDto>> { }

    public class GetAllImportancesQueryHandler : IRequestHandler<GetAllImportancesQuery, IEnumerable<ImportanceDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Importance> _importanceRepository;

        public GetAllImportancesQueryHandler(IMapper mapper,
            IRepository<Importance> importanceRepository)
        {
            _mapper = mapper;
            _importanceRepository = importanceRepository;
        }

        public async Task<IEnumerable<ImportanceDto>> Handle(GetAllImportancesQuery request, CancellationToken cancellationToken)
        {
            var importances = await _importanceRepository.GetAllAsync(); 

            return _mapper.Map<IEnumerable<ImportanceDto>>(importances);
        }
    }

}
