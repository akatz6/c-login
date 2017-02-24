using Microsoft.EntityFrameworkCore;

namespace craigslist.Models
{
    public class CraigsListDBContext : DbContext
    {
            //other code
        public CraigsListDBContext(DbContextOptions<CraigsListDBContext> options) : base(options)
        { }
        public DbSet<User> User { get; set; }
  
    }
}