using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_API.DTO
{
    public class GameResponseDTO: GameResquestDTO
    {
        public int NextDifficultyLevel { get; set; }
    }
}
