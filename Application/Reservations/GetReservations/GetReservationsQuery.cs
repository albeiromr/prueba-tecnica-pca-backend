using Application.Commons.Interfaces;
using Application.Flights.Responses;
using Application.Reservations.Responses;
using System.Collections.Generic;

namespace Application.Reservations.GetReservations;

public sealed record GetReservationsQuery() : IQuery<List<ReservationResponse>>;