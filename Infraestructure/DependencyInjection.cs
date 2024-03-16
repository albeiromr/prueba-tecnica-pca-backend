using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // getting the db connection string
        var connectionString = configuration.GetConnectionString("database") ??
            throw new ArgumentNullException(nameof(configuration));

        // adding the database context
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseCamelCaseNamingConvention();
        });

        // injecting repositories
        //services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
