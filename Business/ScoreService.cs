using GolfLeaderboard.API.Data;
using GolfLeaderboard.API.Models.DTO.ScoreDTO;
using Microsoft.AspNetCore.Mvc;

namespace GolfLeaderboard.API.Business
{
    public class ScoreService
    {
        private readonly GolfLeaderboardDbContext _dbContext;

        /// <summary>
        /// Constructor for the score service
        /// </summary>
        /// <param name="dbContext">DB Context</param>
        public ScoreService(GolfLeaderboardDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Adds a score to the database
        /// </summary>
        /// <param name="addScoreRequest">add Score request</param>
        /// <returns>The newly created score</returns>
        public Models.DomainModels.Score AddScore(AddScoreRequest addScoreRequest)
        {
            // Convert DTO to Domain Model
            var score = new Models.DomainModels.Score
            {
                Total = addScoreRequest.Total,
                GolferId = addScoreRequest.GolferId,
            };

            _dbContext.Scores.Add(score);
            _dbContext.SaveChanges();

            return score;
        }

        /// <summary>
        /// Gets all scores from the database
        /// </summary>
        /// <returns>A list of score objects</returns>
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
                    GolferId = score.GolferId,
                });
            }

            return scoresDTO;
        }

        /// <summary>
        /// Gets all scores for a specific golfer
        /// </summary>
        /// <param name="golferId">ID number fo the golfer the scores belong to</param>
        /// <returns>A list of scores associated with that golfer</returns>
        public List<Models.DomainModels.Score> GetAllScoresByGolfer(Guid golferId)
        {

            var scores = _dbContext.Scores.ToList();

            var scoresDTO = new List<Models.DomainModels.Score>();
            foreach (var score in scores)
            {
                if (score.GolferId == golferId)
                {
                    scoresDTO.Add(new Models.DomainModels.Score
                    {
                        Id = score.Id,
                        Total = score.Total,
                        GolferId = score.GolferId,
                    });
                }
            }

            return scoresDTO;
        }

        /// <summary>
        /// Updates an existing score in the database
        /// </summary>
        /// <param name="id">ID number of the updated score</param>
        /// <param name="updateScoreRequest">Update score request</param>
        /// <returns>The updated score object</returns>
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

        /// <summary>
        /// Deletes an exisitng score from the database
        /// </summary>
        /// <param name="id">ID number of the deleted score</param>
        /// <returns>True if deletion was successful, otherwise false</returns>
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
