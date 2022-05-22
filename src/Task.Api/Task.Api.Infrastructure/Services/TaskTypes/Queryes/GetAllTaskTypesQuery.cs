using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;

namespace Tasks.Api.Infrastructure.Services.TaskTypes.Queryes
{
    public class GetAllTaskTypesQuery : IRequest<IEnumerable<TaskTypeDto>> { }

    public class GetAllTaskTypesQueryHandler : IRequestHandler<GetAllTaskTypesQuery, IEnumerable<TaskTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TaskType> _taskTypeRepository;

        public GetAllTaskTypesQueryHandler(IMapper mapper,
            IRepository<TaskType> taskTypeRepository)
        {
            _mapper = mapper;
            _taskTypeRepository = taskTypeRepository;
        }

        public async Task<IEnumerable<TaskTypeDto>> Handle(GetAllTaskTypesQuery request, CancellationToken cancellationToken)
        {
            var taskTypes = await _taskTypeRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<TaskTypeDto>>(taskTypes);
        }
    }
}
