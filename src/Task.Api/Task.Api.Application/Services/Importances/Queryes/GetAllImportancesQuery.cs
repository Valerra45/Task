using AutoMapper;
using MediatR;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;

namespace Tasks.Api.Application.Services.Importances.Queryes
{
    public class GetAllImportancesQuery : IRequest<IEnumerable<ImportanceResponse>> { }

    public class GetAllImportancesQueryHandler : IRequestHandler<GetAllImportancesQuery, IEnumerable<ImportanceResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Importance> _importanceRepository;

        public GetAllImportancesQueryHandler(IMapper mapper,
            IRepository<Importance> importanceRepository)
        {
            _mapper = mapper;
            _importanceRepository = importanceRepository;
        }

        public async Task<IEnumerable<ImportanceResponse>> Handle(GetAllImportancesQuery request, CancellationToken cancellationToken)
        {
            var importances = await _importanceRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ImportanceResponse>>(importances);
        }
    }

}
