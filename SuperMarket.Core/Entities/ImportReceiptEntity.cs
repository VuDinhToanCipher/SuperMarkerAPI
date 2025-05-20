namespace SuperMarket.Core.Entities
{
    public class ImportReceiptEntity
    {
        public Guid ImportReceiptID { get; set; }
        public Guid SupplierID { get; set; }
        public Guid EmployeeID { get; set; }
        public DateTime ImportDate { get; set; }
        public SupplierEntity? Supplier { get; set; }
        public EmployeeEntity? Employee { get; set; }
        public ICollection<ImportDetailEntity>? ImportDetail { get; set; }
    }
}
