using Domain.AirLines;
using Domain.Cities;
using Domain.Commons.Abstractions;
using Domain.Commons.Interfaces;
using Domain.Commons.ValueObjects;
using Domain.Flights.ValueObjects;
using System;

namespace Domain.Flights;

/// <summary>
/// Represents every single one of the airlines flights
/// </summary>
public sealed class Flight : Entity
{
    public AirLineName? AirLineName { get; private set; }
    public FlightCode? FlightCode { get; private set; }
    public City? Origin { get; private set; }
    public City? Destination { get; private set; }
    public FlightDuration? FlightDuration { get; private set; }
    public FlightPrice? FlightPrice { get; private set; }

    // this constructor is required for executing migrations with 
    // entity framework under the domain driven design architecture
    private Flight() { }

    private Flight(
        Guid id, 
        AirLineName? airLineName, 
        FlightCode? flightCode, 
        City? origin, 
        City? destination, 
        FlightDuration? flightDuration, 
        FlightPrice? flightPrice
    ): base(id)
    {
        AirLineName = airLineName;
        FlightCode = flightCode;
        Origin = origin;
        Destination = destination;
        FlightDuration = flightDuration;
        FlightPrice = flightPrice;
    }

    /// <summary>
    /// Returns a new flight instance
    /// </summary>
    public static Flight Create(
        Airline? airline,
        City? origin,
        City? destination,
        FlightDuration? flightDuration, 
        FlightPrice? flightPrice,
        IRegularExpressionsService regularExpressionsService
    )
    {
        // calculating the airline flight count
        int count = airline!.FlightsCount!.Value > 0 ? airline.FlightsCount!.Value : 1;
        // generating the flight code
        FlightCode code = new FlightCode($"{airline.Code}{count}", regularExpressionsService);

        return new Flight(
            Guid.NewGuid(),
            airline.Name,
            code,
            origin,
            destination,
            flightDuration,
            flightPrice
        );
    }
}
