using CosmosDB.Features.Invoices.CreateInvoice;
using Microsoft.AspNetCore.Builder;

namespace CosmosDB.Features.Invoices
{
    public static class Endpoints
    {
        public static void MapInvoicesEndpoints(this WebApplication app)
        {
            CreateInvoiceEndpoint.MapEndpoint(app);
        }
    }
}
