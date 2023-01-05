using Microsoft.AspNetCore.Mvc;
using SCO.Application.DTOs;
using SCO.Application.Services.Authentication.Commands;
using SCO.Contracts.Identity;

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
    public IActionResult Register([FromBody] RegisterUserDto registerRequest)
    {
        var authResult = _authenticationCommandService.Register(registerRequest);

        var response = new AuthenticatedUserResponse() {
            };
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginRequest)
    {
        var authResult = _authenticationQueryService.Login(loginRequest);
        return Ok(loginRequest);
    }

}