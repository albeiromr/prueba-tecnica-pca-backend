using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using Application.Reservations.GetReservations;
using Application.Reservations.Dtos;
using Application.Reservations.CreateReservation;

namespace Web_Api.Controllers;

[ApiController]
[Route("api/reservations")]
public class ReservationsController : ControllerBase
{
    //Sender de mediatr
    private readonly ISender? _sender;

    public ReservationsController(ISender? sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetReservations(
        CancellationToken cancellationToken
    )
    {
        var query = new GetReservationsQuery();
        var actionResult = await _sender!.Send(query, cancellationToken);
        return actionResult.Success ? Ok(actionResult) : NotFound();
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateReservation(
        [FromBody] CreateReservationDto body,
        CancellationToken cancellationToken
    )
    {
        var command = new CreateReservationCommand(body);
        var actionResult = await _sender!.Send(command, cancellationToken);
        return actionResult.Success ? Ok(actionResult) : NotFound();
    }
}
