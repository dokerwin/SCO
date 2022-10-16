
namespace SCO.Application.Services;
 public interface IAccountService
{
    void RegisterUser(RegistereUserDto userDto);
    string GenerateJwt(LoginDto user);
}