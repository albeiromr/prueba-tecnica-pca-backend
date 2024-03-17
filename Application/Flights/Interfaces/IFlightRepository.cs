using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Application.Flights.Responses;
using Domain.Flights;
using Domain.AirLines;

namespace Application.Flights.Interfaces;

/// <summary>
/// Contains methos for accessing the database flight table
/// </summary>
public interface IFlightRepository
{
    Task<List<FlightResponse>> GetFlightsAsync(CancellationToken cancellationToken = default);

    Task<Flight> GetFlightByCodeAsync(
        string? flightCode,
        CancellationToken cancellationToken = default
    );

    void Add(Flight flight);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}