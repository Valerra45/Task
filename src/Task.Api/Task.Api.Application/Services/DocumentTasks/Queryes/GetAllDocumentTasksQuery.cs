using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;

namespace Tasks.Api.Application.Services.DocumentTasks.Queryes
{
    public class GetAllDocumentTasksQuery : IRequest<IEnumerable<DocumentTaskShortResponse>> { }

    public class GetAllDocumentTasksQueryHandler : IRequestHandler<GetAllDocumentTasksQuery, IEnumerable<DocumentTaskShortResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DocumentTask> _documentTaskRepository;

        public GetAllDocumentTasksQueryHandler(IMapper mapper,
            IRepository<DocumentTask> documentTaskRepository)
        {
            _mapper = mapper;
            _documentTaskRepository = documentTaskRepository;
        }

        public async Task<IEnumerable<DocumentTaskShortResponse>> Handle(GetAllDocumentTasksQuery request, CancellationToken cancellationToken)
        {
            var documentTasks = await _documentTaskRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<DocumentTaskShortResponse>>(documentTasks);
        }
    }
}
