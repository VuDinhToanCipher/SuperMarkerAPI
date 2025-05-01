using SuperMarkerAPI.Models;

namespace SuperMarket.Core.Entities
{
    public class Supplier_Product_Entity
    {
        public Guid SupplierId { get; set; }
        public Guid ProductId { get; set; }
        //Navigation
        public ProductEntity? ProductEntity { get; set; }
        public SupplierEntity? SupplierEntity { get; set; }
    }
}
