using Application.Flights.Interfaces;
using Application.Flights.Responses;
using Domain.AirLines;
using Domain.Commons.Abstractions;
using Domain.Flights;
using Domain.Reservations;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infraestructure.Repositories;

public sealed class FlightRepository : IFlightRepository
{
    private readonly AppDbContext? _appDbContext;

    public FlightRepository(AppDbContext? appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<FlightResponse>> GetFlightsAsync(CancellationToken cancellationToken = default)
    {
        var dbSet = _appDbContext!.Set<Flight>();
        var dbFlights = await dbSet.ToListAsync<Flight>();

        List<FlightResponse> flights = new List<FlightResponse>();
        foreach (var flight in dbFlights)
        {
            var response = new FlightResponse(
                flight.AirLineName,
                flight.FlightCode,
                flight.Origin,
                flight.Destination,
                flight.DepartureDate,
                flight.ArrivalDate,
                flight.FlightPrice
            );
            flights.Add(response);
        }

        return flights;
    }

    public async Task<Flight> GetFlightByCodeAsync(
        string? flightCode,
        CancellationToken cancellationToken = default
    )
    {
        var dbSet = _appDbContext!.Set<Flight>();
        var dbFlight = await dbSet.FirstOrDefaultAsync<Flight>(f => f.FlightCode == flightCode);

        return dbFlight!;
    }

    public void Add(Flight flight)
    {
        _appDbContext!.Add(flight);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await _appDbContext!.SaveChangesAsync(cancellationToken);
        return result;
    }
}
