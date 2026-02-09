using Microsoft.EntityFrameworkCore;
using PlayerStatsRM.Domain.Entities;

namespace PlayerStatsRM.Infrastructure.Persistence;

public class PlayerDbContext : DbContext
{
    public PlayerDbContext(DbContextOptions<PlayerDbContext> options) : base(options) { }

    public DbSet<Player> Players { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Player>().HasData(
            new Player { Id = 1, Name = "Mbappe", Goals = 25 },
            new Player { Id = 2, Name = "Vinicius", Goals = 22 },
            new Player { Id = 3, Name = "Bellingham", Goals = 15 }
        );
    }
}