using GolfLeaderboard.API.Data;
using GolfLeaderboard.API.Models.DTO.GolferDTO;
using GolfLeaderboard.API.Models.DTO.ScoreDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolfLeaderboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly GolfLeaderboardDbContext _dbContext;

        public ScoresController(GolfLeaderboardDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult AddScore(AddScoreRequest addScoreRequest)
        {
            // Convert DTO to Domain Model
            var score = new Models.DomainModels.Score
            {
                Total = addScoreRequest.Total,
            };

            _dbContext.Scores.Add(score);
            _dbContext.SaveChanges();

            return Ok(score);
        }

        [HttpGet]
        public IActionResult GetAllScores()
        {
            var scores = _dbContext.Scores.ToList();

            var scoresDTO = new List<Models.DTO.ScoreDTO.Score>();
            foreach (var score in scores)
            {
                scoresDTO.Add(new Models.DTO.ScoreDTO.Score
                {
                    Id = score.Id,
                    Total = score.Total,
                });
            }

            return Ok(scoresDTO);
        }

        [HttpGet]
        [Route("{golferId:Guid}")]
        public IActionResult GetAllScoresByGolfer(Guid golferId)
        {

            var scores = _dbContext.Scores.ToList();

            var scoresDTO = new List<Models.DTO.ScoreDTO.Score>();
            foreach (var score in scores)
            {
                if(score.Id == golferId) 
                {
                    scoresDTO.Add(new Models.DTO.ScoreDTO.Score
                    {
                        Id = score.Id,
                        Total = score.Total,
                    });
                }
            }

            return Ok(scoresDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateScore(Guid id, UpdateScoreRequest updateScoreRequest)
        {
            var existingScore = _dbContext.Scores.Find(id);

            if (existingScore != null)
            {
                existingScore.Total = updateScoreRequest.Total;

                _dbContext.SaveChanges();
                return Ok(existingScore);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteScore(Guid id)
        {
            var existingScore = _dbContext.Scores.Find(id);

            if (existingScore != null)
            {
                _dbContext.Scores.Remove(existingScore);
                _dbContext.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }
    }
}
