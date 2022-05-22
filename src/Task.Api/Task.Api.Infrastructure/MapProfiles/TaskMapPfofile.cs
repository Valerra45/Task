using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Domain.Tasks;
using Tasks.Api.Infrastructure.Services.Importances;
using Tasks.Api.Infrastructure.Services.TaskTypes;

namespace Tasks.Api.Infrastructure.MapProfiles
{
    public class TaskMapPfofile : Profile
    {
        public TaskMapPfofile()
        {
            CreateMap<TaskType, TaskTypeDto>()
              .ReverseMap();

            CreateMap<Importance, ImportanceDto>()
                .ReverseMap();
        }
    }
}
