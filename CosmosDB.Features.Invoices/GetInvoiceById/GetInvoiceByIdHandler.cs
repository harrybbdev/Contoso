using CosmosDb.Common.Exceptions;
using MediatR;

namespace CosmosDB.Features.Invoices.GetInvoiceById
{
    public class GetInvoiceByIdHandler : IRequestHandler<GetInvoiceByIdQuery, InvoiceDTO>
    {
        private readonly GetInvoiceByIdDataAccess _dataAccess;

        public GetInvoiceByIdHandler(GetInvoiceByIdDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<InvoiceDTO> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            var invoice = await _dataAccess.GetInvoiceByIdAsync(request.Id) ?? throw new NotFoundException($"Could not find invoice with ID {request.Id}");
            return new InvoiceDTO()
            {
                Id = invoice.Id,
                Amount = invoice.Amount,
                Status = invoice.Status,
            };
        }
    }
}
