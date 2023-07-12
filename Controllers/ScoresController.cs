using GolfLeaderboard.API.Business;
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
        private ScoreService _scoreService;

        public ScoresController(GolfLeaderboardDbContext dbContext)
        {
            this._scoreService = new ScoreService(dbContext);
        }

        [HttpPost]
        public IActionResult AddScore(AddScoreRequest addScoreRequest)
        {
            var score = _scoreService.AddScore(addScoreRequest);

            return Ok(score);
        }

        [HttpGet]
        public IActionResult GetAllScores()
        {
            var scoresDTO = _scoreService.GetAllScores();
          
            return Ok(scoresDTO);
        }

        [HttpGet]
        [Route("{golferId:Guid}")]
        public IActionResult GetAllScoresByGolfer(Guid golferId)
        {      
            var scoresDTO = _scoreService.GetAllScoresByGolfer(golferId);
            
            return Ok(scoresDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateScore(Guid id, UpdateScoreRequest updateScoreRequest)
        {
            var existingScore = _scoreService.UpdateScore(id, updateScoreRequest);

            if (existingScore != null)
            {                
                return Ok(existingScore);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteScore(Guid id)
        {
            var existingScore = _scoreService.DeleteScore(id);

            if (existingScore != false)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
