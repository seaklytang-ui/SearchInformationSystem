using Microsoft.EntityFrameworkCore;
using Search.Api.Models;

namespace Search.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<LandInformation> LandInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LandInformation>()
                .ToTable("land_information");
        }
    }
}