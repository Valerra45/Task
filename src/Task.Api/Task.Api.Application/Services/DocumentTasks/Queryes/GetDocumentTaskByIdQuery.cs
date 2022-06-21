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

namespace Tasks.Api.Application.Services.DocumentTasks.Queryes
{
    public class GetDocumentTaskByIdQuery : IRequest<DocumentTaskResponse>
    {
        public Guid Id { get; set; }
    }

    public class GetDocumentTaskByIdQueryHandler : IRequestHandler<GetDocumentTaskByIdQuery, DocumentTaskResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DocumentTask> _documentTaskRepository;

        public GetDocumentTaskByIdQueryHandler(IMapper mapper,
            IRepository<DocumentTask> documentTaskRepository)
        {
            _mapper = mapper;
            _documentTaskRepository = documentTaskRepository;
        }

        public async Task<DocumentTaskResponse> Handle(GetDocumentTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var documentTask = await _documentTaskRepository.GetByIdAsync(request.Id);

            if (documentTask is null)
            {
                throw new EntityNotFoundException($"{nameof(DocumentTask)} with id '{request.Id}' doesn't exist");
            }

            return _mapper.Map<DocumentTaskResponse>(documentTask);
        }
    }
}
