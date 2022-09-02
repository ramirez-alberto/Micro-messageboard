using Microsoft.EntityFrameworkCore;
using Micro_messageboard.Models;

namespace Micro_messageboard.Data
{
    public class MicroMessageBoardContext : DbContext
    {
        public MicroMessageBoardContext(DbContextOptions<MicroMessageBoardContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; } = default!;

                /*specifying singular table names*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is User && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((User)entityEntry.Entity).UpdateTime = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((User)entityEntry.Entity).CreationTime = DateTime.Now;
                }
            }

            return base.SaveChangesAsync();
        }
    }
}
