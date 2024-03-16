using Domain.AirLines;
using Domain.Commons.Abstractions;
using Domain.Commons.Interfaces;
using System;

namespace Domain.Flights;

/// <summary>
/// Represents every single one of the airlines flights
/// </summary>
public sealed class Flight : Entity
{
    public string? AirLineName { get; private set; }
    public string? FlightCode { get; private set; }
    public string? Origin { get; private set; }
    public string? Destination { get; private set; }
    public DateTime DepartureDate { get; private set; }
    public DateTime ArrivalDate { get; private set; }
    public decimal FlightPrice { get; private set; }

    // this constructor is required for executing migrations with 
    // entity framework under the domain driven design architecture
    private Flight() { }

    private Flight(
        Guid id, 
        string? airLineName, 
        string? flightCode, 
        string? origin, 
        string? destination, 
        DateTime departureDate,
        DateTime arrivalDate,
        decimal flightPrice
    ): base(id)
    {
        AirLineName = airLineName;
        FlightCode = flightCode;
        Origin = origin;
        Destination = destination;
        DepartureDate = departureDate;
        ArrivalDate = arrivalDate;
        FlightPrice = flightPrice;
    }

    /// <summary>
    /// Returns a new flight instance
    /// </summary>
    public static Flight Create(
        Airline? airline,
        string? origin,
        string? destination,
        DateTime departureDate,
        DateTime arrivalDate,
        decimal flightPrice
    )
    {
        // calculating the airline flight count
        int count = airline!.FlightsCount > 0 ? airline.FlightsCount : 1;
        // generating the flight code
        string code = $"{airline.Code}{count}";

        return new Flight(
            Guid.NewGuid(),
            airline.Name,
            code,
            origin,
            destination,
            departureDate,
            arrivalDate,
            flightPrice
        );
    }
}
