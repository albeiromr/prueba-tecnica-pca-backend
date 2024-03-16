using System;
using Domain.Commons.Abstractions;

namespace Domain.AirLines;

/// <summary>
/// Represents every single airline such as avianca, wingo and so on
/// </summary>
public sealed class Airline : Entity
{
    public string? Name { get; private set; }
    public string? Code { get; private set; }

    /// <summary>
    /// Represents the amount of flights that an airline has created for selling seats
    /// </summary>
    public int FlightsCount { get; private set; }

    // this constructor is private to protect the Airline entity from external access
    private Airline(Guid id, string? name, string? code, int flightsCount) : base(id)
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
    public static Airline Create(string? name, string? code, int flightsCount)
    {
        return new Airline(Guid.NewGuid(), name, code, flightsCount);
    }

    /// <summary>
    /// increments the flights count in one unit
    /// </summary>
    public void IncrementsFlightsCount()
    {
        int count = FlightsCount;
        count += 1;
        FlightsCount = count;
    }

}
