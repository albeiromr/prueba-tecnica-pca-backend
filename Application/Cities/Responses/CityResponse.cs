namespace Application.Cities.Responses;

public sealed record CityResponse
{
    public string? CityName { get; init; }
    public CityResponse(string? cityName)
    {
        CityName = cityName;
    }

}
