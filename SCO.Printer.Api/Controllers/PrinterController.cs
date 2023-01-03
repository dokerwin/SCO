using Microsoft.AspNetCore.Mvc;
using SCO.PrinterService.Application.Commands;
using SCO.PrinterService.Application.DTOs;

namespace SCO.PrinterService.Api.Controllers;

[ApiController]
[Route("receipt")]
public class PrinterController : ControllerBase
{

    IPrintCommandService _printCommandService;
    public PrinterController(IPrintCommandService printCommandService)
    {
        _printCommandService = printCommandService;

    }

    [HttpPost("print")]
    public IActionResult Print([FromBody] TicketDto ticket)
    {
        var result = _printCommandService.Print(ticket);

        return Ok(result);
    }
}
