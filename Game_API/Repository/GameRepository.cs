using Game_API.DTO;
using Game_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_API.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly GameContext _context;

        public GameRepository(GameContext context)
        {
            _context = context;
        }

        public async Task<GameResponseDTO> Get(GameResquestDTO gameResultDTO)
        {
            await _context.Database.EnsureCreatedAsync();
            var game = GetGame(gameResultDTO);

            if (await game.AnyAsync())
                return await game.FirstAsync();
            else
                return null;

        }
        public async Task<GameResult> Post(GameResult gameResult)
        {
            try
            {
                await _context.Database.EnsureCreatedAsync();
                await _context.GameResults.AddAsync(gameResult);
                await _context.SaveChangesAsync();
                return gameResult;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        private IQueryable<GameResponseDTO> GetGame(GameResquestDTO gameResultDTO)
        {
            return _context.GameResults.Include(x => x.Sessions).AsQueryable()
                .Where(x => x.UserId.Equals(gameResultDTO.UserId) && x.PlayerId.Equals(gameResultDTO.PlayerId) && x.GameName.Equals(gameResultDTO.GameName))
                .Select(x => new GameResponseDTO { NextDifficultyLevel = x.Sessions.First().DifficultyLevel, UserId = x.UserId, PlayerId = x.PlayerId, GameName = x.GameName});
        }
    }
}
