using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models
{
    public class WeddingContext : DbContext
    {
        public WeddingContext(DbContextOptions options) : base(options) {}

        DbSet<User> Users { get; set; }
        DbSet<Wedding> Weddings { get; set; }
        DbSet<Association> Associations { get; set; }
    }
}