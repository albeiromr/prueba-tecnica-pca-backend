using Application.Commons.Interfaces;
using Application.Reservations.Dtos;
using System;

namespace Application.Reservations.CreateReservation;

// Command for creating a new reservation
public record CreateReservationCommand(CreateReservationDto createReservationDto) : ICommand<Guid>;
