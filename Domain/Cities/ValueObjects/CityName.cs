using Domain.Commons.Constants;
using Domain.Commons.Interfaces;
using System;

namespace Domain.Cities.ValueObjects;

public sealed record CityName
{
    public string? Value { get; init; }
    private readonly IRegularExpressionsService? _regularExpressionsService;

    public CityName(string? name, IRegularExpressionsService regularExpressionsService)
    {
        _regularExpressionsService = regularExpressionsService;

        if(string.IsNullOrEmpty(name))
            throw new ArgumentException(CitiesCreationConstants.InvalidCityName, nameof(name));
        if(!_regularExpressionsService!.IsValidNameOrLastName(name)) 
            throw new ArgumentException(CitiesCreationConstants.InvalidCityName, nameof(name));

        Value = name;
    }
}
