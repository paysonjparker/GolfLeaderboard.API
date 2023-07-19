using GolfLeaderboard.API.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace GolfLeaderboard.API.Data
{
    public class GolfLeaderboardDbContext : DbContext
    {
        public GolfLeaderboardDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Golfer> Golfers { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<GolfCourse> GolfCourses { get; set; }
        public DbSet<Leaderboard> Leaderboards { get; set; }

    }
}
