using Newtonsoft.Json;

namespace CosmosDB.Features.Invoices.CreateInvoice
{
    public class Invoice
    {
        [JsonProperty("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [JsonProperty("amount")]
        public required decimal Amount { get; set; }

        [JsonProperty("status")]
        public required string Status { get; set; }
    }
}
