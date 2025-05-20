namespace SuperMarket.Core.Entities
{
    public class InvoiceEntity
    {
        public Guid InvoiceID { get; set; }
        public Guid CustomerID { get; set; }
        public CustomerEntity? Customer { get; set; }
        public Guid EmployeeID { get; set; }    
        public EmployeeEntity? Employee { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<InvoiceDetailEntity>? InvoiceDetail { get; set; }
    }
}
