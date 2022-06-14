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

namespace Tasks.Api.Application.Services.TaskTypes.Queryes
{
    public class GetTaskTypeByIdQuery : IRequest<TaskTypeResponse>
    {
        public Guid Id { get; set; }
    }

    public class GetTaskTypeByIdQueryHandler : IRequestHandler<GetTaskTypeByIdQuery, TaskTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TaskType> _taskTypeRepository;

        public GetTaskTypeByIdQueryHandler(IMapper mapper,
            IRepository<TaskType> taskTypeRepository)
        {
            _mapper = mapper;
            _taskTypeRepository = taskTypeRepository;
        }

        public async Task<TaskTypeResponse> Handle(GetTaskTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var taskType = await _taskTypeRepository.GetByIdAsync(request.Id);

            if (taskType is null)
            {
                throw new EntityNotFoundException($"{nameof(TaskType)} with id '{request.Id}' doesn't exist");
            }

            return _mapper.Map<TaskTypeResponse>(taskType);
        }
    }
}
