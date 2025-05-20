using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Entities;

namespace SuperMarket.Infrastructure.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.HasKey(c => c.CustomerID);
            builder.Property(c => c.CustomerName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.CustomerPhoneNumber)
                .IsRequired();
            builder.HasOne(c => c.CustomerPermission)
                .WithMany(p => p.Customer)
                .HasForeignKey(c => c.PermissionID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
