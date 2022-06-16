namespace Tasks.Api.Application.Services.Partners
{
    public class PartnerCreateOrEdit
    {
        public Guid UtId { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Description { get; set; }

        public string? Phone { get; set; }
    }
}
