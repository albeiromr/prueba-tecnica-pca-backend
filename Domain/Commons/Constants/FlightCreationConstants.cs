namespace Domain.Commons.Constants;

/// <summary>
/// Represents the exceptions and error descriptions thrown when creating Error objects
/// </summary>
internal static class FlightCreationConstants
{
    public static string? InvalidFlightCode = "The provided flight code is invalid";
    public static string? ArrivalDateEarlierThanDeparture = "The Arrival date can´t be earlier than the departure date";
    public static string? ArrivalDateSameAsDeparture = "The Arrival date can´t be the same departure date";
    public static string? FlightPriceInZero = "A valid price for a new flight can´t be Zero";
}
