using System.ComponentModel.DataAnnotations;

namespace SuperMarkerAPI.Models
{
    public class ProductType
    {
        public Guid IDType { get; set; }
        [Required]
        public string TypeName { get; set; } = string.Empty;
        //Navigation with product
        public ICollection<Product>? Products { get; set; }
    }
}
