using GumpFinanca.MySql.Context;
using GumpFinanca.MySql.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("FinancaConnection");

builder.Services.AddDbContext<MySqlContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();


await app.RunAsync();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Financa API V1");
    options.RoutePrefix = string.Empty;
});

app.MapControllers();

await app.RunAsync();
