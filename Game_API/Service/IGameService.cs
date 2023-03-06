using Game_API.DTO;
using Game_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_API.Service
{
    public interface IGameService
    {
        public Task<GameResponseDTO> Get(GameResquestDTO gameResultDto);
        public Task<GameResultDTO> Post(GameResultDTO gameResult);
    }
}
