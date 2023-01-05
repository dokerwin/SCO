using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCO.Contracts.Identity;
using SCO.Contracts.Requests.Identity;
using SCO.Contracts.Responses.Identity;
using SCO.Identity.Application.Authentication.Commands.Login;
using SCO.Identity.Application.Authentication.Commands.Logout;
using SCO.Identity.Application.Authentication.Commands.RefreshToken;
using SCO.Identity.Application.Authentication.Commands.Register;
using System;
using System.Security.Claims;

namespace SCO.Identity.Api.Conrollers;
[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediatr;
    private readonly IValidator<RegisterRequest> _validator;
    public AuthenticationController(IMediator mediatr, IValidator<RegisterRequest> validator)
    {
        _mediatr = mediatr;
        _validator = validator;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {
        ValidationResult result = await _validator.ValidateAsync(registerRequest);

        if (!result.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, result);
        }

        var resultMessage = await _mediatr.Send(new RegisterCommand(registerRequest));

        RegisterResponse response = await Task.FromResult(resultMessage);

        return Ok(response);

    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        var result = await _mediatr.Send(new LoginCommand(loginRequest));

        AuthenticatedUserResponse response = await Task.FromResult(result);

        return Ok(response);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest refreshRequest)
    {
        var result = await _mediatr.Send(new RefreshTokenCommand(refreshRequest));

        AuthenticatedUserResponse response = await Task.FromResult(result);

        return Ok(response);
    }

    [Authorize]
    [HttpDelete("logout")]
    public async Task<IActionResult> Logout()
    {
        await _mediatr.Send(new LogoutCommand(HttpContext.User.FindFirstValue("id")));
        return NoContent();
    }
}