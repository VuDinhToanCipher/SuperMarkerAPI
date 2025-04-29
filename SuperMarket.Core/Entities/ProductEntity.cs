namespace SuperMarkerAPI.Models
{
    public class ProductEntity
    {
        public Guid IDProduct { get; set; } 
        public string NameProduct { get; set; } = string.Empty;
        public Guid ProductTypeID { get; set; } 
        public decimal ProductPrice { get; set; }
        public string ProductUnit { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
        public DateTime ManufactureDate { get; set; }
        public bool IsExpired { get; set; }
        //Navigation with ProductType
        public ProductTypeEntity? productType { get; set; }
    }
}
