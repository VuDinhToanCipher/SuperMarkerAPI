namespace SuperMarkerAPI.Models.DTOs.ProductsDTO
{
    public class ProductsSearchDTO
    {
        public string NameProduct { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }
        public string ProductUnit { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
    }
}
