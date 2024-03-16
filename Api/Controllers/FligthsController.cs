using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using Application.Flights.GetFlights;
using Application.Flights.Dtos;
using Application.Flights.CreateFlight;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Web_Api.Controllers;

[ApiController]
[Route("api/flights")]
public class FlightsController : ControllerBase
{
    //Sender de mediatr
    private readonly ISender? _sender;

    public FlightsController(ISender? sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetFlights(
        CancellationToken cancellationToken
    )
    {
        var query = new GetFlightsQuery();
        var actionResult = await _sender!.Send(query, cancellationToken);
        return actionResult.Success ? Ok(actionResult) : NotFound();
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateFlight(
        [FromBody] CreateFlightDto body, 
        CancellationToken cancellationToken
    )
    {
        var command = new CreateFlightCommand(body);
        var actionResult = await _sender!.Send(command, cancellationToken);
        return actionResult.Success ? Ok(actionResult) : NotFound();
    }
}
