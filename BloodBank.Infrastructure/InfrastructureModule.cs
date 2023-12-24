using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Refit;

using BloodBank.Domain.Interfaces;
using BloodBank.Infrastructure.Data;
using BloodBank.Infrastructure.Repositories;


namespace BloodBank.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories()
                .AddDbContexts(configuration);

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IDonorRepository, DonorRepository>();
        services.AddTransient<IDonationRepository, DonationRepository>();
        services.AddTransient<IBloodStorageRepository, BloodStorageRepository>();
        services.AddRefitClient<ICepRepository>().ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri("https://viacep.com.br/");
        });

        return services;
    }

    private static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DatabaseSettings:BloodBankConnectionString"];

        services.AddDbContext<BloodBankDbContext>(opts =>
                        opts.UseSqlServer(connectionString));

        return services;
    }
}