namespace Tasks.Api.Core.Domain.Tasks
{
    public class Importance : BaseEntity
    {
        public Guid UtId { get; set; }

        public string? Name { get; set; }

        public virtual List<DocumentTask>? DocumentTasks { get; set; }
    }
}
