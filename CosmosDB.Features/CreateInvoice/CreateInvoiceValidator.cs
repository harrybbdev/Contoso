using FluentValidation;

namespace CosmosDB.Features.Invoices.CreateInvoice
{
    public class CreateInvoiceValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceValidator()
        {
            RuleFor(c => c.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero.");
        }
    }
}
