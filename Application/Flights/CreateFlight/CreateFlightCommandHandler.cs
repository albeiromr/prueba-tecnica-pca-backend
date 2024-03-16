using Application.Airlines.Interfaces;
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

            _rentalRepository.Add(rental);

            await _unitOfWork!.SaveChangesAsync(cancellationToken);

            return rental.Id;
        }
        catch (ConcurrencyException)
        {
            //Ojo!!! ConcurrencyException es una excepción personalizada que es explicada en
            // el video 47 del curso udemy concurrencia optimista
            return Result.CreateWithFailureStatus<Guid>(RentalErrors.Overlap);
        }

        //return new Result<Guid>(Guid.NewGuid(), false, null!);
        

    }
}
