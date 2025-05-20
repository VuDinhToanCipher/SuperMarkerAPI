using SuperMarkerAPI.Models;

namespace SuperMarket.Core.Entities
{
    public class WarehouseInventoryEntity
    {
        public Guid WarehouseID { get; set; }
        public WarehouseEntity? Warehouses { get; set; }
        public Guid ProductID { get; set; }
        public ProductEntity? Products { get; set; }
        public required int Quantity { get; set; }
    }
}
