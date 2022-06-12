using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;

namespace Tasks.Api.Application.Services.TaskTypes.Commands
{
    public class CreateTaskTypeCommand : IRequest<Guid>
    {
        public TaskTypeCreateOrEdit TaskType { get; }

        public CreateTaskTypeCommand(TaskTypeCreateOrEdit taskType)
        {
            TaskType = taskType;
        }
    }

    public class CreateTaskTypeCommandHandler : IRequestHandler<CreateTaskTypeCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TaskType> _taskTypeRepository;

        public CreateTaskTypeCommandHandler(IMapper mapper,
            IRepository<TaskType> taskTypeRepository)
        {
            _mapper = mapper;
            _taskTypeRepository = taskTypeRepository;
        }

        public async Task<Guid> Handle(CreateTaskTypeCommand request, CancellationToken cancellationToken)
        {
            var taskType = _mapper.Map<TaskType>(request.TaskType);

            await _taskTypeRepository.AddAsync(taskType);

            return taskType.Id;
        }
    }
}
