using GolfLeaderboard.API.Data;
using GolfLeaderboard.API.Models.DTO.ScoreDTO;
using Microsoft.AspNetCore.Mvc;

namespace GolfLeaderboard.API.Business
{
    public class ScoreService
    {
        private readonly GolfLeaderboardDbContext _dbContext;

        public ScoreService(GolfLeaderboardDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Models.DomainModels.Score AddScore(AddScoreRequest addScoreRequest)
        {
            // Convert DTO to Domain Model
            var score = new Models.DomainModels.Score
            {
                Total = addScoreRequest.Total,
            };

            _dbContext.Scores.Add(score);
            _dbContext.SaveChanges();

            return score;
        }

        public List<Models.DTO.ScoreDTO.Score> GetAllScores()
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

            return scoresDTO;
        }

        public List<Models.DTO.ScoreDTO.Score> GetAllScoresByGolfer(Guid golferId)
        {

            var scores = _dbContext.Scores.ToList();

            var scoresDTO = new List<Models.DTO.ScoreDTO.Score>();
            foreach (var score in scores)
            {
                if (score.Id == golferId)
                {
                    scoresDTO.Add(new Models.DTO.ScoreDTO.Score
                    {
                        Id = score.Id,
                        Total = score.Total,
                    });
                }
            }

            return scoresDTO;
        }

        public Models.DomainModels.Score UpdateScore(Guid id, UpdateScoreRequest updateScoreRequest)
        {
            var existingScore = _dbContext.Scores.Find(id);

            if (existingScore != null)
            {
                existingScore.Total = updateScoreRequest.Total;

                _dbContext.SaveChanges();
                return existingScore;
            }

            return null;
        }

        public bool DeleteScore(Guid id)
        {
            var existingScore = _dbContext.Scores.Find(id);

            if (existingScore != null)
            {
                _dbContext.Scores.Remove(existingScore);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
