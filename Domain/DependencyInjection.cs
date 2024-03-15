using Domain.Commons.Interfaces;
using Domain.Commons.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class DependencyInjection
{
    /// <summary>
    /// Adds all the dependencies required for the domain layer to work properly
    /// </summary>
    public static IServiceCollection AddDomainLayer(this IServiceCollection services)
    {
        // transient services
        services.AddTransient<IRegularExpressionsService, RegularExpressionsService>();

        return services;
    }
}
