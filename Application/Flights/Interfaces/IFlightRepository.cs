using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Application.Flights.Responses;

namespace Application.Flights.Interfaces;

/// <summary>
/// Contains methos for accessing the database flight table
/// </summary>
public interface IFlightRepository
{
    Task<List<FlightResponse>> GetFlightsAsync(CancellationToken cancellationToken = default);
}