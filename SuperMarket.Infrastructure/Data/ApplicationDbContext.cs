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
        public DbSet<PositionEntity> Positions { get; set; }
        public DbSet<PermissionEntity> Permission {  get; set; }
        public DbSet<Position_Permission_Entity> PositionPermissions { get; set; }
        public DbSet<EmployeeEntity> Employee { get; set; }
        public DbSet<ImportReceiptEntity> ImportReceipt { get; set; }
        public DbSet<ImportDetailEntity> ImportDetail { get; set; }
        public DbSet<CustomerEntity> Customer { get; set; }
        public DbSet<CustomerPermissionEntity> CustomerPermissions { get; set; }
        public DbSet<InvoiceEntity> Invoice { get; set; }
        public DbSet<InvoiceDetailEntity> InvoiceDetail { get; set; }
        public DbSet<WarehouseEntity> Warehouse { get; set; }
        public DbSet<WarehouseInventoryEntity> Inventory { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new Supplier_Product_Configuration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new Position_Permission_Configuration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ImportReceiptConfiguration());
            modelBuilder.ApplyConfiguration(new ImportDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());   
            modelBuilder.ApplyConfiguration(new CustomerPermissionConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new WareHouseConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryConfiguration());
        }
    }
}
