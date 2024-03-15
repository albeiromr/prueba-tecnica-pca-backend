using Domain.AirLines;
using Domain.AirLines.ValueObjects;
using Domain.Commons.ValueObjects;
using Domain.Flights.ValueObjects;

namespace Domain.Flights;

public sealed class Flights
{
    public AirLineName? AirLineName { get; private set; }
    public FlightCode? FlightCode { get; private set; }

    // poner destino y origen
}
