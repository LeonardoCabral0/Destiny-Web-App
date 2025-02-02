using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TouristSpot.Infrastructure.Configurations
{
    public class TouristSpotConfiguration : IEntityTypeConfiguration<Domain.Entities.TouristSpot>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.TouristSpot> builder)
        {
            ConfigureTouristSpotTable(builder);
        }

        private void ConfigureTouristSpotTable(EntityTypeBuilder<Domain.Entities.TouristSpot> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(120);

            builder.Property(t => t.Description)
                .HasMaxLength(100);

            builder.Property(t => t.Localization)
                .HasMaxLength(256);

            builder.Property(t => t.City)
               .HasMaxLength(100);

            builder.Property(t => t.State)
               .HasMaxLength(2);
        }
    }
}
