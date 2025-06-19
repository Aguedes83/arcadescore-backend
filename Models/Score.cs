// Models/Score.cs
using System;

namespace ArcadeScore.Api.Models
{
    public class Score
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? PlayerName { get; set; }
        public DateTime MatchDate { get; set; }
        public int Points { get; set; }
    }
}
