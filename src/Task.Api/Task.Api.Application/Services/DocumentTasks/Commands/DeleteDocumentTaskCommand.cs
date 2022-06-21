using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;
using Tasks.Api.Core.Exceptions;

namespace Tasks.Api.Application.Services.DocumentTasks.Commands
{
    public class DeleteDocumentTaskCommand: IRequest
    {
        public Guid Id { get; }

        public DeleteDocumentTaskCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteDocumentTaskCommandHandler : IRequestHandler<DeleteDocumentTaskCommand>
    {
        private readonly IRepository<DocumentTask> _documentTaskRepository;

        public DeleteDocumentTaskCommandHandler(IRepository<DocumentTask> documentTaskRepository)
        {
            _documentTaskRepository = documentTaskRepository;
        }

        public async Task<Unit> Handle(DeleteDocumentTaskCommand request, CancellationToken cancellationToken)
        {
            var importance = await _documentTaskRepository.GetByIdAsync(request.Id);

            if (importance is null)
            {
                throw new EntityNotFoundException($"{nameof(DocumentTask)} with id '{request.Id}' doesn't exist");
            }

            await _documentTaskRepository.DeleteAsync(importance);

            return Unit.Value;
        }
    }
}
