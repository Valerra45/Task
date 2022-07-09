namespace Tasks.Api.Core.Domain
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Created = DateTime.Now;

            Update = Created;
        }

        public Guid Id { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Update { get; set; }
    }
}
