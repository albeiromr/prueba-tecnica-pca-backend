using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Flights;

namespace Infraestructure.Configurations;

/// <summary>
/// Contains the database table configuration and constraints for the flight entity
/// </summary>
internal sealed class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.ToTable("flights");

        builder.HasKey(flight => flight.Id);

        builder.Property(flight => flight.Id);

        builder.Property(flight => flight.AirLineName);

        builder.Property(flight => flight.FlightCode);

        builder.Property(flight => flight.Origin);

        builder.Property(flight => flight.Destination);

        builder.Property(flight => flight.DepartureDate);

        builder.Property(flight => flight.ArrivalDate);

        builder.Property(flight => flight.FlightPrice);
    }
}
