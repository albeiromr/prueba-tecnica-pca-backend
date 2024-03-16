using Application.Cities.Responses;
using Application.Commons.Interfaces;
using System.Collections.Generic;

namespace Application.Users.GetUsers;

public sealed record GetCitiesQuery() : IQuery<List<CityResponse>>;