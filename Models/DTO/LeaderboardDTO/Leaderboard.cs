using GolfLeaderboard.API.Models.DomainModels;

namespace GolfLeaderboard.API.Models.DTO.LeaderboardDTO
{
    public class Leaderboard
    {
        public Guid Id { get; set; }
        public ICollection<Golfer> Golfers { get; set; }
        public GolfCourse GolfCourse { get; set; }
    }
}
