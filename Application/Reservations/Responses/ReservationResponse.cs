using System;

namespace Application.Reservations.Responses;

public sealed record ReservationResponse
{
    public string? ClientName { get; private set; }
    public string? ClientLastName { get; private set; }
    public string? ClientEmail { get; private set; }
    public string? FlightCode { get; private set; }
    public string? AirLineName { get; private set; }
    public string? Origin { get; private set; }
    public string? Destination { get; private set; }
    public DateTime DepartureDate { get; private set; }
    public string? PlaneSeat { get; private set; }

    public ReservationResponse(
        string? clientName,
        string? clientLastName,
        string? clientEmail,
        string? flightCode,
        string? airlineName,
        string? origin,
        string? destination,
        DateTime departureDate,
        string? planeSeat
    )
    {
        ClientName = clientName;
        ClientLastName = clientLastName;
        ClientEmail = clientEmail;
        FlightCode = flightCode;
        AirLineName = airlineName;
        Origin = origin;
        Destination = destination;
        DepartureDate = departureDate;
        PlaneSeat = planeSeat;
    }
}
