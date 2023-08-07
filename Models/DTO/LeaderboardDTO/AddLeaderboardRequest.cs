using GolfLeaderboard.API.Models.DomainModels;

namespace GolfLeaderboard.API.Models.DTO.LeaderboardDTO
{
    public class AddLeaderboardRequest
    {
        public ICollection<Golfer> Golfers { get; set; }
        public GolfCourse GolfCourse { get; set; }
    }
}
