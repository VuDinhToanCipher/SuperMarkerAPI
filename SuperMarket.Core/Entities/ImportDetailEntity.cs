using SuperMarkerAPI.Models;

namespace SuperMarket.Core.Entities
{
    public class ImportDetailEntity
    {
        public Guid ImportDetailID { get; set; }
        public Guid ImportReceiptID { get; set; }
        public ImportReceiptEntity? ImportReceipt { get; set; }
        public Guid IDProduct { get; set; }
        public ProductEntity? Products { get; set; }
        public required int Quantity { get; set; }
        public required float UnitPrice { get; set; }
        public float TotalPrice => UnitPrice*Quantity;

    }
}
