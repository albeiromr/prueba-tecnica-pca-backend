using Domain.Commons.Constants;
using System;

namespace Domain.Reservations.ValueObjects;

/// <summary>
/// Represents every single one seat within the plane
/// </summary>
public sealed record PlaneSeat
{
    public string? Value;

    public PlaneSeat(string? seat)
    {
        if(string.IsNullOrEmpty(seat))
            throw new ArgumentException(ReservationCreationConstants.NullOrEmptySeat, nameof(seat));
        if (seat!.Length < 2)
            throw new ArgumentException(ReservationCreationConstants.SeatStringToShort, nameof(seat));
        if (seat!.Length > 3 )
            throw new ArgumentException(ReservationCreationConstants.SeatStringToLong, nameof(seat));

        Value = seat;
    }
}
