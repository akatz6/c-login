using Microsoft.EntityFrameworkCore;

namespace idea.Models
{
    public class IdeasDBContext : DbContext
    {
            //other code
        public IdeasDBContext(DbContextOptions<IdeasDBContext> options) : base(options)
        { }
        public DbSet<User> User { get; set; }
  
    }
}