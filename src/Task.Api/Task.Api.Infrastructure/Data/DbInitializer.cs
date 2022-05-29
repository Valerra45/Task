using Tasks.Api.Core.Abstractions;

namespace Tasks.Api.Infrastructure.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly TaskDbContext _context;

        public DbInitializer(TaskDbContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.Database.EnsureDeleted();

            if (_context.Database.EnsureCreated())
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                _context.TaskTypes.AddRange(FakeDataFactory.TaskTypes());

                _context.Importances.AddRange(FakeDataFactory.Importances());
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                _context.SaveChanges();
            }
        }
    }
}
