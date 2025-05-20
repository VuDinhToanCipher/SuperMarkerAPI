using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Entities;

namespace SuperMarket.Infrastructure.Data.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<PositionEntity>
    {
        public void Configure(EntityTypeBuilder<PositionEntity> builder)
        {
            builder.HasKey(p => p.PositionID);
            builder.Property(p => p.PositionName)
                .IsRequired();
            builder.HasMany(pr => pr.Permission)
                .WithOne(p => p.PositionEntity)
                .HasForeignKey(p => p.PositionID);
        }
    }
}
