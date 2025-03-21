using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;

namespace CosmosDB.Features.Invoices.DeleteInvoiceById
{
    public class DeleteInvoiceEndpoint
    {
        public static void MapEndpoint(WebApplication app)
        {
            app.MapDelete("/api/invoices/{id}", async (Guid id, CosmosClient cosmosClient, CancellationToken token) =>
            {
                var container = cosmosClient.GetDatabase("cosmos").GetContainer("invoices");
                try
                {
                    var response = await container.DeleteItemAsync<dynamic>(id.ToString(), new PartitionKey(id.ToString()));
                }
                catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return Results.NotFound();
                }
                return Results.Ok();
            })
            .WithName("DeleteInvoice")
            .WithOpenApi();
        }
    }
}
