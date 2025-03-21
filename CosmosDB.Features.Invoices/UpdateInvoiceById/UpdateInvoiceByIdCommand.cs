using MediatR;

namespace CosmosDB.Features.Invoices.UpdateInvoiceById
{
    public class UpdateInvoiceByIdCommand : IRequest
    {
        public required Guid Id { get; set; }
        public decimal? Amount { get; set; }
        public string? Status { get; set; }
    }
}
