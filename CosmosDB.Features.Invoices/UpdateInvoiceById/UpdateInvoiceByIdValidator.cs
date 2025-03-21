using FluentValidation;

namespace CosmosDB.Features.Invoices.UpdateInvoiceById
{
    public class UpdateInvoiceByIdValidator : AbstractValidator<UpdateInvoiceByIdCommand>
    {
        public UpdateInvoiceByIdValidator()
        {
            RuleFor(x => x).Must(c => !string.IsNullOrEmpty(c.Status) || c.Amount.HasValue).WithMessage("Update must have at least one updated property");
            RuleFor(x => x.Amount).GreaterThan(0).When(x => x.Amount.HasValue).WithMessage("Amount must be greater than or equal to zero if provided");
        }
    }
}
