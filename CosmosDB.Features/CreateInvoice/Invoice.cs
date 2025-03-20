namespace CosmosDB.Features.Invoices.CreateInvoice
{
    public class Invoice
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required decimal Amount { get; set; }
        public required string Status { get; set; }
    }
}
