using GumpFinanca.Domain.Entities;
using GumpFinanca.Domain.Repositories;
using GumpFinanca.MySql.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GumpFinanca.MySql.Repositories;

public static class AddRepositorySetup
{
    public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MySqlContext>(options =>
        {
            options.UseMySql(
                configuration.GetConnectionString("FinancaConnection"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("FinancaConnection"))
            );
        });
        services.AddScoped<IBaseRepository<Transaction>, BaseRepository<Transaction>>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        return services;
    }
}
