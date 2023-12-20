

using Foreveryone.Entities;
using Microsoft.EntityFrameworkCore;

namespace Foreveryone{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Player> Players {get; set;}
        public DbSet<Warrior> Warriors {get; set;}
    }
}