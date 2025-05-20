using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Entities;

namespace SuperMarket.Infrastructure.Data.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<PermissionEntity>
    {
        public void Configure(EntityTypeBuilder<PermissionEntity> builder)
        {
            builder.HasKey(p => p.PermissionID);
            builder.Property(p => p.PermissionName)
                .IsRequired();
            builder.HasMany(p => p.Position)
                .WithOne(pr => pr.PermissionEntity)
                .HasForeignKey(p => p.PermissionID);
        }
    }
}
