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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentTask>().HasKey(sc => new { sc.AuthorId, sc.ExecutorId });

            modelBuilder.Entity<DocumentTask>()
                .HasOne(m => m.Author)
                .WithMany(t => t.DocumentTasks1)
                .HasForeignKey(m => m.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DocumentTask>()
                .HasOne(m => m.Executor)
                .WithMany(t => t.DocumentTasks2)
                .HasForeignKey(m => m.ExecutorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

