using MediatR;

namespace CosmosDB.Features.Invoices.CreateInvoice
{
    internal class CreateInvoiceHandler : IRequestHandler<CreateInvoiceCommand, Guid>
    {
        private readonly CreateInvoiceDataAccess _dataAccess;

        public CreateInvoiceHandler(CreateInvoiceDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<Guid> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            Invoice invoice = new()
            {
                Amount = request.Amount,
                Status = "New"
            };

            await _dataAccess.CreateInvoiceAsync(invoice, cancellationToken);

            return Guid.Empty;
        }
    }
}
