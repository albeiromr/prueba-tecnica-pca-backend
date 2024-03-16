using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Application.Cities.Responses;

namespace Application.Cities.Interfaces;

/// <summary>
/// Contains methos for accessing the database cities table
/// </summary>
public interface ICityRepository
{
    Task<List<CityResponse>> GetCitiesAsync(CancellationToken cancellationToken = default);
}