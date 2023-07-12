namespace GolfLeaderboard.API.Models.DTO.ScoreDTO
{
    public class AddScoreRequest
    {
        public int Total { get; set; }
        public Guid GolferId { get; set; }
    }
}
