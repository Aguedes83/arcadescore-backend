// Controllers/ScoresController.cs
using Microsoft.AspNetCore.Mvc;
using ArcadeScore.Api.Models;
using ArcadeScore.Api.Repositories;
using ArcadeScore.Api.Services;

namespace ArcadeScore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoresController : ControllerBase
    {
        private readonly InMemoryScoreRepository _repo;
        private readonly ScoreService _service;

        public ScoresController(InMemoryScoreRepository repo, ScoreService service)
        {
            _repo = repo;
            _service = service;
        }

        // POST: api/scores
        [HttpPost]
        public IActionResult AddScore([FromBody] Score score)
        {
            _repo.Add(score);
            return Ok(score);
        }

        // GET: api/scores
        [HttpGet]
        public IActionResult GetAllScores()
        {
            var scores = _repo.GetAll();
            return Ok(scores);
        }

        // GET: api/scores/top10
        [HttpGet("top10")]
        public IActionResult GetTop10()
        {
            return Ok(_repo.GetTop10());
        }

        // GET: api/scores/player/{name}
        [HttpGet("player/{name}")]
        public IActionResult GetPlayerStats(string name)
        {
            var stats = _service.GetStatistics(name);
            if (stats == null) return NotFound("Jogador não encontrado");
            return Ok(stats);
        }
    }
}
