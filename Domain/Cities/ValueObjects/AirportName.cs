using Domain.Commons.Constants;
using System;

namespace Domain.Cities.ValueObjects;

public sealed record AirportName
{
    public string? Value { get; init; }

    public AirportName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException(CitiesCreationConstants.InvalidAirportName, nameof(name));
        if (name.Length < 3)
            throw new ArgumentException(CitiesCreationConstants.InvalidAirportName, nameof(name));

        Value = name;
    }
}
