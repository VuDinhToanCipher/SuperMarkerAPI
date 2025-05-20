using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Entities;

namespace SuperMarket.Infrastructure.Data.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<InvoiceEntity>
    {
        public void Configure(EntityTypeBuilder<InvoiceEntity> builder)
        {
            builder.HasKey(invoice => invoice.InvoiceID);
            builder.HasOne(invoice => invoice.Customer)
                .WithMany(customer => customer.Invoices)
                .HasForeignKey(invoice => invoice.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(invoice => invoice.Employee)
                .WithMany(employee => employee.Invoices)
                .HasForeignKey(invoice => invoice.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(invoice => invoice.CreatedDate)
                .IsRequired(); 
        }
    }
}
