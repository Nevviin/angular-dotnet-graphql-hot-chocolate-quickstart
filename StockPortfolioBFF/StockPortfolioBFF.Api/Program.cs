using StockPortfolioBFF.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", p =>
    p.WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod()
    );
});

builder.AddGraphQL().AddApiTypes();
    

var app = builder.Build();

app.UseCors("AllowAngular");

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
