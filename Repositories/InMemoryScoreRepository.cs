// Repositories/InMemoryScoreRepository.cs
using ArcadeScore.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace ArcadeScore.Api.Repositories
{
    public class InMemoryScoreRepository
    {
        private readonly List<Score> _scores = new();

        public void Add(Score score)
        {
            _scores.Add(score);
        }

        public List<Score> GetAll() => _scores;

        public List<Score> GetTop10()
        {
            return _scores.OrderByDescending(s => s.Points).Take(10).ToList();
        }

        public List<Score> GetByPlayer(string playerName)
        {
            return _scores.Where(s => s.PlayerName.ToLower() == playerName.ToLower()).ToList();
        }
    }
}
