﻿using Application.Airlines.Interfaces;
using Application.Airlines.Responses;
using Domain.AirLines;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infraestructure.Repositories;

public sealed class AirlineRepository : IAirlineRepository
{
    private readonly AppDbContext? _appDbContext;

    public AirlineRepository(AppDbContext? appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<AirlineResponse>> GetAirlinesAsync(CancellationToken cancellationToken = default)
    {
        var dbSet = _appDbContext!.Set<Airline>();
        var dbAirlines = await dbSet.ToListAsync<Airline>();

        List<AirlineResponse> airlines = new List<AirlineResponse>();
        foreach (var airline in dbAirlines)
        {
            var response = new AirlineResponse(airline.Name, airline.Code, airline.FlightsCount);
            airlines.Add(response);
        }

        return airlines;
    }

    public async Task<Airline> GetAirlineByNameAsync(
        string? airlineName,
        CancellationToken cancellationToken = default
    )
    {
        var dbSet = _appDbContext!.Set<Airline>();
        var dbAirline = await dbSet.FirstOrDefaultAsync<Airline>(a => a.Name == airlineName);

        return dbAirline!;
    }
}
