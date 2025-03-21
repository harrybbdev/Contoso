using CosmosDb.Common.CosmosDb;
using CosmosDB;
using CosmosDB.Features.Invoices;
using CosmosDB.Setup.MediatR;
using CosmosDB.Setup.Middleware;
using FluentValidation;
using MediatR;
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
        new CosmosClient(cosmosSettings!.AccountEndpoint, cosmosSettings.AccountKey))
    .AddSingleton<CosmosDbClient>();

var featureAssemblies = AppDomain.CurrentDomain
    .GetAssemblies()
    .Where(a => a.FullName != null && a.FullName.Contains(".Features.")) // Filter only feature assemblies
    .ToArray();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssemblies(featureAssemblies);
})
.AddValidatorsFromAssemblies(featureAssemblies)
.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
.InjectInvoicesDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddExceptionMiddleware();

app.UseHttpsRedirection();

app.MapInvoicesEndpoints();

app.Run();

