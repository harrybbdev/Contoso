using FluentValidation;

namespace CosmosDB.Features.Invoices.GetInvoiceById
{
    public class GetInvoiceByIdValidator : AbstractValidator<GetInvoiceByIdQuery>
    {
        public GetInvoiceByIdValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotNull().NotEqual(Guid.Empty).WithMessage("Id must be a valid non-empty Guid.");
        }
    }
}
