namespace SCO.Contracts.DTOs;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Barcode { get; set; }
    public string ShortName { get; set; }
    public decimal UnitPrice { get; set; }
    public Guid CategoryId { get; set; }
}
