namespace SuperMarkerAPI.Models.DTOs.ProductsDTO
{
    public class PutProductsDTO
    {
        public Guid IDProducts { get; set; }
        public string NameProduct { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }
        public string ProductUnit { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
        public DateTime ManufactureDate { get; set; }
        public bool IsExpired { get; set; }
    }
}
