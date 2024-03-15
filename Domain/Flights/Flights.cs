using Domain.Cities;
using Domain.Commons.ValueObjects;
using Domain.Flights.ValueObjects;
using System;

namespace Domain.Flights;

/// <summary>
/// Represents every single one of the airlines flights
/// </summary>
public sealed class Flights
{
    public AirLineName? AirLineName { get; private set; }
    public FlightCode? FlightCode { get; private set; }
    public City? Origin { get; private set; }
    public City? Destination { get; private set; }
    public FlightDuration? FlightDuration { get; private set; }
    public FlightPrice? FlightPrice { get; private set; }
}
