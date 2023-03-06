using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_API.DTO
{
    public class GameResultDTO
    {
        public string UserId { get; set; }
        public int PlayerId { get; set; }
        public string GameName { get; set; }
        public long Timestamp { get; set; }
        public List<GameSessionDTO> Sessions { get; set; }
    }
}
