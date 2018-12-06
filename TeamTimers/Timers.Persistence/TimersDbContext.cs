using Microsoft.EntityFrameworkCore;
using Timers.Domain.Entities;
using Timers.Persistence.Extensions;

namespace Timers.Persistence
{
    public class TimersDbContext : DbContext
    {
        public TimersDbContext(DbContextOptions<TimersDbContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<GameSetting> GameSettings { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=timers.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
        }
    }
}
