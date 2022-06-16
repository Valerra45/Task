using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;

namespace Tasks.Api.Application.Services.Partners.Queryes
{
    public class GetAllPartnersQuery : IRequest<IEnumerable<PartnerResponse>> { }

    public class GetAllPartnersQueryHandler : IRequestHandler<GetAllPartnersQuery, IEnumerable<PartnerResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Partner> _partnerRepository;

        public GetAllPartnersQueryHandler(IMapper mapper,
            IRepository<Partner> partnerRepository)
        {
            _mapper = mapper;
            _partnerRepository = partnerRepository;
        }

        public async Task<IEnumerable<PartnerResponse>> Handle(GetAllPartnersQuery request, CancellationToken cancellationToken)
        {
            var partner = await _partnerRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<PartnerResponse>>(partner);
        }
    }
 
}
