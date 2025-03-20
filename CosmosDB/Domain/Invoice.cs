namespace CosmosDB.Domain
{
    public class Invoice
    {
        public required string Id { get; set; }
        public required string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public required string Status { get; set; } // e.g., Paid, Pending
    }
}
