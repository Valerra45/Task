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
    public class DeleteTaskTypeCommand: IRequest
    {
        public Guid Id { get; }

        public DeleteTaskTypeCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteTaskTypeCommandHandler : IRequestHandler<DeleteTaskTypeCommand>
    {
        private readonly IRepository<TaskType> _taskTypeRepository;

        public DeleteTaskTypeCommandHandler(IRepository<TaskType> taskTypeRepository)
        {
            _taskTypeRepository = taskTypeRepository;
        }

        public async Task<Unit> Handle(DeleteTaskTypeCommand request, CancellationToken cancellationToken)
        {
            var taskType = await _taskTypeRepository.GetByIdAsync(request.Id);

            if (taskType is null)
            {
                throw new EntityNotFoundException($"{nameof(TaskType)} with id '{request.Id}' doesn't exist");
            }

            await _taskTypeRepository.DeleteAsync(taskType);

            return Unit.Value;
        }
    }
}
