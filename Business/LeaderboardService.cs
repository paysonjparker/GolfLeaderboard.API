using GolfLeaderboard.API.Data;
using GolfLeaderboard.API.Models.DomainModels;
using GolfLeaderboard.API.Models.DTO.GolferDTO;
using GolfLeaderboard.API.Models.DTO.LeaderboardDTO;

namespace GolfLeaderboard.API.Business
{
    public class LeaderboardService
    {
        private readonly GolfLeaderboardDbContext _dbContext;

        public LeaderboardService(GolfLeaderboardDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

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
