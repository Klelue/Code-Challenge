using Code_Challenge.Models;
using Microsoft.EntityFrameworkCore;


namespace Code_Challenge.Util
{
    public class CodeChallengeDbContext : DbContext
    {
        public CodeChallengeDbContext(DbContextOptions<CodeChallengeDbContext> options) : base(options) { }

        public DbSet<Room> Room { get; set; }

        public DbSet<People> People { get; set; }
    }
}
