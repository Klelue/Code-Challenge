using Code_Challenge.Models;
using Microsoft.EntityFrameworkCore;


namespace Code_Challenge.Util
{
    public class CodeChallengeDbContext : DbContext
    {
        private bool isExecuted = false;

        public CodeChallengeDbContext(DbContextOptions<CodeChallengeDbContext> options) : base(options)
        {
            if (isExecuted == false)
            {
                Database.ExecuteSqlRaw("DELETE FROM People");
                Database.ExecuteSqlRaw("DELETE FROM Room");
                SaveChanges();
                isExecuted = true;
            }
            
        }

        public DbSet<Room> Room { get; set; }

        public DbSet<People> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MyDatabase.db");
        }
    }
}
