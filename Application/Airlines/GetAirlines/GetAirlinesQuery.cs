using Application.Airlines.Responses;
using Application.Commons.Interfaces;
using System.Collections.Generic;

namespace Application.Airlines.GetAirlines;

public sealed record GetAirlinesQuery() : IQuery<List<AirlineResponse>>;