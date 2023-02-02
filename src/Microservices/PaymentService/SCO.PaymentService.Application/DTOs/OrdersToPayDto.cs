namespace SCO.Contracts.DTOs;

public class OrdersToPaytDto
{
    public IEnumerable<ProductDto> Items { get; set; }
}