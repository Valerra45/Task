using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;
using Tasks.Api.Core.Exceptions;

namespace Tasks.Api.Application.Services.Partners.Queryes
{
    public class GetPartnerByIdQuery : IRequest<PartnerResponse>
    {
        public Guid Id { get; set; }
    }

    public class GetPartnerByIdQueryHandler : IRequestHandler<GetPartnerByIdQuery, PartnerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Partner> _partnerRepository;

        public GetPartnerByIdQueryHandler(IMapper mapper,
            IRepository<Partner> partnerRepository)
        {
            _mapper = mapper;
            _partnerRepository = partnerRepository;
        }

        public async Task<PartnerResponse> Handle(GetPartnerByIdQuery request, CancellationToken cancellationToken)
        {
            var partner = await _partnerRepository.GetByIdAsync(request.Id);

            if (partner is null)
            {
                throw new EntityNotFoundException($"{nameof(Partner)} with id '{request.Id}' doesn't exist");
            }

            return _mapper.Map<PartnerResponse>(partner);
        }
    }
}
