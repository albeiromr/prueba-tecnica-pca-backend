using Application.Reservations.Interfaces;
using Application.Reservations.Responses;
using Domain.AirLines;
using Domain.Flights;
using Domain.Reservations;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infraestructure.Repositories;

public sealed class ReservationRepository : IReservationRepository
{
    private readonly AppDbContext? _appDbContext;

    public ReservationRepository(AppDbContext? appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<ReservationResponse>> GetReservationsAsync(CancellationToken cancellationToken = default)
    {
        var dbSet = _appDbContext!.Set<Reservation>();
        var dbReservations = await dbSet.ToListAsync<Reservation>();

        List<ReservationResponse> reservations = new List<ReservationResponse>();
        foreach (var reservation in dbReservations)
        {
            var response = new ReservationResponse(
                reservation.ClientName,
                reservation.ClientLastName,
                reservation.ClientEmail,
                reservation.FlightCode,
                reservation.AirLineName,
                reservation.Origin,
                reservation.Destination,
                reservation.DepartureDate,
                reservation.PlaneSeat
            );
            reservations.Add(response);
        }

        return reservations;
    }

    public void Add(Reservation reservation)
    {
        _appDbContext!.Add(reservation);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await _appDbContext!.SaveChangesAsync(cancellationToken);
        return result;
    }
}
