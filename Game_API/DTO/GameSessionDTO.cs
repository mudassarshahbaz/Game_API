using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_API.DTO
{
    public class GameSessionDTO
    {
        public int DurationSeconds { get; set; }
        public long StartTimeStamp { get; set; }
        public long EndTimeStamp { get; set; }
        public int PositiveActions { get; set; }
        public int NegativeActions { get; set; }
        public int DifficultyLevel { get; set; }
        public string Outcome { get; set; }
    }
}
