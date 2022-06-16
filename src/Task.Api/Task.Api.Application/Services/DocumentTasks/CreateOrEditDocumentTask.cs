using Tasks.Api.Application.Services.Partners;
using Tasks.Api.Application.Services.Responsibles;

namespace Tasks.Api.Application.Services.Tasks
{
    public class CreateOrEditDocumentTask
    {
        public Guid UtId { get; set; }

        public virtual ResponsibleCreateOrEdit? Author { get; set; }

        public virtual ResponsibleCreateOrEdit? Executor { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Report { get; set; }

        public virtual PartnerCreateOrEdit? Partner { get; set; }

        public string? Importance { get; set; }

        public int Priority { get; set; }

        public string? TaskType { get; set; }

        public bool Viewed { get; set; }
        
        public bool Completed { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public DateTime? DateCompleted { get; set; }
    }
}
