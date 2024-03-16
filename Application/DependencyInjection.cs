using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration => {

            // Adding commands queries and commands
            configuration.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
        });

        return services;
    }
}
