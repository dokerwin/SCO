namespace SCO.Contracts.DTOs;

public class BasketDto
{
    public Guid OrderId { get; set; }
    public DateTime OrderedOn { get; set; }
    public IEnumerable<BasketItemDetailDto> ItemDetails { get; set; }

}
