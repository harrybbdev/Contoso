using MediatR;

namespace CosmosDB.Features.Invoices.GetInvoiceById
{
    public class GetInvoiceByIdQuery : IRequest<InvoiceDTO>
    {
        public required Guid Id { get; set; }
    }
}
