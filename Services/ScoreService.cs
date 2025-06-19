// Services/ScoreService.cs
using ArcadeScore.Api.Models;
using ArcadeScore.Api.Repositories;
using System;
using System.Linq;

namespace ArcadeScore.Api.Services
{
    public class ScoreService
    {
        private readonly InMemoryScoreRepository _repo;

        public ScoreService(InMemoryScoreRepository repo)
        {
            _repo = repo;
        }

        public PlayerStatistics? GetStatistics(string player)
        {
            var scores = _repo.GetByPlayer(player);
            if (!scores.Any()) return null;

            var orderedScores = scores.OrderBy(s => s.MatchDate).ToList();

            int recordBreaks = 0;
            int currentRecord = int.MinValue;

            foreach (var score in orderedScores)
            {
                if (score.Points > currentRecord)
                {
                    if (currentRecord != int.MinValue) recordBreaks++;
                    currentRecord = score.Points;
                }
            }

            
            var firstDate = orderedScores.First().MatchDate;
            var lastDate = orderedScores.Last().MatchDate;
            var timeSpan = lastDate - firstDate;

            string playPeriodFormatted = $"{timeSpan.Days} dias, {timeSpan.Hours} horas, {timeSpan.Minutes} minutos";


            return new PlayerStatistics
            {
                PlayerName = player,
                TotalMatches = scores.Count,
                AveragePoints = scores.Average(s => s.Points),
                MaxPoints = scores.Max(s => s.Points),
                MinPoints = scores.Min(s => s.Points),
                RecordBreaks = recordBreaks,
                PlayPeriod = playPeriodFormatted
            };
        }
    }
}
