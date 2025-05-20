namespace SuperMarket.Core.Entities
{
    public class WarehouseEntity
    {
        public Guid WarehouseID { get; set; }
        public required string WarehouseName { get; set; }
        public required string WarehouseLocation { get; set; }
        public required string WarehousePhoneNumber { get; set; }
        public ICollection<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();
        public ICollection<WarehouseInventoryEntity>? Inventory { get; set; }
        public string? Description { get; set; }
    }
}
