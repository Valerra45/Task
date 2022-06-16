using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;

namespace Tasks.Api.Application.Services.Partners.Commands
{
    public class CreatePartnerCommand : IRequest<Guid>
    {
        public PartnerCreateOrEdit Partner { get; }
        
        public CreatePartnerCommand(PartnerCreateOrEdit partner)
        {
            Partner = partner;
        }
    }

    public class CreatePartnerCommandHandler : IRequestHandler<CreatePartnerCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Partner> _partnerRepository;

        public CreatePartnerCommandHandler(IMapper mapper,
            IRepository<Partner> partnerRepository)
        {
            _mapper = mapper;
            _partnerRepository = partnerRepository;
        }

        public async Task<Guid> Handle(CreatePartnerCommand request, CancellationToken cancellationToken)
        {
            var partner = _mapper.Map<Partner>(request.Partner);

            await _partnerRepository.AddAsync(partner);

            return partner.Id;
        }
    }
}
