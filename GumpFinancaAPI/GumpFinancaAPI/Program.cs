using GumpFinanca.Application.Handlers;
using GumpFinanca.MySql.Repositories;
using GumpFinancaAPI.Extensions;
using GumpFinancaAPI.Extensions.SwaggerConfigurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSwaggerConfig(builder.Configuration)
    .AddControllers();

builder.Services.AddCustomCors();

builder.Services.AddRepository(builder.Configuration);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IncluirTransactionHandler).Assembly));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Financa API V1");
    options.RoutePrefix = string.Empty;
});

app.MapControllers();

await app.RunAsync();
