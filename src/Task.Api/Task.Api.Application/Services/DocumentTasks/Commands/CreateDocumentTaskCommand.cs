using AutoMapper;
using MediatR;
using Tasks.Api.Application.Services.Partners;
using Tasks.Api.Application.Services.Responsibles;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;
using Tasks.Api.Core.Exceptions;

namespace Tasks.Api.Application.Services.Tasks.Commands
{
    public class CreateDocumentTaskCommand : IRequest<Guid>
    {
        public DocumentTaskCreateOrEdit DocumentTask { get; }

        public CreateDocumentTaskCommand(DocumentTaskCreateOrEdit documentTask)
        {
            DocumentTask = documentTask;
        }
    }

    public class CreateDocumentTaskCommandHandler : IRequestHandler<CreateDocumentTaskCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DocumentTask> _documentTaskRepository;
        private readonly IRepository<Responsible> _responsibleRepository;
        private readonly IRepository<Partner> _partnerRepositpry;
        private readonly IRepository<Importance> _importanceRepositpry;
        private readonly IRepository<TaskType> _taskTypeRepository;
        private readonly IRepository<Product> _productRepositpry;

        public CreateDocumentTaskCommandHandler(IMapper mapper,
            IRepository<DocumentTask> documentTaskRepository,
            IRepository<Responsible> responsibleRepository,
            IRepository<Partner> partnerRepositpry,
            IRepository<Importance> importanceRepositpry,
            IRepository<TaskType> taskTypeRepository,
            IRepository<Product> productRepositpry)
        {
            _mapper = mapper;
            _documentTaskRepository = documentTaskRepository;
            _responsibleRepository = responsibleRepository;
            _partnerRepositpry = partnerRepositpry;
            _importanceRepositpry = importanceRepositpry;
            _taskTypeRepository = taskTypeRepository;
            _productRepositpry = productRepositpry;
        }

        public async Task<Guid> Handle(CreateDocumentTaskCommand request, CancellationToken cancellationToken)
        {
            var documentTask = _mapper.Map<DocumentTask>(request.DocumentTask);

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

            documentTask.TaskProducts = new List<TaskProduct>();

            foreach (var productRequest in request.DocumentTask.Products)
            {
                var product = await _productRepositpry.GetByIdAsync(productRequest.ProductId);

                if (product is null)
                {
                    throw new EntityNotFoundException($"{nameof(Product)} with id '{productRequest.ProductId}' doesn't exist");
                }

                var taskProduct = new TaskProduct
                {
                    Product = product,
                    Discount = productRequest.Discount,
                    Margin = productRequest.Margin,
                    Enable = productRequest.Enable
                };

                documentTask.TaskProducts.Add(taskProduct);
            }

            documentTask.Author = author;
            documentTask.Executor = executor;
            documentTask.Partner = partner;
            documentTask.Importance = importance;
            documentTask.TaskType = taskType;

            await _documentTaskRepository.AddAsync(documentTask);

            return documentTask.Id;
        }
    }
}
