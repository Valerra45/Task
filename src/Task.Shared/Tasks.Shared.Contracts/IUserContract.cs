namespace Tasks.Shared.Contracts
{
    public interface IUserContract
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
