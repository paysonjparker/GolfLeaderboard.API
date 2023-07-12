namespace GolfLeaderboard.API.Models.DTO.ScoreDTO
{
    public class UpdateScoreRequest
    {
        public int Total { get; set; }
        public Guid GolferId { get; set; }
    }
}
