using Game_API.DTO;
using Game_API.Models;
using Game_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_API.Service
{
    public class GameService: IGameService
    {
        private readonly IGameRepository _repository;

        public GameService(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task<GameResponseDTO> Get(GameResquestDTO gameResultDTO)
        {
            var result = await _repository.Get(gameResultDTO);
            if (result == null)
                return null;

            return new GameResponseDTO()
            {
                NextDifficultyLevel = result.NextDifficultyLevel,
                UserId = result.UserId,
                PlayerId = result.PlayerId,
                GameName = result.GameName
            };
        }

        public async Task<GameResultDTO> Post(GameResultDTO gameResult)
        {
            var gameResultObj =  new GameResult();
            var mappedGameResult = gameResultObj.MappDTOToGameResult(gameResult);
            var response = await _repository.Post(mappedGameResult);
            var mappedToDTO = gameResultObj.MappGameResultToDTO(response);
            return mappedToDTO;
        }
    }
}
