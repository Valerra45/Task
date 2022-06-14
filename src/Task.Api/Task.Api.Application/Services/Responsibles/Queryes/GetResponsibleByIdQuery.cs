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

namespace Tasks.Api.Application.Services.Responsibles.Queryes
{
    public class GetResponsibleByIdQuery : IRequest<ResponsibleResponse>
    {
        public Guid Id { get; set; }
    }

    public class GetResponsibleByIdQueryHandler : IRequestHandler<GetResponsibleByIdQuery, ResponsibleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Responsible> _responsibleRepository;

        public GetResponsibleByIdQueryHandler(IMapper mapper,
            IRepository<Responsible> responsibleRepository)
        {
            _mapper = mapper;
            _responsibleRepository = responsibleRepository;
        }

        public async Task<ResponsibleResponse> Handle(GetResponsibleByIdQuery request, CancellationToken cancellationToken)
        {
            var responsible = await _responsibleRepository.GetByIdAsync(request.Id);

            if (responsible is null)
            {
                throw new EntityNotFoundException($"{nameof(Responsible)} with id '{request.Id}' doesn't exist");
            }

            return _mapper.Map<ResponsibleResponse>(responsible);
        }
    }
}
