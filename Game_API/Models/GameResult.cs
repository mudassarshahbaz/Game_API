using Game_API.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Game_API.Models
{
    public class GameResult
    {
        [Key]
        public int PkGameResultId { get; set; }
        public string UserId { get; set; }
        public int PlayerId { get; set; }
        public string GameName { get; set; }
        public long Timestamp { get; set; }
        public List<GameSession> Sessions { get; set; }

        public GameResult MappDTOToGameResult(GameResultDTO gameResultDTO)
        {
            var sessions = new List<GameSession>();
            
            foreach (var item in gameResultDTO.Sessions)
            {
                sessions.Add(new GameSession
                {
                    DurationSeconds = item.DurationSeconds,
                    StartTimeStamp = item.StartTimeStamp,
                    EndTimeStamp = item.EndTimeStamp,
                    PositiveActions = item.PositiveActions,
                    NegativeActions = item.NegativeActions,
                    DifficultyLevel = item.DifficultyLevel,
                    Outcome = item.Outcome
                });
            }

            var gameResult = new GameResult()
            {
                UserId = gameResultDTO.UserId,
                PlayerId = gameResultDTO.PlayerId,
                GameName = gameResultDTO.GameName,
                Timestamp = gameResultDTO.Timestamp,
                Sessions = sessions
            };

            return gameResult;
        }

        public GameResultDTO MappGameResultToDTO(GameResult gameResult)
        {
            var sessions = new List<GameSessionDTO>();

            foreach (var item in gameResult.Sessions)
            {
                sessions.Add(new GameSessionDTO
                {
                    DurationSeconds = item.DurationSeconds,
                    StartTimeStamp = item.StartTimeStamp,
                    EndTimeStamp = item.EndTimeStamp,
                    PositiveActions = item.PositiveActions,
                    NegativeActions = item.NegativeActions,
                    DifficultyLevel = item.DifficultyLevel,
                    Outcome = item.Outcome
                });
            }

            var gameResultDTO = new GameResultDTO()
            {
                UserId = gameResult.UserId,
                PlayerId = gameResult.PlayerId,
                GameName = gameResult.GameName,
                Timestamp = gameResult.Timestamp,
                Sessions = sessions
            };

            return gameResultDTO;
        }
    }
}
