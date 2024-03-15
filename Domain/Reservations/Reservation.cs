using Domain.Cities;
using Domain.Commons.ValueObjects;
using Domain.Reservations.ValueObjects;
using System;

namespace Domain.Reservations;

/// <summary>
/// Represents every single one of the user reservation
/// </summary>
public sealed class Reservation
{
    public FirstName? ClientName { get; private set; }
    public FirstLastName? ClientLastName { get; private set; }
    public Email? UserLastName { get; private set; }
    public FlightCode? FlightCode { get; private set;}
    public AirLineName? AirLineName { get; private set; }
    public City? Origin { get; private set; }
    public City? Destination { get; private set; }
    public DateTime DepartureDate { get; private set; }

    /// <summary>
    /// Represents the seat where the client is gonig to be sat within the plane
    /// </summary>
    public PlaneSeat? PlaneSeat { get; private set; }

}
