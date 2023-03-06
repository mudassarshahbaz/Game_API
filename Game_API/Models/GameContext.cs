using Game_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_API
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base (options)
        {

        }

        public DbSet<GameResult> GameResults { get; set; }
        public DbSet<GameSession> GameSession { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
