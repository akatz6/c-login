using Microsoft.EntityFrameworkCore;

namespace login.Models
{
    public class YourContext : DbContext
    {
            //other code
        public YourContext(DbContextOptions<YourContext> options) : base(options)
        { }
        public DbSet<User> User { get; set; }
  
    }
}