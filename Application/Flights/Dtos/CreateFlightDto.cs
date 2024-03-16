using System;

namespace Application.Flights.Dtos;

public class CreateFlightDto
{
    public string? AirLineName { get; set; }
    public string? Origin { get; set; }
    public string? Destination { get; set; }
    public DateOnly DepartureDate { get; set; }
    public DateOnly ArrivalDate { get; set; }
    public decimal FlightPrice { get; set; }
}
