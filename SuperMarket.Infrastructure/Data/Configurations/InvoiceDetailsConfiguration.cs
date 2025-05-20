using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Entities;

namespace SuperMarket.Infrastructure.Data.Configurations
{
    public class InvoiceDetailsConfiguration : IEntityTypeConfiguration<InvoiceDetailEntity>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetailEntity> builder)
        {
            builder.HasKey(ivdetail => ivdetail.InvoiceDetailID);
            builder.HasOne(ivdetail => ivdetail.Invoice)
                .WithMany(invoice => invoice.InvoiceDetail)
                .HasForeignKey(ivdetail => ivdetail.InvoiceID)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(ivdetail => ivdetail.Product)
                .WithMany(product => product.invoiceDetails)
                .HasForeignKey(ivdetail =>ivdetail.ProductID)   
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(ivdetail => ivdetail.Quantity)
                .IsRequired();
            builder.Property(ivdetail => ivdetail.UnitPrice)
                .IsRequired();
        }
    }
}
