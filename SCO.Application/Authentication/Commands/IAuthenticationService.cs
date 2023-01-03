using SCO.Application.DTOs;
using SCO.Application.Services.Authentication.Common;

namespace SCO.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    AuthenticationResult Register(RegisterUserDto registerUserDto);
}