namespace Tasks.Api.Core.Domain.Tasks
{
    public class TaskType : BaseEntity
    {
        public Guid UtId { get; set; }

        public string? Name { get; set; }

        public virtual List<DocumentTask>? DocumentTasks { get; set; }
    }
}
