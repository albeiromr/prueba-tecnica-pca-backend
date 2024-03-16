using Application.Commons.Interfaces;
using Domain.Commons.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using Application.Commons.Constants;
using Application.Flights.Responses;
using Application.Flights.Interfaces;

namespace Application.Flights.GetFlights;

internal sealed class GetFlightsQueryHandler : IQueryHandler<GetFlightsQuery, List<FlightResponse>>
{
    private readonly IFlightRepository? _flightRepository;

    public GetFlightsQueryHandler(IFlightRepository? flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<Result<List<FlightResponse>>> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var flights = await _flightRepository!.GetFlightsAsync(cancellationToken);
            return new Result<List<FlightResponse>>(flights, true, null!);

        }
        catch (Exception ex)
        {
            return new Result<List<FlightResponse>>(default!, false, new Error(
                Constants.FlightsQueryError!,
                ex.Message
            ));
        }
    }
}
