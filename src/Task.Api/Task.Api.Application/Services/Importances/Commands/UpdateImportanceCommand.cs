using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Api.Core.Domain.Tasks;
using Tasks.Api.Core.Exceptions;

namespace Tasks.Api.Application.Services.Importances.Commands
{
    public class UpdateImportanceCommand : IRequest<Guid>
    {
        public Guid Id { get; }

        public ImportanceCreateOrEdit Importance { get; }

        public UpdateImportanceCommand(Guid id, ImportanceCreateOrEdit importance)
        {
            Id = id;
            Importance = importance;
        }

    }

    public class UpdateImportanceCommandHandler : IRequestHandler<UpdateImportanceCommand, Guid>
    {
        private readonly IRepository<Importance> _importanceRepository;

        public UpdateImportanceCommandHandler(IRepository<Importance> importanceRepository)
        {
            _importanceRepository = importanceRepository;
        }

        public async Task<Guid> Handle(UpdateImportanceCommand request, CancellationToken cancellationToken)
        {
            var importance = await _importanceRepository.GetByIdAsync(request.Id);

            if (importance is null)
            {
                throw new EntityNotFoundException($"{nameof(Importance)} with id '{request.Id}' doesn't exist");
            }

            importance.Name = request.Importance.Name;
            importance.Update = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Russian Standard Time");

            await _importanceRepository.UpdateAsync(importance);

            return importance.Id;
        }
    }
}
