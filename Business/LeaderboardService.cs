using GolfLeaderboard.API.Data;
using GolfLeaderboard.API.Models.DomainModels;
using GolfLeaderboard.API.Models.DTO.GolferDTO;
using GolfLeaderboard.API.Models.DTO.LeaderboardDTO;

namespace GolfLeaderboard.API.Business
{
    public class LeaderboardService
    {
        private readonly GolfLeaderboardDbContext _dbContext;

        /// <summary>
        /// Constructor for Leaderboard service
        /// </summary>
        /// <param name="dbContext">DB Context</param>
        public LeaderboardService(GolfLeaderboardDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Creates a new Leaderboard and adds it to the database
        /// </summary>
        /// <param name="addLeaderboardRequest">Create leaderboard request</param>
        /// <returns>The created leaderboard object</returns>
        public Models.DomainModels.Leaderboard AddLeaderboard(AddLeaderboardRequest addLeaderboardRequest)
        {
            // Convert DTO to Domain Model
            var leaderboard = new Models.DomainModels.Leaderboard
            {
                Golfers = addLeaderboardRequest.Golfers,
                GolfCourse = addLeaderboardRequest.GolfCourse,
            };

            _dbContext.Leaderboards.Add(leaderboard);
            _dbContext.SaveChanges();

            return leaderboard;
        }

        /// <summary>
        /// Gets all leaderboards from the database
        /// </summary>
        /// <returns>A list of leaderboard objects</returns>
        public List<Models.DTO.LeaderboardDTO.Leaderboard> GetAllLeaderboards()
        {

            var leaderboards = _dbContext.Leaderboards.ToList();

            var leaderboardDTO = new List<Models.DTO.LeaderboardDTO.Leaderboard>();
            foreach (var leaderboard in leaderboards)
            {
                leaderboardDTO.Add(new Models.DTO.LeaderboardDTO.Leaderboard
                {
                    Id = leaderboard.Id,
                    Golfers = leaderboard.Golfers,
                    GolfCourse = leaderboard.GolfCourse,
                });
            }

            return leaderboardDTO;
        }

        /// <summary>
        /// Gets a specific leaderboard by ID number from the database
        /// </summary>
        /// <param name="id">ID number of the leaderboard</param>
        /// <returns>The leaderboard obejct associated with that ID number</returns>
        public Models.DTO.LeaderboardDTO.Leaderboard GetLeaderboardById(Guid id)
        {
            var leaderboardDomain = _dbContext.Leaderboards.Find(id);

            if (leaderboardDomain != null)
            {
                var leaderboardDTO = new Models.DTO.LeaderboardDTO.Leaderboard
                {
                    Id = leaderboardDomain.Id,
                    Golfers = leaderboardDomain.Golfers,
                    GolfCourse = leaderboardDomain.GolfCourse,
                };

                return leaderboardDTO;
            }

            return null;
        }

        /// <summary>
        /// Updates an exisitng leaderboard in the database
        /// </summary>
        /// <param name="id">ID of the updated leaderboard</param>
        /// <param name="updateLeaderboardRequest">Update leaderboard request</param>
        /// <returns>The updated leaderboard object</returns>
        public Models.DomainModels.Leaderboard UpdateLeaderboard(Guid id, UpdateLeaderboardRequest updateLeaderboardRequest)
        {
            var exisitngLeaderboard = _dbContext.Leaderboards.Find(id);

            if (exisitngLeaderboard != null)
            {
                exisitngLeaderboard.Golfers = updateLeaderboardRequest.Golfers;
                exisitngLeaderboard.GolfCourse = updateLeaderboardRequest.GolfCourse;

                _dbContext.SaveChanges();
                return exisitngLeaderboard;
            }

            return null;
        }

        /// <summary>
        /// Deletes a leaderboard from the database
        /// </summary>
        /// <param name="id">Id of the deleted leaderboard</param>
        /// <returns>True if the deletion is successfull, otherwise false</returns>
        public bool DeleteLeaderboard(Guid id)
        {
            var existingLeaderboard = _dbContext.Leaderboards.Find(id);

            if (existingLeaderboard != null)
            {
                _dbContext.Leaderboards.Remove(existingLeaderboard);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds a golfer to the leaderboard
        /// </summary>
        /// <param name="leaderboardId">ID number of the leaderboard</param>
        /// <param name="golferId">ID of the golfer being added to the leaderboard</param>
        /// <returns>The golfer that was added to the leaderboard</returns>
        public Models.DomainModels.Golfer AddGolferToLeaderboard(Guid leaderboardId, Guid golferId)
        {
            var scoreService = new ScoreService(_dbContext);

            var golferDomainObject = _dbContext.Golfers.Find(golferId);

            var existingLeaderboard = _dbContext.Leaderboards.Find(leaderboardId);


            if (golferDomainObject != null && existingLeaderboard != null)
            {
                var golfer = new Models.DomainModels.Golfer
                {
                    Id = golferDomainObject.Id,
                    Name = golferDomainObject.Name,
                    HandicapIndex = golferDomainObject.HandicapIndex,
                    HomeCourse = golferDomainObject.HomeCourse,
                    Scores = scoreService.GetAllScoresByGolfer(golferDomainObject.Id),
                };

                existingLeaderboard.Golfers.Add(golfer);

                return golfer;
            }

            return null;
        }
    }
}
