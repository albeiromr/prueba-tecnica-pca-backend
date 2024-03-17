using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Application.Flights.Responses;
using Domain.Flights;

namespace Application.Flights.Interfaces;

/// <summary>
/// Contains methos for accessing the database flight table
/// </summary>
public interface IFlightRepository
{
    Task<List<FlightResponse>> GetFlightsAsync(CancellationToken cancellationToken = default);

    void Add(Flight flight);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}