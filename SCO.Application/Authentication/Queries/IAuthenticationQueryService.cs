using SCO.Application.DTOs;
using SCO.Application.Services.Authentication.Common;

namespace SCO.Application.Services.Authentication.Commands;

public interface IAuthenticationQueryService
{
    AuthenticationResult Login(LoginDto loginDto);
}