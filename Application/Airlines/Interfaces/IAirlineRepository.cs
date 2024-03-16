using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Application.Airlines.Responses;
using Domain.AirLines;

namespace Application.Airlines.Interfaces;

/// <summary>
/// Contains methos for accessing the database airlines table
/// </summary>
public interface IAirlineRepository
{
    Task<List<AirlineResponse>> GetAirlinesAsync(CancellationToken cancellationToken = default);

    Task<Airline> GetAirlineByNameAsync(
        string? airlineName,
        CancellationToken cancellationToken = default
    );
}