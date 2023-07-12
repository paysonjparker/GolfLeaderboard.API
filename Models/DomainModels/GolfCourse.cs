namespace GolfLeaderboard.API.Models.DomainModels
{
    public class GolfCourse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int SlopeRating { get; set; }
        public float CourseRating { get; set; }
        public int Yardage { get; set; }
        public int Par { get; set; }
    }
}
