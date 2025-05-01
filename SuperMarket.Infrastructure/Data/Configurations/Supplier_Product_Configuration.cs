using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Entities;

namespace SuperMarket.Infrastructure.Data.Configurations
{
    public class Supplier_Product_Configuration : IEntityTypeConfiguration<Supplier_Product_Entity>
    {
        public void Configure(EntityTypeBuilder<Supplier_Product_Entity> builder)
        {
            builder.HasKey(sp => new {sp.SupplierId,sp.ProductId});
            builder.HasOne(sp => sp.ProductEntity)
                .WithMany(s => s.Suppliers)
                .HasForeignKey(sp => sp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(sp => sp.SupplierEntity)
                .WithMany(p => p.Products)
                .HasForeignKey(sp => sp.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
