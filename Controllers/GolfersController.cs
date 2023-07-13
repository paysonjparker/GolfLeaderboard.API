using GolfLeaderboard.API.Business;
using GolfLeaderboard.API.Data;
using GolfLeaderboard.API.Models.DomainModels;
using GolfLeaderboard.API.Models.DTO.GolfCourseDTO;
using GolfLeaderboard.API.Models.DTO.GolferDTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolfLeaderboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAngularOrigins")]
    public class GolfersController : ControllerBase
    {
        private GolferService _golferService;

        public GolfersController(GolfLeaderboardDbContext dbContext)
        {
            this._golferService = new GolferService(dbContext);
        }

        [HttpPost]
        public IActionResult AddGolfer(AddGolferRequest addGolferRequest)
        {
            var golfer = _golferService.AddGolfer(addGolferRequest);

            return Ok(golfer);
        }

        [HttpGet]
        public IActionResult GetAllGolfers()
        {
            var golfersDTO = _golferService.GetAllGolfers();

            return Ok(golfersDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetGolferById(Guid id)
        {
            var golferDTO = _golferService.GetGolferById(id);

            if (golferDTO != null)
            {
                return Ok(golferDTO);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateGolfer(Guid id, UpdateGolferRequest updateGolferRequest)
        {
            var exisitngGolfer = _golferService.UpdateGolfer(id, updateGolferRequest);

            if (exisitngGolfer != null)
            {
                return Ok(exisitngGolfer);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteGolfer(Guid id)
        {
            var existingGolfer = _golferService.DeleteGolfer(id);

            if (existingGolfer != false)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
