using PlayerStatsRM.Application.Commands;
using PlayerStatsRM.Application.DTOs;

namespace PlayerStatsRM.Application.Interfaces;

public interface IPlayerService
{
    Task<IEnumerable<PlayerDto>> GetTopScorersAsync(int top);
    Task CreatePlayerAsync(CreatePlayerCommand command);
}