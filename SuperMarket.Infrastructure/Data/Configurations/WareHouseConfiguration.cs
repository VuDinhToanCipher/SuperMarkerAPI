using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Entities;

namespace SuperMarket.Infrastructure.Data.Configurations
{
    public class WareHouseConfiguration : IEntityTypeConfiguration<WarehouseEntity>
    {
        public void Configure(EntityTypeBuilder<WarehouseEntity> builder)
        {
            builder.HasKey(warehouse => warehouse.WarehouseID);
            builder.Property(warehouse => warehouse.WarehouseName)
                .IsRequired()
                .HasMaxLength(40);
        }
    }
}
