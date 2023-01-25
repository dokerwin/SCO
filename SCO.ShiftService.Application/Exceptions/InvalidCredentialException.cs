namespace SCO.ShiftService.Application.Exceptions;

public class InvalidCredentialException : Exception
{
    public InvalidCredentialException(string? message) : base(message)
    {
    }

}