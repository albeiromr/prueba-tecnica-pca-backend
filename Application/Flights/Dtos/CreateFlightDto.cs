using System;

namespace Application.Flights.Dtos;

public class CreateFlightDto
{
    public string? AirLineName { get; set; }
    public string? Origin { get; set; }
    public string? Destination { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public decimal FlightPrice { get; set; }
}
