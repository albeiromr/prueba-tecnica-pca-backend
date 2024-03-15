using Domain.Commons.Constants;
using Domain.Commons.Interfaces;
using System;

namespace Domain.AirLines.ValueObjects;

/// <summary>
/// Represent the airline alphanumeric identification code
/// </summary>
public sealed record AirlineCode
{
    public string? Value { get; init; }
    private readonly IRegularExpressionsService? _regularExpressionsService;

    public AirlineCode(string? airlineCode, IRegularExpressionsService regularExpressionsService)
    {
        _regularExpressionsService = regularExpressionsService;

        if (string.IsNullOrEmpty(airlineCode))
            throw new ArgumentException(AirlineCreationConstants.InvalidAirlineCode, nameof(airlineCode));
        if (!_regularExpressionsService!.IsValidAirlineCode(airlineCode))
            throw new ArgumentException(AirlineCreationConstants.InvalidAirlineCode, nameof(airlineCode));

        Value = airlineCode;
    }
}
