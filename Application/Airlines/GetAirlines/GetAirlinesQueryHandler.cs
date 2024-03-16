using Application.Commons.Interfaces;
using Domain.Commons.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using Application.Commons.Constants;
using Application.Airlines.Responses;
using Application.Airlines.Interfaces;

namespace Application.Airlines.GetAirlines;

internal sealed class GetAirlinesQueryHandler : IQueryHandler<GetAirlinesQuery, List<AirlineResponse>>
{
    private readonly IAirlineRepository? _airlineRepository;

    public GetAirlinesQueryHandler(IAirlineRepository? airlineRepository)
    {
        _airlineRepository = airlineRepository;
    }

    public async Task<Result<List<AirlineResponse>>> Handle(GetAirlinesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var airlines = await _airlineRepository!.GetAirlinesAsync(cancellationToken);
            return new Result<List<AirlineResponse>>(airlines, true, null!);

        }
        catch (Exception ex)
        {
            return new Result<List<AirlineResponse>>(default!, false, new Error(
                Constants.AirlinesQueryError!,
                ex.Message
            ));
        }
    }
}
