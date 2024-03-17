using Application.Commons.Interfaces;
using Application.Flights.Dtos;
using System;

namespace Application.Flights.CreateFlight;

// Command for creating a new flight
public record CreateFlightCommand(CreateFlightDto createflightDto) : ICommand<Guid>;
