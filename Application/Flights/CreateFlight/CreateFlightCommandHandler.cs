using Application.Airlines.Interfaces;
using Application.Commons.Constants;
using Application.Commons.Interfaces;
using Application.Flights.Interfaces;
using Domain.Commons.Abstractions;
using Domain.Flights;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Flights.CreateFlight;

internal sealed class CreateFlightCommandHandler : ICommandHandler<CreateFlightCommand, Guid>
{
    private readonly IFlightRepository? _flightRepository;
    private readonly IAirlineRepository? _airlineRepository;

    public CreateFlightCommandHandler(
        IFlightRepository? flightRepository, 
        IAirlineRepository? airlineRepository
    )
    {
        _flightRepository = flightRepository;
        _airlineRepository = airlineRepository;
    }

    public async Task<Result<Guid>> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var airline = await _airlineRepository!.GetAirlineByNameAsync(
            request.createflightDto.AirLineName, 
            cancellationToken
            );

        try
        {
            var flight = Flight.Create(
                airline,
                request.createflightDto.Origin,
                request.createflightDto.Destination,
                request.createflightDto.DepartureDate,
                request.createflightDto.ArrivalDate,
                request.createflightDto.FlightPrice
            );

            _flightRepository!.Add(flight);

            await _flightRepository!.SaveChangesAsync(cancellationToken);

            return new Result<Guid>(flight.Id, true, null!);
        }
        catch (Exception ex)
        {
            return new Result<Guid>(default, false, new Error(
                Constants.FlightCreationError!,
                ex.Message
            ));
        }
    }
}
