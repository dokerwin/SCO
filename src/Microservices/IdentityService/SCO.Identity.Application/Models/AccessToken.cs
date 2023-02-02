namespace SCO.Identity.Application.Authentication.Models;

public class AccessToken
{
    public string Value { get; set; }
    public DateTime ExpirationTime { get; set; }
}
