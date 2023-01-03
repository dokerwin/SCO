using Microsoft.AspNetCore.Mvc;
using SCO.Indentity.Application.DTOs;
using SCO.Identity.Contracts.Authentication;
using SCO.Identity.Application.Authentication.Commands;

namespace SCO.Api.Conrollers;
[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationCommandService _authenticationCommandService;

    private readonly IAuthenticationQueryService _authenticationQueryService;
    public AuthenticationController(IAuthenticationCommandService authenticationCommandService, IAuthenticationQueryService authenticationQueryService)
    {
        _authenticationCommandService = authenticationCommandService;
        _authenticationQueryService = authenticationQueryService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterCashierDto registerRequest)
    {
        var authResult = _authenticationCommandService.Register(registerRequest);

        var response = new AuthenticationResponce(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token);
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginCashierDto loginRequest)
    {
        var authResult = _authenticationQueryService.Login(loginRequest);
        return Ok(loginRequest);
    }
}