namespace SuperMarkerAPI.Models.DTOs.ProductsDTO
{
    public class GetProductsDTO
    {
        public string? NameProduct { get; set; } 
        public string? ProductType { get; set; } 
        public decimal ProductPrice { get; set; }
        public string? ProductUnit { get; set; } 
        public DateTime ExpirationDate { get; set; }
        public DateTime ManufactureDate { get; set; }
        public bool IsExpired { get; set; }
    }
}
