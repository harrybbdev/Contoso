using Microsoft.Azure.Cosmos;

namespace CosmosDb.Common.CosmosDb
{
    public class CosmosDbClient
    {
        private readonly CosmosClient _client;

        public CosmosDbClient(CosmosClient cosmosClient)
        {
            _client = cosmosClient;
        }

        public async Task<Container> GetOrCreateContainer(string databaseId, ContainerProperties containerProperties, CancellationToken cancellationToken = default)
        {
            var database = await _client.CreateDatabaseIfNotExistsAsync("cosmos", cancellationToken: cancellationToken);
            var container = await database.Database.CreateContainerIfNotExistsAsync(containerProperties, cancellationToken: cancellationToken);
            return container.Container;
        }
    }
}
