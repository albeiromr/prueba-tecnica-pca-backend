using System;
using Domain.AirLines.ValueObjects;
using Domain.Commons.Abstractions;
using Domain.Commons.ValueObjects;

namespace Domain.AirLines;

/// <summary>
/// Represents every single airline such as avianca, wingo and so on
/// </summary>
public sealed class Airline : Entity
{
    public AirLineName? Name { get; private set; }
    public AirlineCode? Code { get; private set; }

    /// <summary>
    /// Represents the amount of flights that an airline has created for selling seats
    /// </summary>
    public AirlineFlightCount? FlightsCount { get; private set; }

    // this constructor is private to protect the Airline entity from external access
    private Airline(Guid id, AirLineName? name, AirlineCode? code, AirlineFlightCount flightsCount) : base(id)
    {
        Name = name;
        Code = code;
        FlightsCount = flightsCount;
    }

    // this constructor is required for executing migrations with 
    // entity framework under the domain driven design architecture
    private Airline(){}

    /// <summary>
    /// return a new Airline instance
    /// </summary>
    public static Airline Create(AirLineName? name, AirlineCode? code, AirlineFlightCount flightsCount)
    {
        return new Airline(Guid.NewGuid(), name, code, flightsCount);
    }

    /// <summary>
    /// increments the flights count in one unit
    /// </summary>
    public void IncrementsFlightsCount()
    {
        int count = FlightsCount!.Value;
        count += 1;
        AirlineFlightCount newFlightsCount = new AirlineFlightCount(count);
        FlightsCount = newFlightsCount;
    }

}
