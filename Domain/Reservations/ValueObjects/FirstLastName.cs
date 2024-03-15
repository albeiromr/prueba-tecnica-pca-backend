using Domain.Commons.Constants;
using Domain.Commons.Interfaces;
using System;

namespace Domain.Commons.ValueObjects;

/// <summary>
/// Represents a user´s first last name
/// </summary>
public sealed record FirstLastName
{
    private readonly IRegularExpressionsService _regularExpressionsService;

    /// <summary>
    /// Represents the first last name´s value
    /// </summary>
    public string? Value { get; init; }
    public FirstLastName(string firstLastName, IRegularExpressionsService regularExpressionsService)
    {
        _regularExpressionsService = regularExpressionsService;

        if (string.IsNullOrEmpty(firstLastName))
            throw new ArgumentException(ReservationCreationConstants.EmptyOrNullFirstLastName, nameof(firstLastName));

        if (!_regularExpressionsService.IsValidNameOrLastName(firstLastName))
            throw new ArgumentException(ReservationCreationConstants.InvalidFirstLastNameFormat, nameof(firstLastName));

        Value = firstLastName;
    }
}
