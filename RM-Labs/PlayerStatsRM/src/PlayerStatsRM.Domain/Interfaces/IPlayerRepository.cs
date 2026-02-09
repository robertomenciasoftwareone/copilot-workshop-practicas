using PlayerStatsRM.Domain.Entities;

namespace PlayerStatsRM.Domain.Interfaces;

public interface IPlayerRepository
{
    Task<IEnumerable<Player>> GetTopScorersAsync(int top);
    Task AddPlayerAsync(Player player);
}