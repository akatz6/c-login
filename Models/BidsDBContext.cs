using Microsoft.EntityFrameworkCore;

namespace login.Models
{
    public class BidsDBContext : DbContext
    {
            //other code
        public BidsDBContext(DbContextOptions<BidsDBContext> options) : base(options)
        { }
        public DbSet<User> User { get; set; }
  
    }
}