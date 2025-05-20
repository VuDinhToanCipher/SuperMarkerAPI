namespace SuperMarket.Application.DTOs.Product_Supplier_DTO
{
    public class Get_Supplier_Product_DTO
    {
        public Guid SupplierId { get; set; }
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? SupplierName { get; set; }
    }

}
