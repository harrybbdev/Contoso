using CosmosDB;
using CosmosDB.Features.Invoices;
using FluentValidation;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cosmosSettings = builder.Configuration.GetSection("CosmosDb").Get<CosmosDbSettings>();
builder.Services
    .AddSingleton(cosmosSettings!)
    .AddSingleton(sp =>
        new CosmosClient(cosmosSettings!.AccountEndpoint, cosmosSettings.AccountKey));

var featureAssemblies = AppDomain.CurrentDomain
    .GetAssemblies()
    .Where(a => a.FullName != null && a.FullName.Contains(".Features.")) // Filter only feature assemblies
    .ToArray();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssemblies(featureAssemblies);
})
.AddValidatorsFromAssemblies(featureAssemblies)
.InjectInvoicesDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapInvoicesEndpoints();

app.Run();

