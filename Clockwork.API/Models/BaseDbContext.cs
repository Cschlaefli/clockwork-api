using Microsoft.EntityFrameworkCore;
using Clockwork.Models;
using System.Collections.Generic;

namespace tephraAPI.Models
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Augment> Augments {get;set;}
        public DbSet<Character> Characters {get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Character>().Navigation(e => e.Specialties).Metadata.SetIsEagerLoaded(true);
            modelBuilder.Entity<CharacterSpecialty>().HasOne(e => e.Specialty);
            modelBuilder.Entity<CharacterSpecialty>().Navigation(e => e.Specialty).Metadata.SetIsEagerLoaded(true);
        }
    }
    
}