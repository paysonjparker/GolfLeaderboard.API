using GolfLeaderboard.API.Business;
using GolfLeaderboard.API.Data;
using GolfLeaderboard.API.Models.DomainModels;
using GolfLeaderboard.API.Models.DTO.GolfCourseDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolfLeaderboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GolfCoursesController : ControllerBase
    {
        private GolfCourseService _golfCourseService;

        public GolfCoursesController(GolfLeaderboardDbContext dbContext)
        {
            this._golfCourseService = new GolfCourseService(dbContext);
        }

        [HttpPost]
        public IActionResult AddGolfCourse(AddGolfCourseRequest addGolfCourseRequest)
        {
            var createdGolfCourse = _golfCourseService.AddGolfCourse(addGolfCourseRequest);

            return Ok(createdGolfCourse);
        }

        [HttpGet]
        public IActionResult GetAllGolfCourses() 
        {
            var golfersDTO = _golfCourseService.GetAllGolfCourses();

            return Ok(golfersDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetGolfCourseById(Guid id)
        {
            var golfCourseDTO = _golfCourseService.GetGolfCourseById(id);
            
            if(golfCourseDTO != null)
            {
                return Ok(golfCourseDTO);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("{golfCourseName}")]
        public IActionResult GetGolfCourseById(string golfCourseName)
        {
            var golfCourseDTO = _golfCourseService.GetGolfCourseByName(golfCourseName);

            if (golfCourseDTO != null)
            {
                return Ok(golfCourseDTO);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateGolfCourse(Guid id, UpdateGolfCourseRequest updateGolfCourseRequest)
        {
            var existingGolfCourse = _golfCourseService.UpdateGolfCourse(id, updateGolfCourseRequest);

            if (existingGolfCourse != null)
            {
                return Ok(existingGolfCourse);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteGolfCourse(Guid id)
        {
            var deletedGolfCourse = _golfCourseService.DeleteGolfCourse(id);

            if (deletedGolfCourse != false)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
