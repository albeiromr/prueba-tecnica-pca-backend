using Application.Commons.Interfaces;
using Application.Flights.Responses;
using System.Collections.Generic;

namespace Application.Flights.GetFlights;

public sealed record GetFlightsQuery() : IQuery<List<FlightResponse>>;