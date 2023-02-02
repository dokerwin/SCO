using SCO.Contracts.Identity;
using SCO.Identity.Domain.Entities.Employees;

namespace SCO.Identity.Aplications.Authentication.Authenticators;

public interface IAuthenticator
{
    Task<AuthenticatedUserResponse> Authenticate(Cashier user);
}