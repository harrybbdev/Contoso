using CosmosDb.Common.CosmosDb;
using Microsoft.Azure.Cosmos;

namespace CosmosDB.Features.Invoices.CreateInvoice
{
    internal class CreateInvoiceDataAccess
    {
        private readonly CosmosDbClient _client;

        public CreateInvoiceDataAccess(CosmosDbClient cosmosClient)
        {
            _client = cosmosClient;
        }

        public async Task CreateInvoiceAsync(Invoice invoice, CancellationToken cancellationToken)
        {
            var container = await _client.GetOrCreateContainer("cosmos", new ContainerProperties()
            {
                Id = "invoices",
                PartitionKeyPath = "/id"
            });

            await container.CreateItemAsync(invoice, cancellationToken: cancellationToken);
        }

    }
}
