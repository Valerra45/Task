using AutoMapper;
using Tasks.Api.Application.Services.Importances;
using Tasks.Api.Application.Services.Paetners;
using Tasks.Api.Application.Services.Responsibles;
using Tasks.Api.Application.Services.TaskTypes;
using Tasks.Api.Core.Domain.Tasks;

namespace Tasks.Api.Application.MapProfiles
{
    public class TaskMapPfofile : Profile
    {
        public TaskMapPfofile()
        {
            CreateMap<TaskType, TaskTypeResponse>()
                .ReverseMap();

            CreateMap<TaskType, TaskTypeCreateOrEdit>()
                .ReverseMap();

            CreateMap<Importance, ImportanceResponse>()
                .ReverseMap();

            CreateMap<Importance, ImportanceCreateOrEdit>()
             .ReverseMap();

            CreateMap<Responsible, CreateOrEditResponsible>()
                .ReverseMap();

            CreateMap<Partner, CreateOrEditPartner>()
                .ReverseMap();
        }
    }
}
