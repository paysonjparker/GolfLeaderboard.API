using GolfLeaderboard.API.Models.DomainModels;

namespace GolfLeaderboard.API.Models.DTO.LeaderboardDTO
{
    public class UpdateLeaderboardRequest
    {
        public ICollection<Golfer> Golfers { get; set; }
        public GolfCourse GolfCourse { get; set; }
    }
}
