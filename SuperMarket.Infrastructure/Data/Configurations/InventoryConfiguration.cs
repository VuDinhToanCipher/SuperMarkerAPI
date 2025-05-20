using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Entities;

namespace SuperMarket.Infrastructure.Data.Configurations
{
    public class InventoryConfiguration : IEntityTypeConfiguration<WarehouseInventoryEntity>
    {
        public void Configure(EntityTypeBuilder<WarehouseInventoryEntity> builder)
        {
            builder.HasKey(inventory => new { inventory.ProductID, inventory.WarehouseID });
            builder.HasOne(inventory => inventory.Products)
                .WithMany(product => product.Inventory)
                .HasForeignKey(inventory => inventory.ProductID)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(inventory => inventory.Warehouses)
                .WithMany(warehouse => warehouse.Inventory)
                .HasForeignKey(inventory => inventory.WarehouseID) 
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
