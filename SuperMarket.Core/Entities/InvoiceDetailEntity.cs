using SuperMarkerAPI.Models;

namespace SuperMarket.Core.Entities
{
    public class InvoiceDetailEntity
    {
        public Guid InvoiceDetailID { get; set; }
        public Guid InvoiceID { get; set; }
        public InvoiceEntity? Invoice { get; set; }
        public Guid ProductID { get; set; }
        public ProductEntity? Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Description { get; set; }
    }
}
