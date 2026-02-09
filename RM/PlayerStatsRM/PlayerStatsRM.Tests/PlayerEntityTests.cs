using Xunit;
using PlayerStatsRM;

namespace PlayerStatsRM.Tests;

public class PlayerEntityTests
{
    [Fact]
    public void Player_CanBeInstantiated()
    {
        // Arrange & Act
        var player = new Player { Id = 1, Name = "Test Player", Goals = 10 };

        // Assert
        Assert.Equal(1, player.Id);
        Assert.Equal("Test Player", player.Name);
        Assert.Equal(10, player.Goals);
    }

    [Fact]
    public void Player_DefaultNameIsEmpty()
    {
        // Arrange & Act
        var player = new Player();

        // Assert
        Assert.Equal(string.Empty, player.Name);
    }

    [Fact]
    public void Player_GoalsCanBeIncremented()
    {
        // Arrange
        var player = new Player { Name = "Test", Goals = 5 };

        // Act
        player.Goals++;

        // Assert
        Assert.Equal(6, player.Goals);
    }

    [Fact]
    public void Player_GoalsCanBeSet()
    {
        // Arrange
        var player = new Player { Name = "Test", Goals = 0 };

        // Act
        player.Goals = 25;

        // Assert
        Assert.Equal(25, player.Goals);
    }

    [Theory]
    [InlineData("Mbappe", 25)]
    [InlineData("Vinicius", 22)]
    [InlineData("Bellingham", 15)]
    public void Player_CanHaveDifferentNames(string name, int goals)
    {
        // Arrange & Act
        var player = new Player { Name = name, Goals = goals };

        // Assert
        Assert.Equal(name, player.Name);
        Assert.Equal(goals, player.Goals);
    }
}
