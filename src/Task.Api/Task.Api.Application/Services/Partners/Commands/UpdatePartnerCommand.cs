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

namespace Tasks.Api.Application.Services.Partners.Commands
{
    public class UpdatePartnerCommand : IRequest<Guid>
    {
        public Guid Id { get; }
        
        public PartnerCreateOrEdit Partner { get; }
        
        public UpdatePartnerCommand(Guid id, PartnerCreateOrEdit partner)
        {
            Id = id;
            Partner = partner;
        }
    }

    public class UpdatePartnerCommandHandler : IRequestHandler<UpdatePartnerCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Partner> _partnerRepository;

        public UpdatePartnerCommandHandler(IMapper mapper,
            IRepository<Partner> partnerRepository)
        {
            _mapper = mapper;
            _partnerRepository = partnerRepository;
        }

        public async Task<Guid> Handle(UpdatePartnerCommand request, CancellationToken cancellationToken)
        {
            var partner = await _partnerRepository.GetByIdAsync(request.Id);

            if (partner is null)
            {
                throw new EntityNotFoundException($"{nameof(Partner)} with id '{request.Id}' doesn't exist");
            }

            partner.Name = request.Partner.Name;
            partner.Address = request.Partner.Address;
            partner.Description = request.Partner.Description;
            partner.Phone = request.Partner.Phone;
            partner.Update = DateTime.Now;

            await _partnerRepository.UpdateAsync(partner);

            return partner.Id;
        }
    }
}
