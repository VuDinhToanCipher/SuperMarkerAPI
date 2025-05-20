namespace SuperMarket.Core.Entities
{
    public class CustomerPermissionEntity
    {
        public Guid PermissionID { get; set; }
        public required string NamePermission { get; set; }
        public float Discount {  get; set; }
        public float HolidayDiscount { get; set; }
        public string? Description { get; set; }
        public ICollection<CustomerEntity>? Customer { get; set; }

    }
}
