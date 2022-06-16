using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;
using Tasks.Api.Core.Exceptions;

namespace Tasks.Api.Application.Services.TaskTypes.Commands
{
    public class UpdateTaskTypeCommand : IRequest<Guid>
    {
        public Guid Id { get; }

        public TaskTypeCreateOrEdit TaskType { get; }

        public UpdateTaskTypeCommand(Guid id, TaskTypeCreateOrEdit taskType)
        {
            Id = id;
            TaskType = taskType;
        }
    }

    public class UpdateTaskTypeCommandHandler : IRequestHandler<UpdateTaskTypeCommand, Guid>
    {
        private readonly IRepository<TaskType> _taskTypeRepository;

        public UpdateTaskTypeCommandHandler(IRepository<TaskType> taskTypeRepository)
        {
            _taskTypeRepository = taskTypeRepository;
        }

        public async Task<Guid> Handle(UpdateTaskTypeCommand request, CancellationToken cancellationToken)
        {
            var taskType = await _taskTypeRepository.GetByIdAsync(request.Id);

            if (taskType is null)
            {
                throw new EntityNotFoundException($"{nameof(TaskType)} with id '{request.Id}' doesn't exist");
            }

            taskType.Name = request.TaskType.Name;
            taskType.Update = DateTime.Now;

            await _taskTypeRepository.UpdateAsync(taskType);

            return taskType.Id;
        }
    }
}
