using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using Application.Airlines.GetAirlines;

namespace Web_Api.Controllers;

[ApiController]
[Route("api/airlines")]
public class AirlineController : ControllerBase
{
    //Sender de mediatr
    private readonly ISender? _sender;

    public AirlineController(ISender? sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetAirlines(
        CancellationToken cancellationToken
    )
    {
        var query = new GetAirlinesQuery();
        var actionResult = await _sender!.Send(query, cancellationToken);
        return actionResult.Success ? Ok(actionResult) : NotFound();
    }
}
