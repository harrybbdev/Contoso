using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CosmosDB.Features.Invoices.CreateInvoice
{
    public class CreateInvoiceEndpoint
    {
        public static void MapEndpoint(WebApplication app)
        {
            app.MapPost("/api/invoices", async (
                CreateInvoiceCommand command,
                IMediator mediator,
                IValidator<CreateInvoiceCommand> validator) =>
            {
                FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(command);
                if (!validationResult.IsValid)
                {
                    return Results.BadRequest(validationResult.Errors);
                }

                Guid id = await mediator.Send(command);
                return Results.Created($"/api/invoices/{id}", new { id });
            })
            .WithName("CreateInvoice")
            .WithOpenApi();
        }
    }
}
