namespace Tasks.Api.Core.Domain.Tasks
{
    public class Importance : BaseEntity
    {
        public string? Name { get; set; }

        public virtual List<DocumentTask>? DocumentTasks { get; set; }
    }
}
