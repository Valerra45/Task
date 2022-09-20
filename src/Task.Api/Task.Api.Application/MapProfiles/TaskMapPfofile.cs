using AutoMapper;
using Tasks.Api.Application.Services.DocumentTasks;
using Tasks.Api.Application.Services.Importances;
using Tasks.Api.Application.Services.Partners;
using Tasks.Api.Application.Services.Products;
using Tasks.Api.Application.Services.Responsibles;
using Tasks.Api.Application.Services.Tasks;
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

            CreateMap<Responsible, ResponsibleCreateOrEdit>()
                .ReverseMap();

            CreateMap<Responsible, ResponsibleResponse>()
                .ReverseMap();

            CreateMap<Partner, PartnerCreateOrEdit>()
                .ReverseMap();

            CreateMap<Partner, PartnerResponse>()
                .ReverseMap();

            CreateMap<DocumentTask, DocumentTaskCreateOrEdit>()
                .ReverseMap();

            CreateMap<DocumentTask, DocumentTaskShortResponse>()
                .ReverseMap();

            CreateMap<DocumentTask, DocumentTaskResponse>()
                .ReverseMap();

            CreateMap<Product, ProductResponse>()
                .ReverseMap();

            CreateMap<Product, ProductCreateOrEdit>()
                .ReverseMap();

            CreateMap<TaskProduct, TaskProductCreateOrEdit>()
              .ReverseMap();

            CreateMap<TaskProduct, TaskProductResponse>()
               .ReverseMap();
        }
    }
}
