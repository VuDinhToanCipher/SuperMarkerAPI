using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarkerAPI.Models;

namespace SuperMarkerAPI.Data.Configurations
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductTypeEntity>
    {
        public void Configure(EntityTypeBuilder<ProductTypeEntity> builder)
        {
            builder.HasKey(pt => pt.IDType);
            builder.Property(pt => pt.TypeName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
