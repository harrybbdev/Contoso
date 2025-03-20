using CosmosDB.Features.Invoices.CreateInvoice;
using Microsoft.Extensions.DependencyInjection;

namespace CosmosDB.Features.Invoices
{
    public static class Dependencies
    {
        public static IServiceCollection InjectInvoicesDependencies(this IServiceCollection services)
        {
            return services.AddScoped<CreateInvoiceDataAccess>();
        }
    }
}
