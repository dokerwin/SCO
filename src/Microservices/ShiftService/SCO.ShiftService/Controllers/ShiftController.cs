using MediatR;
using Microsoft.AspNetCore.Mvc;
using SCO.Contracts.DTOs;
using SCO.Contracts.Requests.Identity;
using SCO.Contracts.Responses.Shift;
using SCO.ShiftService.Application.Commands;
using SCO.ShiftService.Application.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SCO.ShiftService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ShiftController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ShiftController>
        [HttpGet("ShiftInfo")]
        public async Task<ShiftInfoDto> Get()
        {
            var shiftResponse = await _mediator.Send(new ActualShiftInfoQuery());
            return shiftResponse.ShiftInfoDto;
        }
       
        // POST api/<ShiftController>
        [HttpPost("StartShift")]
        public async Task<StartShiftResponse> StartShift([FromBody] LoginRequest login)
        {
            var startShiftResponse =  await _mediator.Send(new StartShiftCommand(login));
            return startShiftResponse;
        }

        // POST api/<ShiftController>
        [HttpPost("EndShift")]
        public async void EndShift([FromBody] LoginRequest login)
        {
            await _mediator.Send(new EndShiftCommand(login));
        }
    }
}
