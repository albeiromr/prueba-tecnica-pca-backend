using Domain.Commons.Interfaces;
using Domain.Commons.Services;
using Domain.Reservations.Interfaces;
using Domain.Reservations.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // injecting services
        services.AddScoped<IPlaneSeatService, PlaneSeatService>();
        services.AddScoped<IRegularExpressionsService, RegularExpressionsService>();

        return services;
    }
}
