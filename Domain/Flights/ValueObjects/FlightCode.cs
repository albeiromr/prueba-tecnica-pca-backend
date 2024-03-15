using Domain.Commons.Constants;
using Domain.Commons.Interfaces;
using System;

namespace Domain.Flights.ValueObjects;

/// <summary>
/// Represents the individual an unique flight code
/// </summary>
public sealed record FlightCode
{
    public string? Value { get; init; }
    private readonly IRegularExpressionsService? _regularExpressionsService;

    public FlightCode(string code, IRegularExpressionsService regularExpressionsService)
    {
        _regularExpressionsService = regularExpressionsService;

        if (string.IsNullOrEmpty(code))
            throw new ArgumentException(FlightCreationConstants.InvalidFlightCode, nameof(code));
        if (!_regularExpressionsService!.IsValidFlightCode(code))
            throw new ArgumentException(FlightCreationConstants.InvalidFlightCode, nameof(code));

        Value = code;
    }
}
