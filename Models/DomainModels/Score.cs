namespace GolfLeaderboard.API.Models.DomainModels
{
    /// <summary>
    /// Score domain model
    /// </summary>
    public class Score
    {
        public Guid Id { get; set; }
        public int Total { get; set; }
        public Guid GolferId { get; set; }
    }
}
