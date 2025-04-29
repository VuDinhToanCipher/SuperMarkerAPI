using System.ComponentModel.DataAnnotations;

namespace SuperMarkerAPI.Models
{
    public class ProductTypeEntity
    {
        public Guid IDType { get; set; }
        [Required]
        public string TypeName { get; set; } = string.Empty;
        //Navigation with product
        public ICollection<ProductEntity>? Products { get; set; }
    }
}
