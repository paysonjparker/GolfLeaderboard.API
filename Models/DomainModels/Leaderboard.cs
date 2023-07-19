namespace GolfLeaderboard.API.Models.DomainModels
{
    public class Leaderboard
    {
        public Guid Id { get; set; }
        public ICollection<Golfer> Golfers { get; set; }
        public GolfCourse GolfCourse { get; set; }
    }
}
