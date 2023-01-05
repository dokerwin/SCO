using System.ComponentModel.DataAnnotations;

namespace SCO.Contracts.Requests.Identity;

public class RefreshTokenRequest
{
    [Required]
    public string RefreshToken { get; set; }
}
