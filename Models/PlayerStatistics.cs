// Models/PlayerStatistics.cs
using System;

namespace ArcadeScore.Api.Models
{
    public class PlayerStatistics
    {
        public string PlayerName { get; set; } = string.Empty;
        public int TotalMatches { get; set; }
        public double AveragePoints { get; set; }
        public int MaxPoints { get; set; }
        public int MinPoints { get; set; }
        public int RecordBreaks { get; set; }
        public string? PlayPeriod { get; set; }
    }
}
