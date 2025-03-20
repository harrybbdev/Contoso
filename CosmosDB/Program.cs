using CosmosDB.Features.Invoices;
using FluentValidation;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

System.Reflection.Assembly[] featureAssemblies = AppDomain.CurrentDomain
    .GetAssemblies()
    .Where(a => a.FullName != null && a.FullName.Contains(".Features.")) // Filter only feature assemblies
    .ToArray();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssemblies(featureAssemblies);
});

builder.Services.AddValidatorsFromAssemblies(featureAssemblies);

builder.Services.InjectInvoicesDependencies();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapInvoicesEndpoints();

app.Run();

