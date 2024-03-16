using Domain.Commons.Interfaces;
using Domain.Commons.Services;
using Domain.Reservations.Interfaces;
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

        // injecting services
        services.AddScoped<IPlaneSeatService, PlaneSeatService>();
        services.AddScoped<IRegularExpressionsService, RegularExpressionsService>();

        return services;
    }
}
