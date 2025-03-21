namespace CosmosDB.Features.Invoices.GetInvoiceById
{
    public class Invoice
    {
        public required Guid Id { get; set; }
        public required decimal Amount { get; set; }
        public required string Status { get; set; }
    }
}
