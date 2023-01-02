using SCO.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.Interfaces;
public interface IBasketQueryService
{
    public ItemDto GetById(Guid id);
    public ItemDto GetByName(string name);
    public IEnumerable<ItemDto> GetByCategory(string name);
    public IEnumerable<ItemDto> GetAllItemsInBasket();

}
