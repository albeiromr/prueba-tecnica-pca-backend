﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Application.Reservations.Responses;
using Domain.Flights;
using Domain.Reservations;

namespace Application.Reservations.Interfaces;

/// <summary>
/// Contains methos for accessing the database reservations table
/// </summary>
public interface IReservationRepository
{
    Task<List<ReservationResponse>> GetReservationsAsync(CancellationToken cancellationToken = default);

    void Add(Reservation reservation);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}