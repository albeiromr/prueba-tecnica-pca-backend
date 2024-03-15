using Domain.Commons.Constants;
using Domain.Commons.Interfaces;
using System;

namespace Domain.Commons.ValueObjects;

/// <summary>
/// Represents a user´s email
/// </summary>
public sealed record Email
{
    private IRegularExpressionsService _RegularExpressionsService;

    /// <summary>
    /// Represents the email´s value
    /// </summary>
    public string? Value { get; init; }
    public Email(string email, IRegularExpressionsService RegularExpressionsService)
    {
        _RegularExpressionsService = RegularExpressionsService;

        if (string.IsNullOrEmpty(email))
            throw new ArgumentException(ReservationCreationConstants.EmptyOrNullEmail, nameof(email));

        if (!_RegularExpressionsService.IsValidEmail(email))
            throw new ArgumentException(ReservationCreationConstants.InvalidEmailFormat, nameof(email));

        Value = email;
    }
}
