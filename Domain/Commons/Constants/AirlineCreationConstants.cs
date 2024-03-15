namespace Domain.Commons.Constants;

/// <summary>
/// Represents the exceptions and error descriptions thrown when creating Airline objects
/// </summary>
internal static class AirlineCreationConstants
{
    public static string? InvalidAirlineName = "The Airline name is invalid";
    public static string? InvalidAirlineCode = "The Airline code is invalid";
    public static string? NegativeFlightsCount = "The Airline flight count can´t be negative";
}
