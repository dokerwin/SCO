namespace SCO.Application.DTOs;
public class RegisterUserDto
{
    public string Email { get; set; }

    public string Firstname { get; set; }

    public string LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string Nationality { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }

    public int RoleId { get; set; } = 1;
}