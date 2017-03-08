using Microsoft.EntityFrameworkCore;

namespace craigslist.Models
{
    public class CraigsListDBContext : DbContext
    {
        public CraigsListDBContext(DbContextOptions<CraigsListDBContext> options) : base(options)
        { }
        public DbSet<User> User { get; set; }

        public DbSet<Auto> Auto { get; set; }

        public DbSet<AutoTalk> AutoTalk { get; set; }

        public DbSet<Job> Job { get; set; }

        public DbSet<JobTalk> JobTalk { get; set; }
  
    }
}