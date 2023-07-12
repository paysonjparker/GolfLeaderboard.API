﻿using GolfLeaderboard.API.Data;
using GolfLeaderboard.API.Models.DomainModels;
using GolfLeaderboard.API.Models.DTO.GolfCourseDTO;
using GolfLeaderboard.API.Models.DTO.GolferDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolfLeaderboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GolfersController : ControllerBase
    {
        private readonly GolfLeaderboardDbContext _dbContext;

        public GolfersController(GolfLeaderboardDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult AddGolfer(AddGolferRequest addGolferRequest)
        {
            // Convert DTO to Domain Model
            var golfer = new Models.DomainModels.Golfer
            {
                Name = addGolferRequest.Name,
                HandicapIndex = addGolferRequest.HandicapIndex,
                HomeCourse = addGolferRequest.HomeCourse,
                Scores = addGolferRequest.Scores,
            };

            _dbContext.Golfers.Add(golfer);
            _dbContext.SaveChanges();

            return Ok(golfer);
        }

        [HttpGet]
        public IActionResult GetAllGolfers()
        {
            var golfers = _dbContext.Golfers.ToList();

            var golfersDTO = new List<Models.DTO.GolferDTO.Golfer>();
            foreach (var golfer in golfers)
            {
                golfersDTO.Add(new Models.DTO.GolferDTO.Golfer
                {
                    Id = golfer.Id,
                    Name = golfer.Name,
                    HandicapIndex = golfer.HandicapIndex,
                    HomeCourse = golfer.HomeCourse,
                    Scores = golfer.Scores,
                });
            }

            return Ok(golfersDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetGolferById(Guid id)
        {
            var golferDomainObject = _dbContext.Golfers.Find(id);

            if (golferDomainObject != null)
            {
                var golferDTO = new Models.DTO.GolferDTO.Golfer
                {
                    Id = golferDomainObject.Id,
                    Name = golferDomainObject.Name,
                    HandicapIndex = golferDomainObject.HandicapIndex,
                    HomeCourse = golferDomainObject.HomeCourse,
                    Scores = golferDomainObject.Scores,
                };

                return Ok(golferDTO);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateGolfer(Guid id, UpdateGolferRequest updateGolferRequest)
        {
            var exisitngGolfer = _dbContext.Golfers.Find(id);

            if (exisitngGolfer != null)
            {
                exisitngGolfer.Name = updateGolferRequest.Name;
                exisitngGolfer.HandicapIndex = updateGolferRequest.HandicapIndex;
                exisitngGolfer.HomeCourse = updateGolferRequest.HomeCourse;
                exisitngGolfer.Scores = updateGolferRequest.Scores;

                _dbContext.SaveChanges();
                return Ok(exisitngGolfer);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteGolfer(Guid id)
        {
            var existingGolfer = _dbContext.Golfers.Find(id);

            if (existingGolfer != null)
            {
                _dbContext.Golfers.Remove(existingGolfer);
                _dbContext.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }
    }
}
