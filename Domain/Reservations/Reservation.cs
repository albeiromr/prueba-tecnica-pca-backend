using Domain.Cities;
using Domain.Commons.Abstractions;
using Domain.Commons.ValueObjects;
using Domain.Flights;
using Domain.Reservations.Interfaces;
using Domain.Reservations.ValueObjects;
using System;

namespace Domain.Reservations;

/// <summary>
/// Represents every single one of the user reservation
/// </summary>
public sealed class Reservation : Entity
{
    public FirstName? ClientName { get; private set; }
    public FirstLastName? ClientLastName { get; private set; }
    public Email? ClientEmail { get; private set; }
    public FlightCode? FlightCode { get; private set;}
    public AirLineName? AirLineName { get; private set; }
    public City? Origin { get; private set; }
    public City? Destination { get; private set; }
    public DateTime DepartureDate { get; private set; }

    /// <summary>
    /// Represents the seat where the client is gonig to be sat within the plane
    /// </summary>
    public PlaneSeat? PlaneSeat { get; private set; }

    // this constructor is required for executing migrations with 
    // entity framework under the domain driven design architecture
    private Reservation(){}

    public Reservation(
        Guid id,
        FirstName? clientName,
        FirstLastName? clientLastName,
        Email? clientEmail,
        FlightCode? flightCode,
        AirLineName? airlineName,
        City? origin,
        City? destination,
        DateTime departureDate,
        PlaneSeat? planeSeat
    ): base(id)
    {
        ClientName = clientName;
        ClientLastName = clientLastName;
        ClientEmail = clientEmail;
        FlightCode = flightCode;
        AirLineName = airlineName;
        Origin = origin;
        Destination = destination;
        DepartureDate = departureDate;
        PlaneSeat = planeSeat;
    }

    /// <summary>
    /// Returns a new Reservation instance
    /// </summary>
    public static Reservation Create(
        FirstName? clientName,
        FirstLastName? clientLastName,
        Email? clientEmail,
        Flight flight,
        IPlaneSeatService planeSeatService
    )
    {
        string? seatCode = planeSeatService!.GetSeatCode();
        PlaneSeat seat = new PlaneSeat(seatCode);
        
        return new Reservation(
            Guid.NewGuid(),
            clientName,
            clientLastName,
            clientEmail,
            flight.FlightCode,
            flight.AirLineName,
            flight.Origin,
            flight.Destination,
            flight.FlightDuration!.DepartureDate,
            seat
        );
    }
}
