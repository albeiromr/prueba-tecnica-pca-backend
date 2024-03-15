using Domain.Commons.Constants;
using Domain.Commons.Interfaces;
using System;

namespace Domain.Commons.ValueObjects;

/// <summary>
/// Represents a user´s first name
/// </summary>
public sealed record FirstName
{
    private readonly IRegularExpressionsService _regularExpressionsService;

    /// <summary>
    /// Represents the first name´s value
    /// </summary>
    public string? Value { get; init; }
    public FirstName(string firstName, IRegularExpressionsService regularExpressionsService)
    {
        _regularExpressionsService = regularExpressionsService;

        if (string.IsNullOrEmpty(firstName))
            throw new ArgumentException(ReservationCreationConstants.EmptyOrNullFirstName, nameof(firstName));

        if (!_regularExpressionsService.IsValidNameOrLastName(firstName))
            throw new ArgumentException(ReservationCreationConstants.InvalidFirstNameFormat, nameof(firstName));

        Value = firstName;
    }
}
