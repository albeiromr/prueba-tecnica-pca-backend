using Application.Commons.Constants;
using Application.Commons.Interfaces;
using Application.Flights.Interfaces;
using Application.Reservations.Interfaces;
using Domain.Commons.Abstractions;
using Domain.Reservations;
using Domain.Reservations.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Reservations.CreateReservation;

internal sealed class CreateReservationCommandHandler : ICommandHandler<CreateReservationCommand, Guid>
{
    private readonly IFlightRepository? _flightRepository;
    private readonly IReservationRepository? _reservationRepository;
    private readonly IPlaneSeatService? _planeSeatService;

    public CreateReservationCommandHandler(
        IFlightRepository? flightRepository,
        IReservationRepository reservationRepository,
        IPlaneSeatService planeSeatService
    )
    {
        _flightRepository = flightRepository;
        _reservationRepository = reservationRepository;
        _planeSeatService = planeSeatService;
    }

    public async Task<Result<Guid>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var flight = await _flightRepository!.GetFlightByCodeAsync(
            request.createReservationDto.FlightCode, 
            cancellationToken
            );

        try
        {
            var reservation = Reservation.Create(
                request.createReservationDto.ClientName,
                request.createReservationDto.ClientLastName,
                request.createReservationDto.ClientEmail,
                flight,
                _planeSeatService!
            );

            _reservationRepository!.Add(reservation);

            await _reservationRepository!.SaveChangesAsync(cancellationToken);

            return new Result<Guid>(reservation.Id, true, null!);
        }
        catch (Exception ex)
        {
            return new Result<Guid>(default, false, new Error(
                Constants.ReservationCreationError!,
                ex.Message
            ));
        }
    }
}
