using Domain.AirLines.Constants;
using Domain.Commons.Interfaces;
using System;

namespace Domain.AirLines.ValueObjects;

/// <summary>
/// Represents the complete airline name
/// </summary>
public sealed record AirLineName
{
    public string? Value { get; init; }
    private readonly IRegularExpressionsService? _regularExpressionsService;
    public AirLineName(string? name, IRegularExpressionsService regularExpressionsService)
    {
        _regularExpressionsService = regularExpressionsService;

        if (string.IsNullOrEmpty(name))
            throw new ArgumentException(AirlineCreationConstants.InvalidAirlineName, nameof(name));
        if (!_regularExpressionsService!.IsValidNameOrLastName(name))
            throw new ArgumentException(AirlineCreationConstants.InvalidAirlineName, nameof(name));

        Value = name;
    }
}
