using Domain.Commons.Constants;
using System;

namespace Domain.AirLines.ValueObjects;

public sealed record AirlineFlightCount
{
    public int Value { get; init; }

    public AirlineFlightCount(int count)
    {
        if (count < 0)
            throw new ArgumentException(AirlineCreationConstants.NegativeFlightsCount, nameof(count));

        Value = count;
    }
}
