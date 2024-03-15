using Domain.Commons.Constants;
using Domain.Commons.Interfaces;
using System;

namespace Domain.Commons.ValueObjects;

/// <summary>
/// Represents the individual an unique flight code
/// </summary>
public sealed record FlightCode
{
    private readonly IRegularExpressionsService? _regularExpressionsService;
    public string? Value { get; init; }


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
