using Microsoft.EntityFrameworkCore;

namespace TouristSpot.Infrastructure
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Domain.Entities.TouristSpot> TouristSpots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(APIDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
