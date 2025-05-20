using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Entities;

namespace SuperMarket.Infrastructure.Data.Configurations
{
    public class ImportDetailConfiguration : IEntityTypeConfiguration<ImportDetailEntity>
    {
        public void Configure(EntityTypeBuilder<ImportDetailEntity> builder)
        {
            builder.HasKey(ip => ip.ImportDetailID);
            builder.HasOne(p => p.Products)
                .WithMany()
                .HasForeignKey(p => p.IDProduct)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(r => r.ImportReceipt)
                .WithMany(d => d.ImportDetail)
                .HasForeignKey(r => r.ImportReceiptID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
