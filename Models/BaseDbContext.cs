using Microsoft.EntityFrameworkCore;

namespace tephraAPI.Models
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Specialty> Specialties { get; set; }

    }
}