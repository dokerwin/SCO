using System.ComponentModel.DataAnnotations;

namespace SCO.Contracts.Requests.Identity;

public class RegisterDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string ConfirmPassword { get; set; }

    [Required]
    public Guid RoleId { get; set; }
}