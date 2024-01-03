using Microsoft.Extensions.DependencyInjection;

using BloodBank.Domain.DomainServices;

namespace BloodBank.Domain;

public static class DomainModule
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddServices();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IDonationService, DonationService>();

        return services;
    }
}