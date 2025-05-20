using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Entities;

namespace SuperMarket.Infrastructure.Data.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<SupplierEntity>
    {
        public void Configure(EntityTypeBuilder<SupplierEntity> builder)
        {
            builder.HasKey(p => p.SupplierId);
            builder.HasMany(p => p.Products)
                .WithOne(sp => sp.SupplierEntity)
                .HasForeignKey(sp => sp.SupplierId);
        }
    }
}
