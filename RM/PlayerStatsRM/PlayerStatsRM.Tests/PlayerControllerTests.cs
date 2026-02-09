using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayerStatsRM;

namespace PlayerStatsRM.Tests;

public class PlayerControllerTests
{
    private PlayerDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<PlayerDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new PlayerDbContext(options);
    }

    [Fact]
    public async Task GetTopScorers_ReturnsOrderedPlayersByGoals()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var controller = new PlayerController(context);

        // Act
        var result = await controller.GetTopScorers(page: 1, size: 5);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedPlayers = Assert.IsType<List<Player>>(okResult.Value);
        Assert.NotEmpty(returnedPlayers);
        Assert.Equal("Mbappe", returnedPlayers.First().Name);
        Assert.Equal(25, returnedPlayers.First().Goals);
    }

    [Fact]
    public async Task GetTopScorers_WithPagination_ReturnsPaginatedResults()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        context.Players.Add(new Player { Id = 1, Name = "Player1", Goals = 10 });
        context.Players.Add(new Player { Id = 2, Name = "Player2", Goals = 8 });
        context.Players.Add(new Player { Id = 3, Name = "Player3", Goals = 6 });
        await context.SaveChangesAsync();

        var controller = new PlayerController(context);

        // Act
        var result = await controller.GetTopScorers(page: 1, size: 2);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedPlayers = Assert.IsType<List<Player>>(okResult.Value);
        Assert.Equal(2, returnedPlayers.Count);
    }

    [Fact]
    public async Task AddPlayer_CreatesNewPlayerSuccessfully()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var controller = new PlayerController(context);
        var newPlayer = new Player { Name = "New Player", Goals = 5 };

        // Act
        var result = await controller.AddPlayer(newPlayer);

        // Assert
        Assert.IsType<CreatedAtActionResult>(result);
        var savedPlayer = await context.Players.FirstOrDefaultAsync(p => p.Name == "New Player");
        Assert.NotNull(savedPlayer);
        Assert.Equal(5, savedPlayer.Goals);
    }

    [Fact]
    public async Task IncrementGoals_IncrementsPlayerGoals()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var player = new Player { Id = 1, Name = "Test Player", Goals = 10 };
        context.Players.Add(player);
        await context.SaveChangesAsync();

        var controller = new PlayerController(context);

        // Act
        var result = await controller.IncrementGoals(id: 1);

        // Assert
        Assert.IsType<NoContentResult>(result);
        var updatedPlayer = await context.Players.FindAsync(1);
        Assert.NotNull(updatedPlayer);
        Assert.Equal(11, updatedPlayer.Goals);
    }

    [Fact]
    public async Task IncrementGoals_WithInvalidId_ReturnsNotFound()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var controller = new PlayerController(context);

        // Act
        var result = await controller.IncrementGoals(id: 999);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetTopScorers_WithPage2_SkipsPreviousPlayers()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        for (int i = 1; i <= 10; i++)
        {
            context.Players.Add(new Player { Id = i, Name = $"Player{i}", Goals = 20 - i });
        }
        await context.SaveChangesAsync();

        var controller = new PlayerController(context);

        // Act
        var result = await controller.GetTopScorers(page: 2, size: 3);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedPlayers = Assert.IsType<List<Player>>(okResult.Value);
        Assert.Equal(3, returnedPlayers.Count);
    }
}
