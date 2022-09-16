using Tasks.Api.Application.Services.DocumentTasks;
using Tasks.Api.Application.Services.Partners;
using Tasks.Api.Application.Services.Responsibles;

namespace Tasks.Api.Application.Services.Tasks
{
    public class DocumentTaskCreateOrEdit
    {
        public Guid UtId { get; set; }

        public Guid AuthorId { get; set; }

        public Guid ExecutorId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Report { get; set; }

        public Guid PartnerId { get; set; }

        public Guid ImportanceId { get; set; }

        public int Priority { get; set; }

        public Guid TaskTypeId { get; set; }

        public bool Viewed { get; set; }
        
        public bool Completed { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public DateTime? DateCompleted { get; set; }

        public List<TaskProductRespons>? Products { get; set; }
    }
}
