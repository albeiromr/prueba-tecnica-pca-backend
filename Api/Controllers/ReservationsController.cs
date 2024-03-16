using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using Application.Reservations.GetReservations;

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
}
