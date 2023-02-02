using SCO.ProductService.Domain.Entities.Base;

namespace SCO.ProductService.Domain.Entities;

public class Currency : EntityBase<Guid>
{
    public string CurrencyName { get; set; }
    public string CurrencySign { get; set; }
}
