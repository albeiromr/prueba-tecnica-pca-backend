using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Cities;

namespace Infraestructure.Configurations;

/// <summary>
/// Contains the database table configuration and constraints for the City entity
/// </summary>
internal sealed class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("cities");

        builder.HasKey(city => city.Id);

        builder.Property(city => city.Id);

        builder.Property(city => city.CityName);
    }
}
