namespace SuperMarkerAPI.Models.DTOs.ProductsDTO
{
    public class PutProductsDTO
    {
        public string NameProduct { get; set; } = string.Empty;
        public Guid ProductType { get; set; } 
        public decimal ProductPrice { get; set; }
        public string ProductUnit { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
        public DateTime ManufactureDate { get; set; }
        public bool IsExpired { get; set; }
    }
}
