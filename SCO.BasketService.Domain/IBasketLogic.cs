namespace SCO.BasketService.Domain;

public interface IBasketLogic
{
    void AddItemToBasket(Guid itemId);
    void RemoveItemFromBasket(Guid itemId);
}