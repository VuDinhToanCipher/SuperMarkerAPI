using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Entities;

namespace SuperMarket.Infrastructure.Data.Configurations
{
    public class CustomerPermissionConfiguration : IEntityTypeConfiguration<CustomerPermissionEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerPermissionEntity> builder)
        {
            builder.HasKey(p => p.PermissionID);
            builder.Property(p => p.NamePermission)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
