using GolfLeaderboard.API.Business;
using GolfLeaderboard.API.Data;
using GolfLeaderboard.API.Models.DTO.GolfCourseDTO;
using GolfLeaderboard.API.Models.DTO.LeaderboardDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolfLeaderboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderboardsController : ControllerBase
    {
        /*private LeaderboardService _leaderboardService;

        public LeaderboardsController(GolfLeaderboardDbContext dbContext)
        {
            this._leaderboardService = new LeaderboardService(dbContext);
        }

        [HttpPost]
        public IActionResult AddLeaderboard(AddLeaderboardRequest addLeaderboardRequest)
        {
            var createdLeaderboard = _leaderboardService.AddLeaderboard(addLeaderboardRequest);
            return Ok(createdLeaderboard);
        }

        [HttpGet]
        public IActionResult GetAllLeaderboards()
        {
            var leaderboardsDTO = _leaderboardService.GetAllLeaderboards();

            return Ok(leaderboardsDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetLeaderboardById(Guid id)
        {
            var leaderboardDTO = _leaderboardService.GetLeaderboardById(id);

            if (leaderboardDTO != null)
            {
                return Ok(leaderboardDTO);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateLeaderboard(Guid id, UpdateLeaderboardRequest updateLeaderboardRequest)

        {
            var existingLeaderboard = _leaderboardService.UpdateLeaderboard(id, updateLeaderboardRequest);

            if (existingLeaderboard != null)
            {
                return Ok(existingLeaderboard);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteLeaderboard(Guid id)
        {
            var deletedLeaderboard = _leaderboardService.DeleteLeaderboard(id);

            if (deletedLeaderboard != false)
            {
                return Ok();
            }

            return BadRequest();
        }*/
    }
}
