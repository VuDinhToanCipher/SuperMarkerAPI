using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Entities;

namespace SuperMarket.Infrastructure.Data.Configurations
{
    public class Position_Permission_Configuration : IEntityTypeConfiguration<Position_Permission_Entity>
    {
        public void Configure(EntityTypeBuilder<Position_Permission_Entity> builder)
        {
            builder.HasKey(pp => new {pp.PermissionID, pp.PositionID});
            builder.HasOne(pp => pp.PositionEntity)
                .WithMany(pr => pr.Permission)
                .HasForeignKey(pp => pp.PositionID)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(pr => pr.PermissionEntity)
                .WithMany(pp => pp.Position)
                .HasForeignKey(pr => pr.PermissionID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
