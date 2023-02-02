namespace SCO.Contracts.DTOs;

public class BasketItemDetailDto
{
    public Guid Id { get; set; }
    public string ShortName { get; set; }
    public string Barcode { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}