using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;
using Tasks.Api.Core.Exceptions;

namespace Tasks.Api.Application.Services.DocumentTasks.Commands
{
    public class UpdateDocumentTaskCommand : IRequest<Guid>
    {
        public Guid Id { get; }

        public DocumentTaskCreateOrEdit DocumentTask { get; }

        public UpdateDocumentTaskCommand(Guid id, DocumentTaskCreateOrEdit documentTask)
        {
            Id = id;
            DocumentTask = documentTask;
        }
    }

    public class UpdateDocumentTaskCommandHandler : IRequestHandler<UpdateDocumentTaskCommand, Guid>
    {
        private readonly IRepository<DocumentTask> _documentTaskRepository;
        private readonly IRepository<Responsible> _responsibleRepository;
        private readonly IRepository<Partner> _partnerRepositpry;
        private readonly IRepository<Importance> _importanceRepositpry;
        private readonly IRepository<TaskType> _taskTypeRepository;

        public UpdateDocumentTaskCommandHandler(IRepository<DocumentTask> documentTaskRepository,
            IRepository<Responsible> responsibleRepository,
            IRepository<Partner> partnerRepositpry,
            IRepository<Importance> importanceRepositpry,
            IRepository<TaskType> taskTypeRepository)
        {
            _documentTaskRepository = documentTaskRepository;
            _responsibleRepository = responsibleRepository;
            _partnerRepositpry = partnerRepositpry;
            _importanceRepositpry = importanceRepositpry;
            _taskTypeRepository = taskTypeRepository;
        }

        public async Task<Guid> Handle(UpdateDocumentTaskCommand request, CancellationToken cancellationToken)
        {
            var documentTask = await _documentTaskRepository.GetByIdAsync(request.Id);

            if (documentTask is null)
            {
                throw new EntityNotFoundException($"{nameof(DocumentTask)} with id '{request.Id}' doesn't exist");
            }

            documentTask.Name = request.DocumentTask.Name;
            documentTask.Report = request.DocumentTask.Report;
            documentTask.Priority = request.DocumentTask.Priority;
            documentTask.Description = request.DocumentTask.Description;
            documentTask.DateEnd = request.DocumentTask.DateEnd;
            documentTask.DateCompleted = request.DocumentTask.DateCompleted;
            documentTask.Completed = request.DocumentTask.Completed;

            var author = await _responsibleRepository.GetByIdAsync(request.DocumentTask.AuthorId);

            if (author is null)
            {
                throw new EntityNotFoundException($"{nameof(Responsible)} with id '{request.DocumentTask.AuthorId}' doesn't exist");
            }

            var executor = await _responsibleRepository.GetByIdAsync(request.DocumentTask.ExecutorId);

            if (author is null)
            {
                throw new EntityNotFoundException($"{nameof(Responsible)} with id '{request.DocumentTask.ExecutorId}' doesn't exist");
            }

            var partner = await _partnerRepositpry.GetByIdAsync(request.DocumentTask.PartnerId);

            if (author is null)
            {
                throw new EntityNotFoundException($"{nameof(Partner)} with id '{request.DocumentTask.PartnerId}' doesn't exist");
            }

            var importance = await _importanceRepositpry.GetByIdAsync(request.DocumentTask.ImportanceId);

            if (author is null)
            {
                throw new EntityNotFoundException($"{nameof(Importance)} with id '{request.DocumentTask.ImportanceId}' doesn't exist");
            }

            var taskType = await _taskTypeRepository.GetByIdAsync(request.DocumentTask.TaskTypeId);

            if (author is null)
            {
                throw new EntityNotFoundException($"{nameof(TaskType)} with id '{request.DocumentTask.ImportanceId}' doesn't exist");
            }

            documentTask.Author = author;
            documentTask.Executor = executor;
            documentTask.Partner = partner;
            documentTask.Importance = importance;
            documentTask.TaskType = taskType;

            documentTask.Update = DateTime.Now;

            await _documentTaskRepository.UpdateAsync(documentTask);

            return documentTask.Id;
        }
    }
}
