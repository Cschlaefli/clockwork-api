using Microsoft.EntityFrameworkCore;
using Clockwork.Models;

namespace Clockwork.API.Data
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Augment> Augments {get;set;}


    }
}