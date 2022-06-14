using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;

namespace Tasks.Api.Application.Services.Responsibles.Queryes
{
    public class GetAllResponsiblesQuery : IRequest<IEnumerable<ResponsibleResponse>> { }
  
    public class GetAllResponsiblesQueryHandler : IRequestHandler<GetAllResponsiblesQuery, IEnumerable<ResponsibleResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Responsible> _responsibleRepository;

        public GetAllResponsiblesQueryHandler(IMapper mapper,
            IRepository<Responsible> responsibleRepository)
        {
            _mapper = mapper;
            _responsibleRepository = responsibleRepository;
        }

        public async Task<IEnumerable<ResponsibleResponse>> Handle(GetAllResponsiblesQuery request, CancellationToken cancellationToken)
        {
            var responsibles = await _responsibleRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ResponsibleResponse>>(responsibles);
        }
    }
}
