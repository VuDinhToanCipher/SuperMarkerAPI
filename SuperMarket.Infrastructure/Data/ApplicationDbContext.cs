using Microsoft.EntityFrameworkCore;
using SuperMarkerAPI.Data.Configurations;
using SuperMarkerAPI.Models;
using SuperMarket.Core.Entities;
using SuperMarket.Infrastructure.Data.Configurations;

namespace SuperMarkerAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductTypeEntity> ProductTypes { get; set; }
        public DbSet<SupplierEntity> Suppliers { get; set; }
        public DbSet<Supplier_Product_Entity> supplier_Product { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new Supplier_Product_Configuration());
        }
    }
}
