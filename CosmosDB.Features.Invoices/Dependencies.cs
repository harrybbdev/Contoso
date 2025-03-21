using CosmosDB.Features.Invoices.CreateInvoice;
using CosmosDB.Features.Invoices.GetInvoiceById;
using Microsoft.Extensions.DependencyInjection;

namespace CosmosDB.Features.Invoices
{
    public static class Dependencies
    {
        public static IServiceCollection InjectInvoicesDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped<CreateInvoiceDataAccess>()
                .AddScoped<GetInvoiceByIdDataAccess>();
        }
    }
}
