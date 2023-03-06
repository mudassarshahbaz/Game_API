using Game_API.DTO;
using Game_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_API.Repository
{
    public interface IGameRepository
    {
        public Task<GameResponseDTO> Get(GameResquestDTO gameResultDTO);
        public Task<GameResult> Post(GameResult gameResult);
    }
}
