using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Entities;

namespace SuperMarket.Infrastructure.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.HasKey(e => e.EmployeeID);
            builder.Property(e => e.EmployeeName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.EmployeePhoneNumber)
                .IsRequired()
                .HasMaxLength(12);
            builder.HasOne(p => p.Position)
                .WithMany()
                .HasForeignKey(p => p.PositionID)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(employee => employee.Warehouse)
                .WithMany(warehouse => warehouse.Employees)
                .HasForeignKey(employee => employee.WarehouseID)
                .IsRequired(false);
        }
    }
}
