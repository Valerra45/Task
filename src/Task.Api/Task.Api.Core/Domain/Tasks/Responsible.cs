namespace Tasks.Api.Core.Domain.Tasks
{
    public class Responsible : BaseEntity
    {
        public Guid UtId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? User { get; set; }

        public virtual List<DocumentTask>? DocumentTasks1 { get; set; }

        public virtual List<DocumentTask>? DocumentTasks2 { get; set; }
    }
}
