namespace Tasks.Api.Core.Domain
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Created = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Russian Standard Time");

            Update = Created;
        }

        public Guid Id { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Update { get; set; }
    }
}
