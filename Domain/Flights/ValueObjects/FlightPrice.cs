using Domain.Commons.Constants;
using System;

namespace Domain.Flights.ValueObjects;

/// <summary>
/// Represents the flight price that the user has to pay
/// </summary>
public sealed record FlightPrice
{
    public decimal? Value { get; init; }

    public FlightPrice(decimal price)
    {
        if (price <= 0)
            throw new ArgumentException(FlightCreationConstants.FlightPriceInZero, nameof(price));

        Value = price;
    }
}
