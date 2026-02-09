using Xunit;
using Microsoft.EntityFrameworkCore;
using PlayerStatsRM;

namespace PlayerStatsRM.Tests;

public class PlayerDbContextTests
{
    private PlayerDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<PlayerDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new PlayerDbContext(options);
    }

    [Fact]
    public async Task DbContext_CanAddPlayer()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var player = new Player { Name = "Test Player", Goals = 5 };

        // Act
        context.Players.Add(player);
        await context.SaveChangesAsync();

        // Assert
        var savedPlayer = await context.Players.FirstOrDefaultAsync(p => p.Name == "Test Player");
        Assert.NotNull(savedPlayer);
        Assert.Equal(5, savedPlayer.Goals);
    }

    [Fact]
    public async Task DbContext_CanQueryPlayers()
    {
        // Arrange
        var context = GetInMemoryDbContext();

        // Act
        var players = await context.Players.ToListAsync();

        // Assert
        Assert.NotEmpty(players);
        Assert.Contains(players, p => p.Name == "Mbappe");
        Assert.Contains(players, p => p.Name == "Vinicius");
        Assert.Contains(players, p => p.Name == "Bellingham");
    }

    [Fact]
    public async Task DbContext_SeedData_HasCorrectGoals()
    {
        // Arrange
        var context = GetInMemoryDbContext();

        // Act
        var mbappe = await context.Players.FirstOrDefaultAsync(p => p.Name == "Mbappe");
        var vinicius = await context.Players.FirstOrDefaultAsync(p => p.Name == "Vinicius");
        var bellingham = await context.Players.FirstOrDefaultAsync(p => p.Name == "Bellingham");

        // Assert
        Assert.NotNull(mbappe);
        Assert.Equal(25, mbappe.Goals);

        Assert.NotNull(vinicius);
        Assert.Equal(22, vinicius.Goals);

        Assert.NotNull(bellingham);
        Assert.Equal(15, bellingham.Goals);
    }

    [Fact]
    public async Task DbContext_CanUpdatePlayer()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var player = new Player { Name = "Update Test", Goals = 10 };
        context.Players.Add(player);
        await context.SaveChangesAsync();

        // Act
        player.Goals = 15;
        await context.SaveChangesAsync();

        // Assert
        var updatedPlayer = await context.Players.FirstOrDefaultAsync(p => p.Name == "Update Test");
        Assert.NotNull(updatedPlayer);
        Assert.Equal(15, updatedPlayer.Goals);
    }

    [Fact]
    public async Task DbContext_CanDeletePlayer()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var player = new Player { Name = "Delete Test", Goals = 5 };
        context.Players.Add(player);
        await context.SaveChangesAsync();

        // Act
        context.Players.Remove(player);
        await context.SaveChangesAsync();

        // Assert
        var deletedPlayer = await context.Players.FirstOrDefaultAsync(p => p.Name == "Delete Test");
        Assert.Null(deletedPlayer);
    }

    [Fact]
    public async Task DbContext_CanFilterPlayersByGoals()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        context.Players.Add(new Player { Name = "Low Scorer", Goals = 2 });
        context.Players.Add(new Player { Name = "High Scorer", Goals = 30 });
        await context.SaveChangesAsync();

        // Act
        var highScorers = await context.Players
            .Where(p => p.Goals >= 20)
            .ToListAsync();

        // Assert
        Assert.NotEmpty(highScorers);
        Assert.True(highScorers.All(p => p.Goals >= 20));
    }
}
