using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Reservations;


namespace Infraestructure.Configurations;

/// <summary>
/// Contains the database table configuration and constraints for the Reservation entity
/// </summary>
internal sealed class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("reservations");

        builder.HasKey(reservation => reservation.Id);

        builder.Property(reservation => reservation.Id);

        builder.Property(reservation => reservation.ClientName);

        builder.Property(reservation => reservation.ClientLastName);

        builder.Property(reservation => reservation.ClientEmail);

        builder.Property(reservation => reservation.FlightCode);

        builder.Property(reservation => reservation.AirLineName);

        builder.Property(reservation => reservation.Origin);

        builder.Property(reservation => reservation.Destination);

        builder.Property(reservation => reservation.DepartureDate);

        builder.Property(reservation => reservation.PlaneSeat);
    }
}
