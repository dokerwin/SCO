using Microsoft.AspNetCore.Mvc;
using SCO.Contracts.Requests.Identity;
using SCO.ShiftService.Application.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SCO.ShiftService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        // GET: api/<ShiftController>
        [HttpGet("GetShiftInfo")]
        public ShiftInfoDto Get()
        {
            return new ShiftInfoDto();
        }
       
        // POST api/<ShiftController>
        [HttpPost("StartShift")]
        public void StartShift([FromBody] LoginRequest login)
        {

        }

        // POST api/<ShiftController>
        [HttpPost("EndShift")]
        public void EndShift([FromBody] LoginRequest login)
        {

        }
    }
}
