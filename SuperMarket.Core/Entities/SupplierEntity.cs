namespace SuperMarket.Core.Entities
{
    public class SupplierEntity
    {
        public Guid SupplierId { get; set; }
        public required string SupplierName { get; set; }
        public required string SupplierAddress { get; set; }
        public required string SupplierPhoneNummber { get; set; }
        public string? Email { get; set; }
        public string? SupplierDescription { get; set; }
        //Navigation with product_Supplier
        public ICollection<Supplier_Product_Entity>? Products { get; set; }

    }
}
