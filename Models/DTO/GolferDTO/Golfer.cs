using GolfLeaderboard.API.Models.DomainModels;

namespace GolfLeaderboard.API.Models.DTO.GolferDTO
{
    public class Golfer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float HandicapIndex { get; set; }
        public string HomeCourse { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
