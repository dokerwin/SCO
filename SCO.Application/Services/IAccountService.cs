using SCO.Application.DTOs;
namespace SCO.Application.Services;
 public interface IAccountService
{
    void RegisterUser(RegisterUserDto userDto);
    string GenerateJwt(LoginDto user);
}