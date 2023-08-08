using GolfLeaderboard.API.Data;
using GolfLeaderboard.API.Models.DomainModels;
using GolfLeaderboard.API.Models.DTO.GolferDTO;
using Microsoft.AspNetCore.Mvc;

namespace GolfLeaderboard.API.Business
{
    public class GolferService
    {
        private readonly GolfLeaderboardDbContext _dbContext;

        /// <summary>
        /// Constructor for Golfer Service
        /// </summary>
        /// <param name="dbContext">DB Context</param>
        public GolferService(GolfLeaderboardDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Adds a golfer to the database
        /// </summary>
        /// <param name="addGolferRequest">Add golfer request</param>
        /// <returns></returns>
        public Models.DomainModels.Golfer AddGolfer(AddGolferRequest addGolferRequest)
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

            return golfer;
        }

        /// <summary>
        /// Gets all golfers from the database
        /// </summary>
        /// <returns>A list of golfers</returns>
        public List<Models.DTO.GolferDTO.Golfer> GetAllGolfers()
        {
            var scoreService = new ScoreService(_dbContext);

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
                    Scores = scoreService.GetAllScoresByGolfer(golfer.Id),
                });
            }

            return golfersDTO;
        }

        /// <summary>
        /// Gets a specific golfer by ID number
        /// </summary>
        /// <param name="id">ID of the golfer</param>
        /// <returns>A golfer object</returns>
        public Models.DTO.GolferDTO.Golfer GetGolferById(Guid id)
        {
            var scoreService = new ScoreService(_dbContext);

            var golferDomainObject = _dbContext.Golfers.Find(id);

            if (golferDomainObject != null)
            {
                var golferDTO = new Models.DTO.GolferDTO.Golfer
                {
                    Id = golferDomainObject.Id,
                    Name = golferDomainObject.Name,
                    HandicapIndex = golferDomainObject.HandicapIndex,
                    HomeCourse = golferDomainObject.HomeCourse,
                    Scores = scoreService.GetAllScoresByGolfer(golferDomainObject.Id),
                };

                return golferDTO;
            }

            return null;
        }

        /// <summary>
        /// Updates an existing golfer
        /// </summary>
        /// <param name="id">ID of the golfer</param>
        /// <param name="updateGolferRequest">Update golfer request</param>
        /// <returns>The updated golfer object</returns>
        public Models.DomainModels.Golfer UpdateGolfer(Guid id, UpdateGolferRequest updateGolferRequest)
        {
            var exisitngGolfer = _dbContext.Golfers.Find(id);

            if (exisitngGolfer != null)
            {
                exisitngGolfer.Name = updateGolferRequest.Name;
                exisitngGolfer.HandicapIndex = updateGolferRequest.HandicapIndex;
                exisitngGolfer.HomeCourse = updateGolferRequest.HomeCourse;
                exisitngGolfer.Scores = updateGolferRequest.Scores;

                _dbContext.SaveChanges();
                return exisitngGolfer;
            }

            return null;
        }

        /// <summary>
        /// Deletes a golfer from the database
        /// </summary>
        /// <param name="id">ID of the golfer</param>
        /// <returns>True i deletion was successfull, otherwise false</returns>
        public bool DeleteGolfer(Guid id)
        {
            var existingGolfer = _dbContext.Golfers.Find(id);

            if (existingGolfer != null)
            {
                _dbContext.Golfers.Remove(existingGolfer);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets all golfers by a specific home golf course
        /// </summary>
        /// <param name="homeCourseName">Home Golf course</param>
        /// <returns>A list of golfer objects</returns>
        public List<Models.DTO.GolferDTO.Golfer> GetAllGolfersByHomeCourse(string homeCourseName)
        {
            var scoreService = new ScoreService(_dbContext);

            var golfers = _dbContext.Golfers.ToList();

            var golfersDTO = new List<Models.DTO.GolferDTO.Golfer>();
            foreach (var golfer in golfers)
            {
                if (golfer.HomeCourse == homeCourseName)
                {
                    golfersDTO.Add(new Models.DTO.GolferDTO.Golfer
                    {
                        Id = golfer.Id,
                        Name = golfer.Name,
                        HandicapIndex = golfer.HandicapIndex,
                        HomeCourse = golfer.HomeCourse,
                        Scores = scoreService.GetAllScoresByGolfer(golfer.Id),
                    });
                }
            }

            return golfersDTO;
        }

    }
}
