using Application.Commons.Interfaces;
using Domain.Commons.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using Application.Commons.Constants;
using Application.Reservations.Responses;
using Application.Reservations.Interfaces;

namespace Application.Reservations.GetReservations;

internal sealed class GetReservationsQueryHandler : IQueryHandler<GetReservationsQuery, List<ReservationResponse>>
{
    private readonly IReservationRepository? _reservationRepository;

    public GetReservationsQueryHandler(IReservationRepository? reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<Result<List<ReservationResponse>>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var reservations = await _reservationRepository!.GetReservationsAsync(cancellationToken);
            return new Result<List<ReservationResponse>>(reservations, true, null!);

        }
        catch (Exception ex)
        {
            return new Result<List<ReservationResponse>>(default!, false, new Error(
                Constants.ReservationsQueryError!,
                ex.Message
            ));
        }
    }
}
