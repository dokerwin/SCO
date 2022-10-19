using SCO.Application.DTOs;

namespace SCO.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Register(RegisterUserDto);
    AuthenticationResult Login(LoginDto);
}