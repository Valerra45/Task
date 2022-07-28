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
    public class GetDocumentTaskByTimeQuery : IRequest<IEnumerable<DocumentTaskResponse>>
    {
        public DocumentTaskByTimeRequest? ByTimeRequest { get; set; }
    }

    public class GetDocumentTaskByDateQueryHandler : IRequestHandler<GetDocumentTaskByTimeQuery, IEnumerable<DocumentTaskResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DocumentTask> _documentTaskRepository;

        public GetDocumentTaskByDateQueryHandler(IMapper mapper,
            IRepository<DocumentTask> documentTaskRepository)
        {
            _mapper = mapper;
            _documentTaskRepository = documentTaskRepository;
        }

        public async Task<IEnumerable<DocumentTaskResponse>> Handle(GetDocumentTaskByTimeQuery request, CancellationToken cancellationToken)
        {
            var documentTask = await _documentTaskRepository.GetWhere(x => x.Update >= request.ByTimeRequest.DateStart);
     
            return _mapper.Map<IEnumerable<DocumentTaskResponse>>(documentTask);
        }
    }
}
