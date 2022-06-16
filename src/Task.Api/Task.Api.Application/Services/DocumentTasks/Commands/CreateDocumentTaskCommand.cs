using AutoMapper;
using MediatR;
using Tasks.Api.Application.Services.Partners;
using Tasks.Api.Application.Services.Responsibles;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;

namespace Tasks.Api.Application.Services.Tasks.Commands
{
    public class CreateDocumentTaskCommand : IRequest<Guid>
    {
        public CreateOrEditDocumentTask Task { get; }

        public CreateDocumentTaskCommand(CreateOrEditDocumentTask task)
        {
            Task = task;
        }
    }

    public class CreateDocumentTaskCommandHandler : IRequestHandler<CreateDocumentTaskCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DocumentTask> _taskRepository;
        private readonly IRepository<Responsible> _responsibleRepository;
        private readonly IRepository<Partner> _partnerRepositpry;
        private readonly IRepository<Importance> _importanceRepositpry;
        private readonly IRepository<TaskType> _taskTypeRepository;

        public CreateDocumentTaskCommandHandler(IMapper mapper,
            IRepository<DocumentTask> taskRepository,
            IRepository<Responsible> responsibleRepository,
            IRepository<Partner> partnerRepositpry,
            IRepository<Importance> importanceRepositpry,
            IRepository<TaskType> taskTypeRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
            _responsibleRepository = responsibleRepository;
            _partnerRepositpry = partnerRepositpry;
            _importanceRepositpry = importanceRepositpry;
            _taskTypeRepository = taskTypeRepository;
        }

        public async Task<Guid> Handle(CreateDocumentTaskCommand request, CancellationToken cancellationToken)
        {
            var documentTask = await DocumentTaskMapperAsync(request.Task);

            await _taskRepository.AddAsync(documentTask);

            return documentTask.Id;
        }

        private async Task<DocumentTask> DocumentTaskMapperAsync(CreateOrEditDocumentTask request)
        {
            var documentTask = new DocumentTask();

            documentTask.UtId = request.UtId;

            documentTask.Author = await GetResponsibleAsync(request.Author);

            documentTask.Executor = await GetResponsibleAsync(request.Executor);

            documentTask.Name = request.Name;

            documentTask.Description = request.Description;

            documentTask.Report = request.Report;

            documentTask.Partner = await GetPartnerAsync(request.Partner);

            documentTask.Importance = await GetImportanceAsync(request.Importance);

            documentTask.Priority = request.Priority;

            documentTask.TaskType = await GetTaskType(request.TaskType);

            documentTask.DateStart = request.DateStart;

            return documentTask;
        }

        private async Task<Responsible> GetResponsibleAsync(ResponsibleCreateOrEdit requestAuthor)
        {
            var responsible = await _responsibleRepository.GetFirstWhere(x => x.UtId == requestAuthor.UtId);

            return responsible;
        }

        private async Task<Partner> GetPartnerAsync(PartnerCreateOrEdit requestPartner)
        {
            var partner = await _partnerRepositpry.GetFirstWhere(x => x.UtId == requestPartner.UtId);

            return partner;
        }

        private async Task<Importance> GetImportanceAsync(string requestImportance)
        {
            var importance = await _importanceRepositpry.GetFirstWhere(x => x.Name == requestImportance);

            return importance;
        }

        private async Task<TaskType> GetTaskType(string requestTaskType)
        {
            var taskType = await _taskTypeRepository.GetFirstWhere(x => x.Name == requestTaskType);
                
            return taskType;
        }
    }
}
