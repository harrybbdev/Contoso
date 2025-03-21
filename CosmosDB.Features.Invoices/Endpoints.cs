using CosmosDB.Features.Invoices.CreateInvoice;
using CosmosDB.Features.Invoices.DeleteInvoiceById;
using CosmosDB.Features.Invoices.GetInvoiceById;
using Microsoft.AspNetCore.Builder;

namespace CosmosDB.Features.Invoices
{
    public static class Endpoints
    {
        public static void MapInvoicesEndpoints(this WebApplication app)
        {
            CreateInvoiceEndpoint.MapEndpoint(app);
            DeleteInvoiceEndpoint.MapEndpoint(app);
            GetInvoiceByIdEndpoint.MapEndpoint(app);
        }
    }
}
