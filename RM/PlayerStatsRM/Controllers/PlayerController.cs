using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PlayerStatsRM;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly PlayerDbContext _context;

    public PlayerController(PlayerDbContext context)
    {
        _context = context;
    }

    [HttpGet("topscorers")]
    public async Task<IActionResult> GetTopScorers([FromQuery] int page = 1, [FromQuery] int size = 5)
    {
        var players = await _context.Players
            .OrderByDescending(p => p.Goals)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();

        return Ok(players);
    }

    [HttpPost]
    public async Task<IActionResult> AddPlayer([FromBody] Player player)
    {
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTopScorers), new { id = player.Id }, player);
    }

    [HttpPost("{id}/gol")]
    public async Task<IActionResult> IncrementGoals(int id)
    {
        var player = await _context.Players.FindAsync(id);
        if (player == null)
        {
            return NotFound();
        }

        player.Goals++;
        await _context.SaveChangesAsync();
        return NoContent();
    }
}