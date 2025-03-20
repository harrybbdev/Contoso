using Microsoft.Extensions.DependencyInjection;

namespace CosmosDB.Features.Invoices.CreateInvoice
{
    public static class CreateInvoiceDependencies
    {
        public static void AddInvoiceFeature(this IServiceCollection services)
        {
            services.AddScoped<CreateInvoiceDataAccess>();
        }
    }
}
