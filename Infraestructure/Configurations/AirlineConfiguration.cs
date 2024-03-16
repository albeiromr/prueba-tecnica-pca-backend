using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.AirLines;

namespace Infraestructure.Configurations;

/// <summary>
/// Contains the database table configuration and constraints for the Airline entity
/// </summary>
internal sealed class AirlineConfiguration : IEntityTypeConfiguration<Airline>
{
    public void Configure(EntityTypeBuilder<Airline> builder)
    {
        builder.ToTable("airlines");

        builder.HasKey(airline => airline.Id);

        builder.Property(airline => airline.Id);

        builder.Property(airline => airline.Name);

        builder.Property(airline => airline.Code);

        builder.Property(airline => airline.FlightsCount);
    }
}
