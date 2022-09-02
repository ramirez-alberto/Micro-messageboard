using Microsoft.EntityFrameworkCore;
using Micro_messageboard.Models;

namespace Micro_messageboard.Data
{
    public class MicroMessageBoardContext : DbContext
    {
        public MicroMessageBoardContext(DbContextOptions<MicroMessageBoardContext> options) : base(options)
            { }

        public DbSet<User> Users { get; set; }
    }
}
