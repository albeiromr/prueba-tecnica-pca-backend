namespace Application.Airlines.Responses;

public sealed record AirlineResponse
{
    public string? Name { get; init; }
    public string? Code { get; init; }

    public AirlineResponse(string? name, string? code)
    {
        Name = name;
        Code = code;
    }
}
