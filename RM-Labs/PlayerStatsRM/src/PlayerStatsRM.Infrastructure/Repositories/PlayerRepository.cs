using Microsoft.EntityFrameworkCore;
using PlayerStatsRM.Domain.Entities;
using PlayerStatsRM.Domain.Interfaces;
using PlayerStatsRM.Infrastructure.Persistence;

namespace PlayerStatsRM.Infrastructure.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly PlayerDbContext _context;

    public PlayerRepository(PlayerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Player>> GetTopScorersAsync(int top)
    {
        return await _context.Players
            .OrderByDescending(p => p.GolesTemporada)
            .Take(top)
            .ToListAsync();
    }

    public async Task AddPlayerAsync(Player player)
    {
        await _context.Players.AddAsync(player);
        await _context.SaveChangesAsync();
    }
}