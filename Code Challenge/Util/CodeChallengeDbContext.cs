using Code_Challenge.Models;
using Microsoft.EntityFrameworkCore;


namespace Code_Challenge.Util
{
    public class CodeChallengeDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>().HasRequired(e => e.Room)
        .WithMany(e => e.People);
        }
        public CodeChallengeDbContext(DbContextOptions<CodeChallengeDbContext> options) : base(options) { }

        public DbSet<Room> Room { get; set; }

        public DbSet<People> People { get; set; }
    }
}
