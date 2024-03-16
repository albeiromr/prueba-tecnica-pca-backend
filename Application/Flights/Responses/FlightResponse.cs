using System;

namespace Application.Flights.Responses;

public sealed record FlightResponse
{
    public string? AirLineName { get; private set; }
    public string? FlightCode { get; private set; }
    public string? Origin { get; private set; }
    public string? Destination { get; private set; }
    public DateTime DepartureDate { get; private set; }
    public DateTime ArrivalDate { get; private set; }
    public decimal FlightPrice { get; private set; }

    public FlightResponse(
        string? airLineName, 
        string? flightCode, 
        string? origin, 
        string? destination, 
        DateTime departureDate,
        DateTime arrivalDate,
        decimal flightPrice
    )
    {
        AirLineName = airLineName;
        FlightCode = flightCode;
        Origin = origin;
        Destination = destination;
        DepartureDate = departureDate;
        ArrivalDate = arrivalDate;
        FlightPrice = flightPrice;
    }
}
