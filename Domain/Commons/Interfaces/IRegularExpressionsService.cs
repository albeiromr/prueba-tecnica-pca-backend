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

    /// <summary>
    /// Validates a given string to verify if is a valid airline code
    /// </summary>
    bool IsValidAirlineCode(string airlineCode);

    /// <summary>
    /// Validates a given string to verify if is a valid flight code
    /// </summary>
    bool IsValidFlightCode(string flightCode);
}
