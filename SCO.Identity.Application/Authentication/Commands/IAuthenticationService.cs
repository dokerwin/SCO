using SCO.Identity.Application.Authentication.Common;
using SCO.Indentity.Application.DTOs;

namespace SCO.Identity.Application.Authentication.Commands;

public interface IAuthenticationCommandService
{
    AuthenticationResult Register(RegisterCashierDto registerCashierDto);
}