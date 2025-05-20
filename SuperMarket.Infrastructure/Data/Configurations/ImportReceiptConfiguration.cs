using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Entities;

namespace SuperMarket.Infrastructure.Data.Configurations
{
    public class ImportReceiptConfiguration : IEntityTypeConfiguration<ImportReceiptEntity>
    {
        public void Configure(EntityTypeBuilder<ImportReceiptEntity> builder)
        {
            builder.HasKey(i => i.ImportReceiptID);
            builder.HasOne(s => s.Supplier)
                .WithMany()
                .HasForeignKey(s => s.SupplierID)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e =>e.Employee)
                .WithMany()
                .HasForeignKey(e => e.EmployeeID)   
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(id => id.ImportDetail)
                .WithOne(d => d.ImportReceipt)
                .HasForeignKey(d => d.ImportReceiptID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
