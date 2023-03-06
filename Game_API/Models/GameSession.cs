using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Game_API.Models
{
    public class GameSession
    {
        [Key]
        public int PkGameSessionId { get; set; }
        public int DurationSeconds { get; set; }
        public long StartTimeStamp { get; set; }
        public long EndTimeStamp { get; set; }
        public int PositiveActions { get; set; }
        public int NegativeActions { get; set; }
        public int DifficultyLevel { get; set; }
        public string Outcome { get; set; }
        [ForeignKey("GameResult")]
        public int GameResultId { get; set; }
        public virtual GameResult GameResult { get; set; }
    }
}
