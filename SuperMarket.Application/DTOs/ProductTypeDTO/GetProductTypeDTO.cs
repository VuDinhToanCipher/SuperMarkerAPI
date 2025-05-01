namespace SuperMarket.Application.DTOs.ProductTypeDTO
{
    public class GetProductTypeDTO
    {
        public Guid IDType { get; set; }
        public string TypeName { get; set; } = string.Empty;
    }
}
