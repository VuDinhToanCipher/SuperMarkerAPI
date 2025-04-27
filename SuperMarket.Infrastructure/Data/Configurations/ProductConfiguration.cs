using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarkerAPI.Models;

namespace SuperMarkerAPI.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.IDProduct);
            builder.Property(p => p.NameProduct)
                .IsRequired()
                .HasMaxLength(130);
            builder.Property(p => p.ProductPrice)
                .IsRequired()
                .HasColumnType("Decimal(18, 2)");
            builder.Property(p => p.ProductUnit)
           .IsRequired()
           .HasMaxLength(50);

            builder.Property(p => p.ExpirationDate)
                .IsRequired();

            builder.Property(p => p.ManufactureDate)
                .IsRequired();

            builder.Property(p => p.IsExpired)
                .IsRequired();
            builder.HasOne(p=>p.productType)
                .WithMany(pt => pt.Products)
                .HasForeignKey(p => p.ProductTypeID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

