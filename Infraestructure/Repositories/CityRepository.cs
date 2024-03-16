using Application.Cities.Interfaces;
using Application.Cities.Responses;
using Domain.Cities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infraestructure.Repositories;

public sealed class CityRepository : ICityRepository
{
    private readonly AppDbContext? _appDbContext;

    public CityRepository(AppDbContext? appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<CityResponse>> GetCitiesAsync(CancellationToken cancellationToken = default)
    {
        var dbSet = _appDbContext!.Set<City>();
        var dbCities = await dbSet.ToListAsync<City>();

        List<CityResponse> cities = new List<CityResponse>();
        foreach (var city in dbCities)
        {
            var response = new CityResponse(city.CityName);
            cities.Add(response);
        }

        return cities;
    }
}
