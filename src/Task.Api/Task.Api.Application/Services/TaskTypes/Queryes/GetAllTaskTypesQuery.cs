using AutoMapper;
using MediatR;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;

namespace Tasks.Api.Application.Services.TaskTypes.Queryes
{
    public class GetAllTaskTypesQuery : IRequest<IEnumerable<TaskTypeResponse>> { }

    public class GetAllTaskTypesQueryHandler : IRequestHandler<GetAllTaskTypesQuery, IEnumerable<TaskTypeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TaskType> _taskTypeRepository;

        public GetAllTaskTypesQueryHandler(IMapper mapper,
            IRepository<TaskType> taskTypeRepository)
        {
            _mapper = mapper;
            _taskTypeRepository = taskTypeRepository;
        }

        public async Task<IEnumerable<TaskTypeResponse>> Handle(GetAllTaskTypesQuery request, CancellationToken cancellationToken)
        {
            var taskTypes = await _taskTypeRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<TaskTypeResponse>>(taskTypes);
        }
    }
}
