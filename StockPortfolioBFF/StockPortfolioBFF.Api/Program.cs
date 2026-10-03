using StockPortfolioBFF.Api.Filters;
using StockPortfolioBFF.Api.Middleware;
using StockPortfolioBFF.Application.Stocks;
using StockPortfolioBFF.Infrastructure.Repositories;
using HotChocolate;
using HotChocolate.Execution;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<GetStockByTicker>();


builder.Services.AddScoped<IStockRepository>(_ =>
new JsonStockRepository(
    System.IO.Path.Combine( AppContext.BaseDirectory, "StockDB", "StockDb.json")));

  

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", p =>
    p.WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod()
    );
});
builder.Services.AddLogging();
builder.AddGraphQL().AddApiTypes()
    .AddApplicationService<ILogger<GraphQLErrorFilter>>()
    .AddErrorFilter<GraphQLErrorFilter>();


var app = builder.Build();

app.UseCors("AllowAngular");

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);


