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
    public class GetDocumentTaskByUserNameQuery : IRequest<IEnumerable<DocumentTaskResponse>>
    {
        public DocumentTaskByUserNameRequest? ByUserName { get; set; }
    }

    public class GetDocumentTaskByUserNameQueryHandler : IRequestHandler<GetDocumentTaskByUserNameQuery, IEnumerable<DocumentTaskResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DocumentTask> _documentTaskRepository;

        public GetDocumentTaskByUserNameQueryHandler(IMapper mapper,
            IRepository<DocumentTask> documentTaskRepository)
        {
            _mapper = mapper;
            _documentTaskRepository = documentTaskRepository;
        }

        public async Task<IEnumerable<DocumentTaskResponse>> Handle(GetDocumentTaskByUserNameQuery request, CancellationToken cancellationToken)
        {
            var documentTask = await _documentTaskRepository.GetWhere(x => x.Executor.User.Equals(request.ByUserName.UserName));

            return _mapper.Map<IEnumerable<DocumentTaskResponse>>(documentTask);
        }
    }
}
