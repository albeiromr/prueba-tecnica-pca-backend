using Domain.Commons.Abstractions;
using Domain.Flights;
using Domain.Reservations.Interfaces;
using System;

namespace Domain.Reservations;

/// <summary>
/// Represents every single one of the user reservation
/// </summary>
public sealed class Reservation : Entity
{
    public string? ClientName { get; private set; }
    public string? ClientLastName { get; private set; }
    public string? ClientEmail { get; private set; }
    public string? FlightCode { get; private set;}
    public string? AirLineName { get; private set; }
    public string? Origin { get; private set; }
    public string? Destination { get; private set; }
    public DateTime DepartureDate { get; private set; }

    /// <summary>
    /// Represents the seat where the client is gonig to be sat within the plane
    /// </summary>
    public string? PlaneSeat { get; private set; }

    // this constructor is required for executing migrations with 
    // entity framework under the domain driven design architecture
    private Reservation(){}

    public Reservation(
        Guid id,
        string? clientName,
        string? clientLastName,
        string? clientEmail,
        string? flightCode,
        string? airlineName,
        string? origin,
        string? destination,
        DateTime departureDate,
        string? planeSeat
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
        string? clientName,
        string? clientLastName,
        string? clientEmail,
        Flight flight,
        IPlaneSeatService planeSeatService
    )
    {
        string? seatCode = planeSeatService!.GetSeatCode();
        
        return new Reservation(
            Guid.NewGuid(),
            clientName,
            clientLastName,
            clientEmail,
            flight.FlightCode,
            flight.AirLineName,
            flight.Origin,
            flight.Destination,
            flight.DepartureDate,
            seatCode
        );
    }
}
