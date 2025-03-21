using MediatR;
using Microsoft.AspNetCore.Builder;

namespace CosmosDB.Features.Invoices.GetInvoiceById
{
    public class GetInvoiceByIdEndpoint
    {
        public static void MapEndpoint(WebApplication app)
        {
            app.MapGet("/api/invoices/{id}", async (
                Guid id,
                IMediator mediator,
                CancellationToken token) =>
            {
                var request = new GetInvoiceByIdQuery() { Id = id };
                var invoice = await mediator.Send(request);
                return invoice;
            })
            .WithName("GetInvoiceById")
            .WithOpenApi();
        }
    }
}
