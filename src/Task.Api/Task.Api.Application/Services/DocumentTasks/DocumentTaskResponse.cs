using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.Importances;
using Tasks.Api.Application.Services.Partners;
using Tasks.Api.Application.Services.Responsibles;
using Tasks.Api.Application.Services.TaskTypes;

namespace Tasks.Api.Application.Services.DocumentTasks
{
    public class DocumentTaskResponse
    {
        public Guid Id { get; set; }

        public ResponsibleResponse? Author { get; set; }

        public ResponsibleResponse? Executor { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Report { get; set; }

        public PartnerResponse? Partner { get; set; }

        public ImportanceResponse? Importance { get; set; }

        public int Priority { get; set; }

        public TaskTypeResponse? TaskType { get; set; }

        public bool Viewed { get; set; }

        public bool Completed { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public DateTime? DateCompleted { get; set; }

        public int OffSet { get; set; }

        public List<TaskProductRespons>? Products { get; set; }
    }
}
