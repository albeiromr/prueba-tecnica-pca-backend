namespace Application.Airlines.Responses;

public sealed record AirlineResponse
{
    public string? Name { get; init; }
    public string? Code { get; init; }
    public int FlightsCount { get; init; }

    public AirlineResponse(string? name, string? code, int flightsCount)
    {
        Name = name;
        Code = code;
        FlightsCount = flightsCount;
    }
}
