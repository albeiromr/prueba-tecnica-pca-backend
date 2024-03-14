namespace Domain.Commons.Interfaces;

/// <summary>
/// Contains Methods for validating strings using regular expressions
/// </summary>
public interface IRegularExpressionsService
{
    /// <summary>
    /// Validates a given string to verify if is a valid email Address
    /// </summary>
    bool IsValidEmail(string email);

    /// <summary>
    /// Validates a given string to verify if is a valid name or last name
    /// </summary>
    bool IsValidNameOrLastName(string nameType);
}
