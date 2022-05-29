using Microsoft.EntityFrameworkCore;
using Tasks.Api.Core.Domain.Tasks;

namespace Tasks.Api.Infrastructure
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options)
            : base(options)
        {

        }

        public DbSet<DocumentTask>? DocumentTasks { get; set; }

        public DbSet<Responsible>? Responsible { get; set; }

        public DbSet<Partner>? Partners { get; set; }

        public DbSet<Importance>? Importances { get; set; }

        public DbSet<TaskType>? TaskTypes { get; set; }
    }
}

