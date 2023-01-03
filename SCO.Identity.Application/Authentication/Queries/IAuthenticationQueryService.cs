using SCO.Identity.Application.Authentication.Common;
using SCO.Indentity.Application.DTOs;

namespace SCO.Identity.Application.Authentication.Commands;

public interface IAuthenticationQueryService
{
    AuthenticationResult Login(LoginCashierDto loginDto);
}