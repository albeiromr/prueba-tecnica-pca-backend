using Application.Commons.Interfaces;
using Domain.Commons.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using Application.Users.GetUsers;
using Application.Cities.Responses;
using Application.Cities.Interfaces;
using Application.Commons.Constants;

internal sealed class GetCitiesQueryHandler : IQueryHandler<GetCitiesQuery, List<CityResponse>>
{
    private readonly ICityRepository? _cityRepository;

    public GetCitiesQueryHandler(ICityRepository? cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<Result<List<CityResponse>>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var cities = await _cityRepository!.GetCitiesAsync(cancellationToken);
            return new Result<List<CityResponse>>(cities, true, null!);

        }
        catch (Exception ex)
        {
            return new Result<List<CityResponse>>(default!, false, new Error(
                CitiesConstants.CitiesQueryError!,
                ex.Message
            ));
        }
    }
}
