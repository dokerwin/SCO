namespace SCO.Identity.Contracts.Authentication;


public record LoginRequest(
    string EmployeeID,
    string Password
);