using System.Net;
using CosmosDb.Common.CosmosDb;
using Microsoft.Azure.Cosmos;

namespace CosmosDB.Features.Invoices.GetInvoiceById
{
    public class GetInvoiceByIdDataAccess
    {
        private readonly CosmosDbClient _client;

        public GetInvoiceByIdDataAccess(CosmosDbClient cosmosClient)
        {
            _client = cosmosClient;
        }

        public async Task<Invoice?> GetInvoiceByIdAsync(Guid id)
        {
            var container = await _client.GetOrCreateContainer("cosmos", new ContainerProperties()
            {
                Id = "invoices",
                PartitionKeyPath = "/id"
            });

            try
            {
                return await container.ReadItemAsync<Invoice>(id.ToString(), new PartitionKey(id.ToString()));
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }
    }
}
