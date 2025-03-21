using MediatR;

namespace CosmosDB.Features.Invoices.CreateInvoice
{
    public class CreateInvoiceCommand : IRequest<Guid>
    {
        public decimal Amount { get; set; }
    }
}
