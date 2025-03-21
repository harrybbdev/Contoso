using Microsoft.Azure.Cosmos;

namespace CosmosDB.Features.Invoices.CreateInvoice
{
    internal class CreateInvoiceDataAccess
    {
        private readonly CosmosClient _client;

        public CreateInvoiceDataAccess(CosmosClient cosmosClient)
        {
            _client = cosmosClient;
        }

        public async Task CreateInvoiceAsync(Invoice invoice, CancellationToken cancellationToken)
        {
            Container container = _client.GetDatabase("cosmos").GetContainer("invoices");
            await container.CreateItemAsync(invoice, cancellationToken: cancellationToken);
        }

    }
}
