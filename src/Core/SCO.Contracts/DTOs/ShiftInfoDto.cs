namespace SCO.Contracts.DTOs;

public class ShiftInfoDto
{
    public Guid Id { get; set; }
    public DateTime StartedOn { get; set; }

    public Guid CashierId { get; set; }

}
