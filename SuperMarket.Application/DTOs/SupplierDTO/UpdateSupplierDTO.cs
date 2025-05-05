namespace SuperMarket.Application.DTOs.SupplierDTO
{
    public class UpdateSupplierDTO
    {
        public required string SupplierName { get; set; }
        public required string SupplierAddress { get; set; }
        public required string SupplierPhoneNummber { get; set; }
        public string? Email { get; set; }
        public string? SupplierDescription { get; set; }
    }
}
