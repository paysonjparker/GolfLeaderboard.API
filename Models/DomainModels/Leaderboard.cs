namespace GolfLeaderboard.API.Models.DomainModels
{
    /// <summary>
    /// Leaderboard domain model
    /// </summary>
    public class Leaderboard
    {
        public Guid Id { get; set; }
        public ICollection<Golfer> Golfers { get; set; }
        public GolfCourse GolfCourse { get; set; }
    }
}
